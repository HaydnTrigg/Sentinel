using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Win32;
using HaloOnlineTagTool;
using HaloOnlineTagTool.Common;
using HaloOnlineTagTool.Resources;
using HaloOnlineTagTool.Resources.Bitmaps;
using HaloOnlineTagTool.Resources.Geometry;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace Sentinel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public FileInfo MapFile { get; set; }

        public List<FileInfo> DatFiles { get; set; }

        public FileInfo TagsFile =>
            DatFiles.Find(file => file.Name == "tags.dat");

        public FileInfo StringIDsFile =>
            DatFiles.Find(file => file.Name == "string_ids.dat");

        public EngineVersion Version { get; set; }

        public TagCache TagCache { get; set; }

        public StringIdCache StringIDCache { get; set; }

        public Dictionary<int, TagInstance> MapTags { get; set; }

        public Dictionary<TagInstance, string> TagNames { get; set; }

        public TagInstance ScenarioTag { get; set; }

        public Scenario ScenarioDefinition { get; set; }

        public ScenarioStructureBsp BSPDefinition { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void renderer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Halo Online Maps (*.map)|*.map";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() != true)
                return;
            
            MapFile = new FileInfo(ofd.FileName);
            this.Title = $"Sentinel - {MapFile.FullName}";

            Application.Current.Dispatcher.Invoke(
                DispatcherPriority.Background,
                new Action(delegate
                {
                    LoadScenario();
                }));
        }

        private bool LoadCache()
        {
            var directory = MapFile.Directory;

            DatFiles = directory.GetFiles("*.dat").ToList();

            var tagsFile = TagsFile;
            var stringIDsFile = StringIDsFile;

            if (tagsFile == null || stringIDsFile == null)
            {
                var noTags = tagsFile == null;
                var noStringIDs = stringIDsFile == null;
                var message =
                    (noTags && noStringIDs) ?
                        "tags.dat or string_ids.dat" :
                    (noTags) ?
                        "tags.dat" :
                    (noStringIDs) ?
                        "string_ids.dat" :
                    "life";

                MessageBox.Show($"No {message} was found in the maps directory!",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                MapFile = null;

                if (DatFiles != null)
                {
                    DatFiles.Clear();
                    DatFiles = null;
                }

                return false;
            }

            renderer.InfoLabel.Content = "Loading tag cache...";
            renderer.Refresh();

            using (var tagCacheStream = tagsFile.OpenRead())
                TagCache = new TagCache(tagCacheStream);

            EngineVersion closestVersion;
            Version = VersionDetection.DetectVersion(TagCache, out closestVersion);

            if (Version == EngineVersion.Unknown)
                Version = closestVersion;

            renderer.InfoLabel.Content = "Loading string_ids...";
            renderer.Refresh();

            StringIdResolverBase stringIDsResolver = null;

            if (Version == EngineVersion.V12_1_700123_cert_ms30_oct19)
                stringIDsResolver = new HaloOnlineTagTool.V12_1_700123.StringIdResolver();
            else if (VersionDetection.Compare(Version, EngineVersion.V11_1_498295_Live) >= 0)
                stringIDsResolver = new HaloOnlineTagTool.V11_1_498295.StringIdResolver();
            else
                stringIDsResolver = new HaloOnlineTagTool.V1_106708.StringIdResolver();

            using (var stringIDsCacheStream = stringIDsFile.OpenRead())
                StringIDCache = new StringIdCache(stringIDsCacheStream, stringIDsResolver);

            var scenarioIndex = -1;

            using (var reader = new BinaryReader(MapFile.OpenRead()))
            {
                reader.BaseStream.Seek(4, SeekOrigin.Current);

                var mapFileVersion = reader.ReadInt32();

                if (mapFileVersion != 18)
                    throw new NotImplementedException("Only Halo Online map files are supported.");

                reader.BaseStream.Seek(0x011C, SeekOrigin.Begin);
                var buildName = new string(reader.ReadChars(32)).Trim();

                if (buildName.StartsWith("1.106708"))
                    reader.BaseStream.Seek(0x2DF0, SeekOrigin.Begin);
                else if (buildName.StartsWith("12.1.700123"))
                    reader.BaseStream.Seek(0x2E00, SeekOrigin.Begin);

                scenarioIndex = reader.ReadInt32();
                ScenarioTag = TagCache.Tags[scenarioIndex];
            }

            renderer.InfoLabel.Content = "Loading tag name database...";
            renderer.Refresh();

            TagNames = GetTagNames(Version);

            return true;
        }

        private void LoadScenario()
        {
            renderer.IsHitTestVisible = false;
            renderer.Viewport.Children.Clear();
            renderer.StatsLabel.Content = null;
            renderer.Refresh();

            if (GameObjects != null)
            {
                GameObjects.Clear();
                GameObjects = null;
            }

            if (Materials != null)
            {
                Materials.Clear();
                Materials = null;
            }

            if (Bitmaps != null)
            {
                Bitmaps.Clear();
                Bitmaps = null;
            }

            GC.Collect();

            if (!LoadCache())
                return;

            renderer.InfoLabel.Content = "Loading tag dependency graph...";
            renderer.Refresh();

            var mapTags = new Dictionary<int, TagInstance>();

            LoadTagDependencies(TagCache.Tags.FindFirstInGroup(new Tag("cfgt")).Index, ref mapTags);
            LoadTagDependencies(ScenarioTag.Index, ref mapTags);
            
            MapTags = mapTags;

            using (var cacheStream = DatFiles.Find(f => f.Name == "tags.dat").OpenRead())
            {
                renderer.StatsLabel.Content = "Loading resource cache...";
                renderer.Refresh();

                var resourceManager = new ResourceDataManager();
                resourceManager.LoadCachesFromDirectory(MapFile.Directory.FullName);

                var deserializer = new TagDeserializer(this.Version);
                
                renderer.StatsLabel.Content = "Loading scenario definition...";
                renderer.Refresh();

                var context = new TagSerializationContext(cacheStream, TagCache, StringIDCache, ScenarioTag);
                ScenarioDefinition = deserializer.Deserialize<Scenario>(context);

                renderer.StatsLabel.Content = "Loading bsp definition...";
                renderer.Refresh();

                context = new TagSerializationContext(cacheStream, TagCache, StringIDCache, ScenarioDefinition.StructureBsps[0].StructureBsp2);
                BSPDefinition = deserializer.Deserialize<ScenarioStructureBsp>(context);

                renderer.StatsLabel.Content = "Loading atmosphere...";
                renderer.Refresh();

                context = new TagSerializationContext(cacheStream, TagCache, StringIDCache, ScenarioDefinition.SkyReferences[0].SkyObject);
                var skyObject = deserializer.Deserialize(context, TagStructureTypes.FindByGroupTag(ScenarioDefinition.SkyReferences[0].SkyObject.GroupTag));

                context = new TagSerializationContext(cacheStream, TagCache, StringIDCache, ScenarioDefinition.SkyParameters);
                var skya = deserializer.Deserialize<SkyAtmParameters>(context);

                var lightGroup = new Model3DGroup();

                lightGroup.Children.Add(new AmbientLight(Colors.White));

                lightGroup.Children.Add(new AmbientLight(Color.FromRgb(
                    (byte)(skya.AtmosphereProperties[0].FogColorR * 100),
                    (byte)(skya.AtmosphereProperties[0].FogColorG * 100),
                    (byte)(skya.AtmosphereProperties[0].FogColorB * 100))));

                renderer.viewport.Children.Add(new ModelVisual3D { Content = lightGroup });

                var skyGroup = new Model3DGroup();
                skyGroup.Children.Add(LoadGameObject(cacheStream, resourceManager, deserializer, ScenarioDefinition.SkyReferences[0].SkyObject));

                renderer.viewport.Children.Add(new ModelVisual3D { Content = skyGroup });

                using (var bspStream = new MemoryStream())
                {
                    var bspTag = ScenarioDefinition.StructureBsps[0].StructureBsp2;
                    var groupName = StringIDCache.GetString(bspTag.GroupName);
                    if (!TagNames.ContainsKey(bspTag))
                        TagNames[bspTag] = $"0x{bspTag.Index:X8}";
                    renderer.InfoLabel.Content = $"Loading {TagNames[bspTag]}.{groupName}...";
                    renderer.Refresh();

                    resourceManager.Extract(BSPDefinition.Geometry2.Resource, bspStream);

                    var bspContext = new ResourceSerializationContext(BSPDefinition.Geometry2.Resource);
                    var bspGeometry = deserializer.Deserialize<RenderGeometryResourceDefinition>(bspContext);

                    var extractor = new ObjExtractor();
                    var clusterGroup = new Model3DGroup();
                    var instanceGroup = new Model3DGroup();

                    var materials = new List<MaterialGroup>();

                    renderer.StatsLabel.Content = "Loading bsp materials...";
                    renderer.Refresh();

                    foreach (var material in BSPDefinition.Materials)
                        materials.Add(LoadMaterial(cacheStream, resourceManager, material.RenderMethod));

                    renderer.StatsLabel.Content = "Loading bsp clusters...";
                    renderer.Refresh();

                    foreach (var cluster in BSPDefinition.Clusters)
                    {
                        Model3DGroup section = null;

                        section = LoadMesh(
                            BSPDefinition.Geometry2.Meshes[cluster.MeshIndex],
                            materials, bspStream, bspGeometry, extractor);

                        if (section == null)
                            continue;

                        clusterGroup.Children.Add(section);
                    }

                    var nc = new GeometryCompressionInfo();

                    renderer.StatsLabel.Content = "Loading bsp instanced geometry...";
                    renderer.Refresh();

                    foreach (var instance in BSPDefinition.InstancedGeometryInstances)
                    {
                        var section = LoadMesh(
                            BSPDefinition.Geometry2.Meshes[instance.MeshIndex],
                            materials, bspStream, bspGeometry, extractor,
                            BSPDefinition.Geometry2.Compression[instance.MeshIndex]);

                        if (section == null)
                            continue;
                        
                        var mat = Matrix3D.Identity;
                        mat.M11 = instance.ForwardI;
                        mat.M12 = instance.ForwardJ;
                        mat.M13 = instance.ForwardK;
                        mat.M21 = instance.LeftI;
                        mat.M22 = instance.LeftJ;
                        mat.M23 = instance.LeftK;
                        mat.M31 = instance.UpI;
                        mat.M32 = instance.UpJ;
                        mat.M33 = instance.UpK;
                        mat.OffsetX = instance.PositionX;
                        mat.OffsetY = instance.PositionY;
                        mat.OffsetZ = instance.PositionZ;

                        var transform = new Transform3DGroup();
                        transform.Children.Add(new ScaleTransform3D(instance.Scale, instance.Scale, instance.Scale));
                        transform.Children.Add(new MatrixTransform3D(mat));

                        var sectionGroup = new Model3DGroup();
                        sectionGroup.Children.Add(section);
                        sectionGroup.Transform = transform;

                        instanceGroup.Children.Add(sectionGroup);
                    }

                    var bspGroup = new Model3DGroup();
                    bspGroup.Children.Add(clusterGroup);
                    bspGroup.Children.Add(instanceGroup);

                    SetupCamera();

                    renderer.viewport.Children.Add(new ModelVisual3D { Content = bspGroup });

                    bspStream.Close();
                    bspStream.Dispose();
                }

                renderer.StatsLabel.Content = "Loading scenery...";
                renderer.Refresh();

                #region Scenery
                var sceneryGroup = new Model3DGroup();

                foreach (var entry in ScenarioDefinition.Scenery)
                {
                    var index = entry.PaletteIndex;

                    if (index < 0 || index >= ScenarioDefinition.SceneryPalette.Count)
                        continue;

                    var definition = ScenarioDefinition.SceneryPalette[index].Scenery;

                    var section = LoadGameObject(cacheStream, resourceManager, deserializer, definition);

                    if (section == null)
                        continue;

                    var position = new Vector3(entry.PositionX, entry.PositionY, entry.PositionZ);
                    var eulerRot = new Euler3(entry.RotationI, entry.RotationJ, entry.RotationK);

                    var mat = Matrix3D.Identity;

                    mat.OffsetX = position.X;
                    mat.OffsetY = position.Y;
                    mat.OffsetZ = position.Z;

                    var c1 = Math.Cos(eulerRot.Yaw.Radians * 0.5);
                    var c2 = Math.Cos(eulerRot.Pitch.Radians * 0.5);
                    var c3 = Math.Cos(eulerRot.Roll.Radians * 0.5);
                    var s1 = Math.Sin(eulerRot.Yaw.Radians * 0.5);
                    var s2 = Math.Sin(eulerRot.Pitch.Radians * 0.5);
                    var s3 = Math.Sin(eulerRot.Roll.Radians * 0.5);

                    mat.RotateAt(
                        new Quaternion(
                            c1 * c2 * s3 - s1 * s2 * c3,
                            c1 * s2 * c3 + s1 * c2 * s3,
                            s1 * c2 * c3 - c1 * s2 * s3,
                            c1 * c2 * c3 + s1 * s2 * s3),
                        new Point3D(position.X, position.Y, position.Z));
                    
                    var transform = new Transform3DGroup();
                    transform.Children.Add(new MatrixTransform3D(mat));

                    var sectionGroup = new Model3DGroup();
                    sectionGroup.Children.Add(section);
                    sectionGroup.Transform = transform;

                    sceneryGroup.Children.Add(sectionGroup);
                }

                renderer.viewport.Children.Add(new ModelVisual3D { Content = sceneryGroup });
                #endregion

                renderer.StatsLabel.Content = "Loading bipeds...";
                renderer.Refresh();

                #region Bipeds
                var bipedsGroup = new Model3DGroup();

                foreach (var entry in ScenarioDefinition.Bipeds)
                {
                    var index = entry.PaletteIndex;

                    if (index < 0 || index >= ScenarioDefinition.BipedPalette.Count)
                        continue;

                    var definition = ScenarioDefinition.BipedPalette[index].Biped;

                    var section = LoadGameObject(cacheStream, resourceManager, deserializer, definition);

                    if (section == null)
                        continue;

                    var position = new Vector3(entry.PositionX, entry.PositionY, entry.PositionZ);
                    var eulerRot = new Euler3(entry.RotationI, entry.RotationJ, entry.RotationK);

                    var mat = Matrix3D.Identity;

                    mat.OffsetX = position.X;
                    mat.OffsetY = position.Y;
                    mat.OffsetZ = position.Z;

                    var c1 = Math.Cos(eulerRot.Yaw.Radians * 0.5);
                    var c2 = Math.Cos(eulerRot.Pitch.Radians * 0.5);
                    var c3 = Math.Cos(eulerRot.Roll.Radians * 0.5);
                    var s1 = Math.Sin(eulerRot.Yaw.Radians * 0.5);
                    var s2 = Math.Sin(eulerRot.Pitch.Radians * 0.5);
                    var s3 = Math.Sin(eulerRot.Roll.Radians * 0.5);

                    mat.RotateAt(
                        new Quaternion(
                            c1 * c2 * s3 - s1 * s2 * c3,
                            c1 * s2 * c3 + s1 * c2 * s3,
                            s1 * c2 * c3 - c1 * s2 * s3,
                            c1 * c2 * c3 + s1 * s2 * s3),
                        new Point3D(position.X, position.Y, position.Z));
                    
                    var transform = new Transform3DGroup();
                    transform.Children.Add(new MatrixTransform3D(mat));

                    var sectionGroup = new Model3DGroup();
                    sectionGroup.Children.Add(section);
                    sectionGroup.Transform = transform;

                    bipedsGroup.Children.Add(sectionGroup);
                }

                renderer.viewport.Children.Add(new ModelVisual3D { Content = bipedsGroup });
                #endregion

                renderer.StatsLabel.Content = "Loading vehicles...";
                renderer.Refresh();

                #region Vehicles
                var vehiclesGroup = new Model3DGroup();

                foreach (var entry in ScenarioDefinition.Vehicles)
                {
                    var index = entry.PaletteIndex;

                    if (index < 0 || index >= ScenarioDefinition.VehiclePalette.Count)
                        continue;

                    var definition = ScenarioDefinition.VehiclePalette[index].Vehicle;

                    var section = LoadGameObject(cacheStream, resourceManager, deserializer, definition);

                    if (section == null)
                        continue;

                    var position = new Vector3(entry.PositionX, entry.PositionY, entry.PositionZ);
                    var eulerRot = new Euler3(entry.RotationI, entry.RotationJ, entry.RotationK);

                    var mat = Matrix3D.Identity;

                    mat.OffsetX = position.X;
                    mat.OffsetY = position.Y;
                    mat.OffsetZ = position.Z;

                    var c1 = Math.Cos(eulerRot.Yaw.Radians * 0.5);
                    var c2 = Math.Cos(eulerRot.Pitch.Radians * 0.5);
                    var c3 = Math.Cos(eulerRot.Roll.Radians * 0.5);
                    var s1 = Math.Sin(eulerRot.Yaw.Radians * 0.5);
                    var s2 = Math.Sin(eulerRot.Pitch.Radians * 0.5);
                    var s3 = Math.Sin(eulerRot.Roll.Radians * 0.5);

                    mat.RotateAt(
                        new Quaternion(
                            c1 * c2 * s3 - s1 * s2 * c3,
                            c1 * s2 * c3 + s1 * c2 * s3,
                            s1 * c2 * c3 - c1 * s2 * s3,
                            c1 * c2 * c3 + s1 * s2 * s3),
                        new Point3D(position.X, position.Y, position.Z));
                    
                    var transform = new Transform3DGroup();
                    transform.Children.Add(new MatrixTransform3D(mat));

                    var sectionGroup = new Model3DGroup();
                    sectionGroup.Children.Add(section);
                    sectionGroup.Transform = transform;

                    vehiclesGroup.Children.Add(sectionGroup);
                }

                renderer.viewport.Children.Add(new ModelVisual3D { Content = vehiclesGroup });
                #endregion

                renderer.StatsLabel.Content = "Loading equipment...";
                renderer.Refresh();

                #region Equipment
                var equipGroup = new Model3DGroup();

                foreach (var entry in ScenarioDefinition.Equipment)
                {
                    var index = entry.PaletteIndex;

                    if (index < 0 || index >= ScenarioDefinition.EquipmentPalette.Count)
                        continue;

                    var definition = ScenarioDefinition.EquipmentPalette[index].Equipment;

                    var section = LoadGameObject(cacheStream, resourceManager, deserializer, definition);

                    if (section == null)
                        continue;

                    var position = new Vector3(entry.PositionX, entry.PositionY, entry.PositionZ);
                    var eulerRot = new Euler3(entry.RotationI, entry.RotationJ, entry.RotationK);

                    var mat = Matrix3D.Identity;

                    mat.OffsetX = position.X;
                    mat.OffsetY = position.Y;
                    mat.OffsetZ = position.Z;

                    var c1 = Math.Cos(eulerRot.Yaw.Radians * 0.5);
                    var c2 = Math.Cos(eulerRot.Pitch.Radians * 0.5);
                    var c3 = Math.Cos(eulerRot.Roll.Radians * 0.5);
                    var s1 = Math.Sin(eulerRot.Yaw.Radians * 0.5);
                    var s2 = Math.Sin(eulerRot.Pitch.Radians * 0.5);
                    var s3 = Math.Sin(eulerRot.Roll.Radians * 0.5);

                    mat.RotateAt(
                        new Quaternion(
                            c1 * c2 * s3 - s1 * s2 * c3,
                            c1 * s2 * c3 + s1 * c2 * s3,
                            s1 * c2 * c3 - c1 * s2 * s3,
                            c1 * c2 * c3 + s1 * s2 * s3),
                        new Point3D(position.X, position.Y, position.Z));
                    
                    var transform = new Transform3DGroup();
                    transform.Children.Add(new MatrixTransform3D(mat));

                    var sectionGroup = new Model3DGroup();
                    sectionGroup.Children.Add(section);
                    sectionGroup.Transform = transform;

                    equipGroup.Children.Add(sectionGroup);
                }

                renderer.viewport.Children.Add(new ModelVisual3D { Content = equipGroup });
                #endregion

                renderer.StatsLabel.Content = "Loading weapons...";
                renderer.Refresh();

                #region Weapons
                var weaponsGroup = new Model3DGroup();

                foreach (var entry in ScenarioDefinition.Weapons)
                {
                    var index = entry.PaletteIndex;

                    if (index < 0 || index >= ScenarioDefinition.WeaponPalette.Count)
                        continue;

                    var definition = ScenarioDefinition.WeaponPalette[index].Weapon;

                    var section = LoadGameObject(cacheStream, resourceManager, deserializer, definition);

                    if (section == null)
                        continue;

                    var position = new Vector3(entry.PositionX, entry.PositionY, entry.PositionZ);
                    var eulerRot = new Euler3(entry.RotationI, entry.RotationJ, entry.RotationK);

                    var mat = Matrix3D.Identity;

                    mat.OffsetX = position.X;
                    mat.OffsetY = position.Y;
                    mat.OffsetZ = position.Z;

                    var c1 = Math.Cos(eulerRot.Yaw.Radians * 0.5);
                    var c2 = Math.Cos(eulerRot.Pitch.Radians * 0.5);
                    var c3 = Math.Cos(eulerRot.Roll.Radians * 0.5);
                    var s1 = Math.Sin(eulerRot.Yaw.Radians * 0.5);
                    var s2 = Math.Sin(eulerRot.Pitch.Radians * 0.5);
                    var s3 = Math.Sin(eulerRot.Roll.Radians * 0.5);

                    mat.RotateAt(
                        new Quaternion(
                            c1 * c2 * s3 - s1 * s2 * c3,
                            c1 * s2 * c3 + s1 * c2 * s3,
                            s1 * c2 * c3 - c1 * s2 * s3,
                            c1 * c2 * c3 + s1 * s2 * s3),
                        new Point3D(position.X, position.Y, position.Z));
                    
                    var transform = new Transform3DGroup();
                    transform.Children.Add(new MatrixTransform3D(mat));

                    var sectionGroup = new Model3DGroup();
                    sectionGroup.Children.Add(section);
                    sectionGroup.Transform = transform;

                    weaponsGroup.Children.Add(sectionGroup);
                }

                renderer.viewport.Children.Add(new ModelVisual3D { Content = weaponsGroup });
                #endregion

                renderer.StatsLabel.Content = "Loading machines...";
                renderer.Refresh();

                #region Machines
                var machinesGroup = new Model3DGroup();

                foreach (var entry in ScenarioDefinition.Machines)
                {
                    var index = entry.PaletteIndex;

                    if (index < 0 || index >= ScenarioDefinition.MachinePalette.Count)
                        continue;

                    var definition = ScenarioDefinition.MachinePalette[index].Machine;

                    var section = LoadGameObject(cacheStream, resourceManager, deserializer, definition);

                    if (section == null)
                        continue;

                    var position = new Vector3(entry.PositionX, entry.PositionY, entry.PositionZ);
                    var eulerRot = new Euler3(entry.RotationI, entry.RotationJ, entry.RotationK);

                    var mat = Matrix3D.Identity;

                    mat.OffsetX = position.X;
                    mat.OffsetY = position.Y;
                    mat.OffsetZ = position.Z;

                    var c1 = Math.Cos(eulerRot.Yaw.Radians * 0.5);
                    var c2 = Math.Cos(eulerRot.Pitch.Radians * 0.5);
                    var c3 = Math.Cos(eulerRot.Roll.Radians * 0.5);
                    var s1 = Math.Sin(eulerRot.Yaw.Radians * 0.5);
                    var s2 = Math.Sin(eulerRot.Pitch.Radians * 0.5);
                    var s3 = Math.Sin(eulerRot.Roll.Radians * 0.5);

                    mat.RotateAt(
                        new Quaternion(
                            c1 * c2 * s3 - s1 * s2 * c3,
                            c1 * s2 * c3 + s1 * c2 * s3,
                            s1 * c2 * c3 - c1 * s2 * s3,
                            c1 * c2 * c3 + s1 * s2 * s3),
                        new Point3D(position.X, position.Y, position.Z));
                    
                    var transform = new Transform3DGroup();
                    transform.Children.Add(new MatrixTransform3D(mat));

                    var sectionGroup = new Model3DGroup();
                    sectionGroup.Children.Add(section);
                    sectionGroup.Transform = transform;

                    machinesGroup.Children.Add(sectionGroup);
                }

                renderer.viewport.Children.Add(new ModelVisual3D { Content = machinesGroup });
                #endregion

                renderer.StatsLabel.Content = "Loading terminals...";
                renderer.Refresh();

                #region Terminals
                var terminalsGroup = new Model3DGroup();

                foreach (var entry in ScenarioDefinition.Terminals)
                {
                    var index = entry.PaletteIndex;

                    if (index < 0 || index >= ScenarioDefinition.TerminalPalette.Count)
                        continue;

                    var definition = ScenarioDefinition.TerminalPalette[index].Terminal;

                    var section = LoadGameObject(cacheStream, resourceManager, deserializer, definition);

                    if (section == null)
                        continue;

                    var position = new Vector3(entry.PositionX, entry.PositionY, entry.PositionZ);
                    var eulerRot = new Euler3(entry.RotationI, entry.RotationJ, entry.RotationK);

                    var mat = Matrix3D.Identity;

                    mat.OffsetX = position.X;
                    mat.OffsetY = position.Y;
                    mat.OffsetZ = position.Z;

                    var c1 = Math.Cos(eulerRot.Yaw.Radians * 0.5);
                    var c2 = Math.Cos(eulerRot.Pitch.Radians * 0.5);
                    var c3 = Math.Cos(eulerRot.Roll.Radians * 0.5);
                    var s1 = Math.Sin(eulerRot.Yaw.Radians * 0.5);
                    var s2 = Math.Sin(eulerRot.Pitch.Radians * 0.5);
                    var s3 = Math.Sin(eulerRot.Roll.Radians * 0.5);

                    mat.RotateAt(
                        new Quaternion(
                            c1 * c2 * s3 - s1 * s2 * c3,
                            c1 * s2 * c3 + s1 * c2 * s3,
                            s1 * c2 * c3 - c1 * s2 * s3,
                            c1 * c2 * c3 + s1 * s2 * s3),
                        new Point3D(position.X, position.Y, position.Z));
                    
                    var transform = new Transform3DGroup();
                    transform.Children.Add(new MatrixTransform3D(mat));

                    var sectionGroup = new Model3DGroup();
                    sectionGroup.Children.Add(section);
                    sectionGroup.Transform = transform;

                    terminalsGroup.Children.Add(sectionGroup);
                }

                renderer.viewport.Children.Add(new ModelVisual3D { Content = terminalsGroup });
                #endregion

                renderer.StatsLabel.Content = "Loading alternate reality devices...";
                renderer.Refresh();

                #region Alternate Reality Devices
                var ardGroup = new Model3DGroup();

                foreach (var entry in ScenarioDefinition.AlternateRealityDevices)
                {
                    var index = entry.PaletteIndex;

                    if (index < 0 || index >= ScenarioDefinition.AlternateRealityDevicePalette.Count)
                        continue;

                    var definition = ScenarioDefinition.AlternateRealityDevicePalette[index].ArgDevice;

                    var section = LoadGameObject(cacheStream, resourceManager, deserializer, definition);

                    if (section == null)
                        continue;

                    var position = new Vector3(entry.PositionX, entry.PositionY, entry.PositionZ);
                    var eulerRot = new Euler3(entry.RotationI, entry.RotationJ, entry.RotationK);

                    var mat = Matrix3D.Identity;

                    mat.OffsetX = position.X;
                    mat.OffsetY = position.Y;
                    mat.OffsetZ = position.Z;

                    var c1 = Math.Cos(eulerRot.Yaw.Radians * 0.5);
                    var c2 = Math.Cos(eulerRot.Pitch.Radians * 0.5);
                    var c3 = Math.Cos(eulerRot.Roll.Radians * 0.5);
                    var s1 = Math.Sin(eulerRot.Yaw.Radians * 0.5);
                    var s2 = Math.Sin(eulerRot.Pitch.Radians * 0.5);
                    var s3 = Math.Sin(eulerRot.Roll.Radians * 0.5);

                    mat.RotateAt(
                        new Quaternion(
                            c1 * c2 * s3 - s1 * s2 * c3,
                            c1 * s2 * c3 + s1 * c2 * s3,
                            s1 * c2 * c3 - c1 * s2 * s3,
                            c1 * c2 * c3 + s1 * s2 * s3),
                        new Point3D(position.X, position.Y, position.Z));
                    
                    var transform = new Transform3DGroup();
                    transform.Children.Add(new MatrixTransform3D(mat));

                    var sectionGroup = new Model3DGroup();
                    sectionGroup.Children.Add(section);
                    sectionGroup.Transform = transform;

                    ardGroup.Children.Add(sectionGroup);
                }

                renderer.viewport.Children.Add(new ModelVisual3D { Content = ardGroup });
                #endregion

                renderer.StatsLabel.Content = "Loading controls...";
                renderer.Refresh();

                #region Controls
                var controlsGroup = new Model3DGroup();

                foreach (var entry in ScenarioDefinition.Controls)
                {
                    var index = entry.PaletteIndex;

                    if (index < 0 || index >= ScenarioDefinition.ControlPalette.Count)
                        continue;

                    var definition = ScenarioDefinition.ControlPalette[index].Control;

                    var section = LoadGameObject(cacheStream, resourceManager, deserializer, definition);

                    if (section == null)
                        continue;

                    var position = new Vector3(entry.PositionX, entry.PositionY, entry.PositionZ);
                    var eulerRot = new Euler3(entry.RotationI, entry.RotationJ, entry.RotationK);

                    var mat = Matrix3D.Identity;

                    mat.OffsetX = position.X;
                    mat.OffsetY = position.Y;
                    mat.OffsetZ = position.Z;

                    var c1 = Math.Cos(eulerRot.Yaw.Radians * 0.5);
                    var c2 = Math.Cos(eulerRot.Pitch.Radians * 0.5);
                    var c3 = Math.Cos(eulerRot.Roll.Radians * 0.5);
                    var s1 = Math.Sin(eulerRot.Yaw.Radians * 0.5);
                    var s2 = Math.Sin(eulerRot.Pitch.Radians * 0.5);
                    var s3 = Math.Sin(eulerRot.Roll.Radians * 0.5);

                    mat.RotateAt(
                        new Quaternion(
                            c1 * c2 * s3 - s1 * s2 * c3,
                            c1 * s2 * c3 + s1 * c2 * s3,
                            s1 * c2 * c3 - c1 * s2 * s3,
                            c1 * c2 * c3 + s1 * s2 * s3),
                        new Point3D(position.X, position.Y, position.Z));
                    
                    var transform = new Transform3DGroup();
                    transform.Children.Add(new MatrixTransform3D(mat));

                    var sectionGroup = new Model3DGroup();
                    sectionGroup.Children.Add(section);
                    sectionGroup.Transform = transform;

                    controlsGroup.Children.Add(sectionGroup);
                }

                renderer.viewport.Children.Add(new ModelVisual3D { Content = controlsGroup });
                #endregion

                renderer.StatsLabel.Content = "Loading giants...";
                renderer.Refresh();

                #region Giants
                var giantsGroup = new Model3DGroup();

                foreach (var entry in ScenarioDefinition.Giants)
                {
                    var index = entry.PaletteIndex;

                    if (index < 0 || index >= ScenarioDefinition.GiantPalette.Count)
                        continue;

                    var definition = ScenarioDefinition.GiantPalette[index].Giant;

                    var section = LoadGameObject(cacheStream, resourceManager, deserializer, definition);

                    if (section == null)
                        continue;

                    var position = new Vector3(entry.PositionX, entry.PositionY, entry.PositionZ);
                    var eulerRot = new Euler3(entry.RotationI, entry.RotationJ, entry.RotationK);

                    var mat = Matrix3D.Identity;

                    mat.OffsetX = position.X;
                    mat.OffsetY = position.Y;
                    mat.OffsetZ = position.Z;

                    var c1 = Math.Cos(eulerRot.Yaw.Radians * 0.5);
                    var c2 = Math.Cos(eulerRot.Pitch.Radians * 0.5);
                    var c3 = Math.Cos(eulerRot.Roll.Radians * 0.5);
                    var s1 = Math.Sin(eulerRot.Yaw.Radians * 0.5);
                    var s2 = Math.Sin(eulerRot.Pitch.Radians * 0.5);
                    var s3 = Math.Sin(eulerRot.Roll.Radians * 0.5);

                    mat.RotateAt(
                        new Quaternion(
                            c1 * c2 * s3 - s1 * s2 * c3,
                            c1 * s2 * c3 + s1 * c2 * s3,
                            s1 * c2 * c3 - c1 * s2 * s3,
                            c1 * c2 * c3 + s1 * s2 * s3),
                        new Point3D(position.X, position.Y, position.Z));
                    
                    var transform = new Transform3DGroup();
                    transform.Children.Add(new MatrixTransform3D(mat));

                    var sectionGroup = new Model3DGroup();
                    sectionGroup.Children.Add(section);
                    sectionGroup.Transform = transform;

                    giantsGroup.Children.Add(sectionGroup);
                }

                renderer.viewport.Children.Add(new ModelVisual3D { Content = giantsGroup });
                #endregion

                renderer.StatsLabel.Content = "Loading effects scenery...";
                renderer.Refresh();

                #region Effects Scenery
                var esGroup = new Model3DGroup();

                foreach (var entry in ScenarioDefinition.EffectScenery)
                {
                    var index = entry.PaletteIndex;

                    if (index < 0 || index >= ScenarioDefinition.EffectScenery2.Count)
                        continue;

                    var definition = ScenarioDefinition.EffectScenery2[index].EffectScenery;

                    var section = LoadGameObject(cacheStream, resourceManager, deserializer, definition);

                    if (section == null)
                        continue;

                    var position = new Vector3(entry.PositionX, entry.PositionY, entry.PositionZ);
                    var eulerRot = new Euler3(entry.RotationI, entry.RotationJ, entry.RotationK);

                    var mat = Matrix3D.Identity;

                    mat.OffsetX = position.X;
                    mat.OffsetY = position.Y;
                    mat.OffsetZ = position.Z;

                    var c1 = Math.Cos(eulerRot.Yaw.Radians * 0.5);
                    var c2 = Math.Cos(eulerRot.Pitch.Radians * 0.5);
                    var c3 = Math.Cos(eulerRot.Roll.Radians * 0.5);
                    var s1 = Math.Sin(eulerRot.Yaw.Radians * 0.5);
                    var s2 = Math.Sin(eulerRot.Pitch.Radians * 0.5);
                    var s3 = Math.Sin(eulerRot.Roll.Radians * 0.5);

                    mat.RotateAt(
                        new Quaternion(
                            c1 * c2 * s3 - s1 * s2 * c3,
                            c1 * s2 * c3 + s1 * c2 * s3,
                            s1 * c2 * c3 - c1 * s2 * s3,
                            c1 * c2 * c3 + s1 * s2 * s3),
                        new Point3D(position.X, position.Y, position.Z));
                    
                    var transform = new Transform3DGroup();
                    transform.Children.Add(new MatrixTransform3D(mat));

                    var sectionGroup = new Model3DGroup();
                    sectionGroup.Children.Add(section);
                    sectionGroup.Transform = transform;

                    machinesGroup.Children.Add(sectionGroup);
                }

                renderer.viewport.Children.Add(new ModelVisual3D { Content = machinesGroup });
                #endregion
            }

            renderer.StatsLabel.Content = null;
            renderer.IsHitTestVisible = true;
            renderer.Refresh();

            var buildDate = DateTime.FromFileTime(TagCache.Timestamp);

            var label =
                string.Format("Halo Online {0} {1} ({2})",
                    VersionDetection.GetVersionString(Version),
                    buildDate.ToShortDateString(),
                    buildDate.ToShortTimeString());
            
            if (!TagNames.ContainsKey(ScenarioTag))
                TagNames[ScenarioTag] = $"0x{ScenarioTag.Index:X8}";
            renderer.InfoLabel.Content = $"{label} | {TagNames[ScenarioTag]}.scenario";
            renderer.Start();
        }

        private void SetupCamera()
        {
            var camera = (PerspectiveCamera)this.renderer.Viewport.Camera;

            var XBounds = new Range<float>(float.MaxValue, float.MinValue);
            var YBounds = new Range<float>(float.MaxValue, float.MinValue);
            var ZBounds = new Range<float>(float.MaxValue, float.MinValue);

            foreach (var cluster in BSPDefinition.Clusters)
            {
                if (cluster.MeshIndex >= BSPDefinition.Geometry2.Meshes.Count)
                    continue;

                if (BSPDefinition.Geometry2.Meshes[cluster.MeshIndex].Parts.Count == 0)
                    continue;

                if (cluster.BoundsXMin < XBounds.Min)
                    XBounds = new Range<float>(cluster.BoundsXMin, XBounds.Max);

                if (cluster.BoundsXMax > XBounds.Max)
                    XBounds = new Range<float>(XBounds.Min, cluster.BoundsXMax);

                if (cluster.BoundsYMin < YBounds.Min)
                    YBounds = new Range<float>(cluster.BoundsYMin, YBounds.Max);

                if (cluster.BoundsYMax > YBounds.Max)
                    YBounds = new Range<float>(YBounds.Min, cluster.BoundsYMax);

                if (cluster.BoundsZMin < ZBounds.Min)
                    ZBounds = new Range<float>(cluster.BoundsZMin, ZBounds.Max);

                if (cluster.BoundsZMax > ZBounds.Max)
                    ZBounds = new Range<float>(ZBounds.Min, cluster.BoundsZMax);
            }

            double pythagoras3d = Math.Sqrt(
                Math.Pow(XBounds.Max - XBounds.Min, 2) +
                Math.Pow(YBounds.Max - YBounds.Min, 2) +
                Math.Pow(ZBounds.Max - ZBounds.Min, 2));

            if (double.IsInfinity(pythagoras3d) || pythagoras3d == 0) //no clusters
            {
                XBounds = new Range<float>(BSPDefinition.WorldBoundsXMin, BSPDefinition.WorldBoundsXMax);
                YBounds = new Range<float>(BSPDefinition.WorldBoundsYMin, BSPDefinition.WorldBoundsYMax);
                ZBounds = new Range<float>(BSPDefinition.WorldBoundsZMin, BSPDefinition.WorldBoundsZMax);

                pythagoras3d = Math.Sqrt(
                    Math.Pow(XBounds.Max - XBounds.Min, 2) +
                    Math.Pow(YBounds.Max - YBounds.Min, 2) +
                    Math.Pow(ZBounds.Max - ZBounds.Min, 2));
            }

            var cameraPosition = new Point3D(
                XBounds.Max + pythagoras3d * 0.5,
                (YBounds.Max + YBounds.Min) / 2,
                (ZBounds.Max + ZBounds.Min) / 2);

            renderer.TranslateCamera(cameraPosition, new Vector3D(-1, 0, 0));

            renderer.CameraSpeed = Math.Ceiling(pythagoras3d * 3) / 5000;
            renderer.MaxCameraSpeed = Math.Ceiling(pythagoras3d * 3) * 5 / 1000;

            renderer.MaxPosition = new Point3D(
                BSPDefinition.WorldBoundsXMax + pythagoras3d * 2,
                BSPDefinition.WorldBoundsYMax + pythagoras3d * 2,
                BSPDefinition.WorldBoundsZMax + pythagoras3d * 2);

            renderer.MinPosition = new Point3D(
                BSPDefinition.WorldBoundsXMin - pythagoras3d * 2,
                BSPDefinition.WorldBoundsYMin - pythagoras3d * 2,
                BSPDefinition.WorldBoundsZMin - pythagoras3d * 2);

            renderer.FarPlaneMin = pythagoras3d * 0.01;
            renderer.FarPlane = pythagoras3d * pythagoras3d;
            renderer.FarPlaneMax = pythagoras3d * pythagoras3d;
        }

        private static Dictionary<TagInstance, Model3DGroup> GameObjects = null;
        
        private Model3DGroup LoadGameObject(Stream cacheStream, ResourceDataManager resourceManager, TagDeserializer deserializer, TagInstance tag)
        {
            if (tag == null || !tag.IsInGroup(new Tag("obje")))
                return null;

            var groupName = StringIDCache.GetString(tag.GroupName);
            if (!TagNames.ContainsKey(tag))
                TagNames[tag] = $"0x{tag.Index:X8}";
            renderer.InfoLabel.Content = $"Loading {TagNames[tag]}.{groupName}...";
            renderer.Refresh();

            if (GameObjects == null)
                GameObjects = new Dictionary<TagInstance, Model3DGroup>();

            if (GameObjects.ContainsKey(tag))
                return GameObjects[tag];
            
            var context = new TagSerializationContext(cacheStream, TagCache, StringIDCache, tag);
            var gameObject = (GameObject)deserializer.Deserialize(context, TagStructureTypes.FindByGroupTag(tag.GroupTag));
            var modelTag = gameObject.Model;

            if (modelTag == null)
                return null;

            context = new TagSerializationContext(cacheStream, TagCache, StringIDCache, gameObject.Model);
            var model = deserializer.Deserialize<Model>(context);
            var renderModelTag = model.RenderModel;
                
            if (renderModelTag == null)
                return null;

            context = new TagSerializationContext(cacheStream, TagCache, StringIDCache, model.RenderModel);
            var renderModel = deserializer.Deserialize<RenderModel>(context);

            var materials = new List<MaterialGroup>();
            foreach (var material in renderModel.Materials)
                materials.Add(LoadMaterial(cacheStream, resourceManager, material.RenderMethod));

            var renderModelGroup = new Model3DGroup();
            
            using (var renderModelStream = new MemoryStream())
            {
                resourceManager.Extract(renderModel.Geometry.Resource, renderModelStream);

                var renderModelContext = new ResourceSerializationContext(renderModel.Geometry.Resource);
                var renderModelGeometry = deserializer.Deserialize<RenderGeometryResourceDefinition>(renderModelContext);

                var extractor = new ObjExtractor();
                
                foreach (var region in renderModel.Regions)
                {
                    // TODO: determine default permutation
                    if (region.Permutations == null || region.Permutations.Count == 0)
                        continue;

                    var permutation = region.Permutations[0];

                    for (var i = 0; i < permutation.MeshCount; i++)
                    {
                        Model3DGroup section;
                        
                        section = LoadMesh(
                            renderModel.Geometry.Meshes[permutation.MeshIndex + i],
                            materials, renderModelStream, renderModelGeometry, extractor,
                            renderModel.Geometry.Compression[0]);

                        renderModelGroup.Children.Add(section);
                    }
                }

                renderModelStream.Close();
                renderModelStream.Dispose();
            }


            GameObjects[tag] = renderModelGroup;

            return renderModelGroup;
        }

        private static Dictionary<TagInstance, MaterialGroup> Materials = null;

        private MaterialGroup LoadMaterial(Stream cacheStream, ResourceDataManager resourceManager, TagInstance tag)
        {
            var errMat = new MaterialGroup();
            errMat.Children.Add(new DiffuseMaterial { Color = Colors.Gold });

            var groupName = StringIDCache.GetString(tag.GroupName);
            if (!TagNames.ContainsKey(tag))
                TagNames[tag] = $"0x{tag.Index:X8}";
            renderer.InfoLabel.Content = $"Loading {TagNames[tag]}.{groupName}...";
            renderer.Refresh();

            if (tag == null)
                return errMat;

            if (Materials == null)
                Materials = new Dictionary<TagInstance, MaterialGroup>();

            if (Materials.ContainsKey(tag))
                return Materials[tag];

            if (!tag.IsInGroup("rm  "))
            {
                Materials[tag] = errMat;
                return errMat;
            }

            var deserializer = new TagDeserializer(Version);
            var context = new TagSerializationContext(cacheStream, TagCache, StringIDCache, tag);
            var shader = (RenderMethod)deserializer.Deserialize(context, TagStructureTypes.FindByGroupTag(tag.GroupTag));

            if (shader == null)
            {
                Materials[tag] = errMat;
                return errMat;
            }

            context = new TagSerializationContext(cacheStream, TagCache, StringIDCache, shader.ShaderProperties[0].Template);
            var template = deserializer.Deserialize<RenderMethodTemplate>(context);

            if (template == null)
            {
                Materials[tag] = errMat;
                return errMat;
            }
            
            var bitmapIndex = 0;
            var bitmapArgName = "";

            for (var i = 0; i < template.ShaderMaps.Count; i++)
            {
                var usage = template.ShaderMaps[i];
                var name = StringIDCache.GetString(usage.Name);

                if (name.StartsWith("diffuse_map") || name.StartsWith("base_map") || name == "foam_texture")
                {
                    bitmapIndex = i;
                    bitmapArgName = name;
                    break;
                }
            }
            
            TagInstance bitmapTag;

            try
            {
                bitmapTag = shader.ShaderProperties[0].ShaderMaps[bitmapIndex].Bitmap;
            }
            catch
            {
                Materials[tag] = errMat;
                return errMat;
            }

            var diffuse = LoadBitmap(cacheStream, resourceManager, bitmapTag);

            if (diffuse == null)
            {
                Materials[tag] = errMat;
                return errMat;
            }

            var tileIndex = shader.ShaderProperties[0].ShaderMaps[bitmapIndex].UvArgumentIndex;

            float uTiling;
            try { uTiling = shader.ShaderProperties[0].Arguments[tileIndex].Arg1; }
            catch { uTiling = 1; }

            float vTiling;
            try { vTiling = shader.ShaderProperties[0].Arguments[tileIndex].Arg2; }
            catch { vTiling = 1; }

            var material = new MaterialGroup();

            material.Children.Add(
                new DiffuseMaterial()
                {
                    Brush = new ImageBrush(diffuse)
                    {
                        ViewportUnits = BrushMappingMode.Absolute,
                        TileMode = TileMode.Tile,
                        Viewport = new System.Windows.Rect(0, 0, 1f / Math.Abs(uTiling), 1f / Math.Abs(vTiling))
                    }
                });

            Materials[tag] = material;
            return material;
        }

        private static Dictionary<Mesh, Model3DGroup> Meshes = null;

        private Model3DGroup LoadMesh(Mesh mesh, List<MaterialGroup> materials, Stream meshStream, RenderGeometryResourceDefinition resource, ObjExtractor extractor, GeometryCompressionInfo compression = null)
        {
            if (Meshes == null)
                Meshes = new Dictionary<Mesh, Model3DGroup>();

            if (Meshes.ContainsKey(mesh))
                return Meshes[mesh];
            
            if (mesh.Parts.Count == 0)
                return null;

            var reader = new MeshReader(Version, mesh, resource);
            var compressor = compression == null ? null : new VertexCompressor(compression);

            var vertices = ObjExtractor.ReadVertices(reader, meshStream);
            if (compressor != null)
                ObjExtractor.DecompressVertices(vertices, compressor);

            var group = new Model3DGroup();

            if (materials == null)
            {
                materials = new List<MaterialGroup>();
                var matGroup = new MaterialGroup();
                matGroup.Children.Add(new DiffuseMaterial() { Color = Colors.Gold });
                materials.Add(matGroup);
            }

            foreach (var part in mesh.Parts)
            {
                var partIndices = ObjExtractor.ReadIndices(reader, part, meshStream);

                var geom = new MeshGeometry3D();

                foreach (var v in vertices)
                {
                    geom.Positions.Add(new Point3D(v.Position.X, v.Position.Y, v.Position.Z));
                    geom.Normals.Add(new Vector3D(v.Position.X, v.Position.Y, v.Position.Z));
                    geom.TextureCoordinates.Add(new Point(v.TexCoords.X, v.TexCoords.Y));
                }

                for (var x = 0; x < partIndices.Length; x += 3)
                {
                    var a = partIndices[x];
                    var b = partIndices[x + 1];
                    var c = partIndices[x + 2];

                    if (a == b || a == c || b == c)
                        continue;

                    geom.TriangleIndices.Add((int)a);
                    geom.TriangleIndices.Add((int)b);
                    geom.TriangleIndices.Add((int)c);
                }

                var model = new GeometryModel3D(geom, materials[part.MaterialIndex]);
                group.Children.Add(model);
            }

            Meshes[mesh] = group;
            return group;
        }

        private static Dictionary<TagInstance, BitmapImage> Bitmaps = null;

        public BitmapImage LoadBitmap(Stream cacheStream, ResourceDataManager resourceManager, TagInstance bitmapTag)
        {
            if (bitmapTag == null)
                return null;

            var groupName = StringIDCache.GetString(bitmapTag.GroupName);
            if (!TagNames.ContainsKey(bitmapTag))
                TagNames[bitmapTag] = $"0x{bitmapTag.Index:X8}";
            renderer.InfoLabel.Content = $"Loading {TagNames[bitmapTag]}.{groupName}...";
            renderer.Refresh();

            if (Bitmaps == null)
                Bitmaps = new Dictionary<TagInstance, BitmapImage>();

            if (Bitmaps.ContainsKey(bitmapTag))
                return Bitmaps[bitmapTag];
            
            var deserializer = new TagDeserializer(Version);
            var context = new TagSerializationContext(cacheStream, TagCache, StringIDCache, bitmapTag);
            var bitmap = deserializer.Deserialize<Bitmap>(context);
            var extractor = new BitmapDdsExtractor(resourceManager);

            System.Drawing.Bitmap bmp = null;

            using (var ddsStream = new MemoryStream())
            {
                extractor.ExtractDds(deserializer, bitmap, 0, ddsStream);

                // Create a DevIL image "name" (which is actually a number)
                int img_name;
                DevIL.ilGenImages(1, out img_name);
                DevIL.ilBindImage(img_name);

                var ddsData = ddsStream.ToArray();

                // Load the DDS file into the bound DevIL image
                DevIL.ilLoadL(DevIL.IL_DDS, ddsData, ddsData.Length);

                // Set a few size variables that will simplify later code

                int ImgWidth = DevIL.ilGetInteger(DevIL.IL_IMAGE_WIDTH);
                int ImgHeight = DevIL.ilGetInteger(DevIL.IL_IMAGE_HEIGHT);
                var rect = new System.Drawing.Rectangle(0, 0, ImgWidth, ImgHeight);

                // Convert the DevIL image to a pixel byte array to copy into Bitmap
                DevIL.ilConvertImage(DevIL.IL_BGRA, DevIL.IL_UNSIGNED_BYTE);

                // Create a Bitmap to copy the image into, and prepare it to get data
                bmp = new System.Drawing.Bitmap(ImgWidth, ImgHeight);
                var bmd = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                // Copy the pixel byte array from the DevIL image to the Bitmap
                DevIL.ilCopyPixels(0, 0, 0,
                  DevIL.ilGetInteger(DevIL.IL_IMAGE_WIDTH),
                  DevIL.ilGetInteger(DevIL.IL_IMAGE_HEIGHT),
                  1, DevIL.IL_BGRA, DevIL.IL_UNSIGNED_BYTE,
                  bmd.Scan0);

                // Clean up and return Bitmap
                DevIL.ilDeleteImages(1, ref img_name);
                bmp.UnlockBits(bmd);

                ddsStream.Close();
                ddsStream.Dispose();
            }
            
            MemoryStream stream;

            try
            {
                stream = new MemoryStream();
                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                bmp.Dispose();
            }
            catch
            {
                return null;
            }

            var result = new BitmapImage();

            result.BeginInit();
            result.StreamSource = stream;
            result.EndInit();
            
            Bitmaps[bitmapTag] = result;
            return result;
        }

        private Dictionary<TagInstance, string> GetTagNames(EngineVersion version)
        {
            FileInfo csvFile = null;

            if (VersionDetection.Compare(version, EngineVersion.V12_1_700123_cert_ms30_oct19) >= 0)
                csvFile = new FileInfo("cache\\V12_1_700123\\tagnames.csv");
            else if (VersionDetection.Compare(version, EngineVersion.V11_1_498295_Live) >= 0)
                csvFile = new FileInfo("cache\\V11_1_498295\\tagnames.csv");
            else
                csvFile = new FileInfo("cache\\V1_106708\\tagnames.csv");

            var result = new Dictionary<TagInstance, string>();

            using (var streamReader = new StreamReader(csvFile.OpenRead()))
            {
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine().Split(',');
                    int tagIndex;
                    if (!int.TryParse(line[0].Replace("0x", ""), NumberStyles.HexNumber, null, out tagIndex))
                        continue;
                    if (TagCache.Tags[tagIndex] == null)
                        continue;
                    result[TagCache.Tags[tagIndex]] = line[1];
                }
            }

            return result;
        }

        private void LoadTagDependencies(int index, ref Dictionary<int, TagInstance> tags)
        {
            var queue = new List<int> { index };

            while (queue.Count != 0)
            {
                var nextQueue = new List<int>();

                foreach (var entry in queue)
                {
                    if (!tags.ContainsKey(entry))
                    {
                        tags[entry] = TagCache.Tags[entry];
                        foreach (var dependency in tags[entry].Dependencies)
                            if (!nextQueue.Contains(dependency))
                                nextQueue.Add(dependency);
                    }
                }

                queue = nextQueue;
            }
        }
    }
}
