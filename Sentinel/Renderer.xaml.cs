using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;
using System.Windows.Threading;
using System.Runtime.InteropServices;

namespace Sentinel
{
    /// <summary>
    /// Interaction logic for Renderer.xaml
    /// </summary>
    public partial class Renderer : UserControl
    {
        private const double RAD_089 = 1.5706217940;
        private const double RAD_090 = 1.5707963268;
        private const double RAD_360 = 6.2831853072;

        private DispatcherTimer Timer = new DispatcherTimer();
        private Point LastPosition = new Point();
        private double Yaw;
        private double Pitch;
        private double ForwardAmount;
        private double BackwardAmount;
        private double LeftAmount;
        private double RightAmount;
        private double UpAmount;
        private double DownAmount;
        private double Speed1 = 0.1;
        private double Speed2 = 0.1;

        /// <summary>
        /// The sensitivity of the mouse's effect on camera rotation.
        /// </summary>
        public double LookSensitivity { get; set; } = 100.0;

        /// <summary>
        /// The viewport of the renderer.
        /// </summary>
        public Viewport3D Viewport => viewport;

        /// <summary>
        /// States if the mouse is current pressed down in the renderer.
        /// </summary>
        public bool MiddleButtonDown { get; private set; } = false;

        /// <summary>
        /// The movement speed of the camera.
        /// </summary>
        public double CameraSpeed { get; set; } = 0.015;

        /// <summary>
        /// The maximum movement speed of the camera.
        /// </summary>
        public double MaxCameraSpeed { get; set; } = 1.5;

        /// <summary>
        /// The minimum position of the camera
        /// </summary>
        public Point3D MinPosition { get; set; } = new Point3D(-500, -500, -500);

        /// <summary>
        /// The maximum position of the camera.
        /// </summary>
        public Point3D MaxPosition { get; set; } = new Point3D(500, 500, 500);

        /// <summary>
        /// The far view plane of the camera.
        /// </summary>
        public double FarPlane
        {
            get { return ((PerspectiveCamera)viewport.Camera).FarPlaneDistance; }
            set { ((PerspectiveCamera)viewport.Camera).FarPlaneDistance = value; }
        }

        /// <summary>
        /// The minimum far view plane of the camera.
        /// </summary>
        public double FarPlaneMin { get; set; } = 200;

        /// <summary>
        /// The maximum far view plane of the camera.
        /// </summary>
        public double FarPlaneMax { get; set; } = 5000;

        /// <summary>
        /// The running state of the renderer.
        /// </summary>
        public bool Running => Timer.IsEnabled;

        /// <summary>
        /// Initializes a new <see cref="Renderer"/> instance.
        /// </summary>
        public Renderer()
        {
            InitializeComponent();
        }

        private void Renderer_Loaded(object sender, RoutedEventArgs e)
        {
            Viewport.Children.Clear();
            NormalizeCamera();
            Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var CursorPos = new System.Drawing.Point();
            GetCursorPos(out CursorPos);

            var point2 = new System.Windows.Point(CursorPos.X, CursorPos.Y);

            if (base.IsFocused)
                UpdateCameraPosition();

            UpdateCameraDirection(point2);
        }

        private void Renderer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            base.Focus();
            if (e.MiddleButton == MouseButtonState.Pressed)
                MiddleButtonDown = true;
        }

        private void Renderer_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.MiddleButton == MouseButtonState.Released)
                MiddleButtonDown = false;
        }

        private void Renderer_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
                CameraSpeed = Math.Ceiling(CameraSpeed * 1050) / 1000;
            else
                CameraSpeed = Math.Floor(CameraSpeed * 0950) / 1000;

            if (CameraSpeed < 0.001)
                CameraSpeed = 0.001;

            if (CameraSpeed > MaxCameraSpeed)
                CameraSpeed = MaxCameraSpeed;
        }

        /// <summary>
        /// Refreshes the viewport and starts the <see cref="Renderer"/>.
        /// </summary>
        public void Start()
        {
            Refresh();
            Timer.Start();
        }

        /// <summary>
        /// Stops the renderer.
        /// </summary>
        /// <param name="Message"></param>
        public void Stop(string Message)
        {
            Timer.Stop();
            Viewport.Children.Clear();
            StatsLabel.Content = Message;
            Refresh();
        }

        /// <summary>
        /// Refreshes the renderer.
        /// </summary>
        public void Refresh() =>
            Dispatcher.Invoke(DispatcherPriority.Render, (Action)delegate { });

        /// <summary>
        /// Normalizes the look direction of a camera.
        /// </summary>
        /// <param name="Camera">The camera to normalizes the look direction of.</param>
        private void NormalizeDirection(PerspectiveCamera Camera)
        {
            var length = Camera.LookDirection.Length;

            Camera.LookDirection = new Vector3D(
                Camera.LookDirection.X / length,
                Camera.LookDirection.Y / length,
                Camera.LookDirection.Z / length);
        }

        /// <summary>
        /// Normalizes the position and look direction of the renderer's camera.
        /// </summary>
        public void NormalizeCamera()
        {
            var camera = (PerspectiveCamera)viewport.Camera;
            NormalizeDirection(camera);

            Yaw = Math.Atan2(camera.LookDirection.X, camera.LookDirection.Z);
            Pitch = Math.Atan(camera.LookDirection.Y);
        }

        /// <summary>
        /// Tranlates the position and look direction of the renderer's camera.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="lookDirection"></param>
        public void TranslateCamera(Point3D position, Vector3D lookDirection)
        {
            LastPosition = new Point();
            var camera = (PerspectiveCamera)viewport.Camera;
            camera.Position = position;
            camera.LookDirection = lookDirection;
            NormalizeCamera();
        }

        private void SetDebugInfo(PerspectiveCamera Camera)
        {
            StatsLabel.Content = string.Format(
                "{0,6:0.00}\x00b0, {1,6:0.00}\x00b0 X:{2:0.00} Y:{3:0.00} Z:{4:0.00} FOV: {5:0}, FPD: {6:0}, Speed: {7:0}, Sensitivity: {8:0}",
                (360.0 * Yaw) / RAD_360,
                (360.0 * Pitch) / RAD_360,
                Camera.Position.X,
                Camera.Position.Y,
                Camera.Position.Z,
                Camera.FieldOfView,
                Camera.FarPlaneDistance,
                CameraSpeed * 1000,
                LookSensitivity);
        }

        private void UpdateCameraPosition()
        {
            var camera = (PerspectiveCamera)viewport.Camera;
            NormalizeDirection(camera);
            
            #region Set FOV
            if (CheckKeyState(System.Windows.Forms.Keys.NumPad6))
                camera.FieldOfView += camera.FieldOfView / 100.0;
            if (CheckKeyState(System.Windows.Forms.Keys.NumPad4))
                camera.FieldOfView -= camera.FieldOfView / 100.0;
            camera.FieldOfView = ClipValue(camera.FieldOfView, 40, 120);
            #endregion

            #region Set FPD
            if (CheckKeyState(System.Windows.Forms.Keys.NumPad8))
                camera.FarPlaneDistance *= 1.01;
            if (CheckKeyState(System.Windows.Forms.Keys.NumPad2))
                camera.FarPlaneDistance *= 0.99;
            camera.FarPlaneDistance = ClipValue(camera.FarPlaneDistance, FarPlaneMin, FarPlaneMax);
            #endregion

            #region Check WASD
            if (!CheckKeyState(System.Windows.Forms.Keys.W))
            {
                if (ForwardAmount > 0.0)
                    ForwardAmount -= CameraSpeed * Speed2;
                else
                    ForwardAmount = 0.0;
            }
            else if (ForwardAmount < CameraSpeed)
                ForwardAmount += CameraSpeed * Speed1;
            else
                ForwardAmount = CameraSpeed;

            if (ForwardAmount != 0.0)
                camera.Position = new Point3D(camera.Position.X + (camera.LookDirection.X * ForwardAmount), camera.Position.Y + (camera.LookDirection.Y * ForwardAmount), camera.Position.Z + (camera.LookDirection.Z * ForwardAmount));

            if (!CheckKeyState(System.Windows.Forms.Keys.A))
            {
                if (LeftAmount > 0.0)
                    LeftAmount -= CameraSpeed * Speed2;
                else
                    LeftAmount = 0.0;
            }
            else if (LeftAmount < CameraSpeed)
                LeftAmount += CameraSpeed * Speed1;
            else
                LeftAmount = CameraSpeed;

            if (LeftAmount != 0.0)
                camera.Position = new Point3D(camera.Position.X - (Math.Sin(Yaw + RAD_090) * LeftAmount), camera.Position.Y - (Math.Cos(Yaw + RAD_090) * LeftAmount), camera.Position.Z);

            if (!CheckKeyState(System.Windows.Forms.Keys.S))
            {
                if (BackwardAmount > 0.0)
                    BackwardAmount -= CameraSpeed * Speed2;
                else
                    BackwardAmount = 0.0;
            }
            else if (BackwardAmount < CameraSpeed)
                BackwardAmount += CameraSpeed * Speed1;
            else
                BackwardAmount = CameraSpeed;

            if (BackwardAmount != 0.0)
                camera.Position = new Point3D(camera.Position.X - (camera.LookDirection.X * BackwardAmount), camera.Position.Y - (camera.LookDirection.Y * BackwardAmount), camera.Position.Z - (camera.LookDirection.Z * BackwardAmount));

            if (!CheckKeyState(System.Windows.Forms.Keys.D))
            {
                if (RightAmount > 0.0)
                    RightAmount -= CameraSpeed * Speed2;
                else
                    RightAmount = 0.0;
            }
            else if (RightAmount < CameraSpeed)
                RightAmount += CameraSpeed * Speed1;
            else
                RightAmount = CameraSpeed;
            if (RightAmount != 0.0)
                camera.Position = new Point3D(camera.Position.X + (Math.Sin(Yaw + RAD_090) * RightAmount), camera.Position.Y + (Math.Cos(Yaw + RAD_090) * RightAmount), camera.Position.Z);
            #endregion

            #region Check RF
            if (!CheckKeyState(System.Windows.Forms.Keys.R))
            {
                if (UpAmount > 0.0)
                    UpAmount -= CameraSpeed * Speed2;
                else
                    UpAmount = 0.0;
            }
            else if (UpAmount < CameraSpeed)
                UpAmount += CameraSpeed * Speed1;
            else
                UpAmount = CameraSpeed;
            if (UpAmount != 0.0)
            {
                var vectord = Vector3D.CrossProduct(camera.LookDirection, Vector3D.CrossProduct(camera.LookDirection, camera.UpDirection));
                vectord.Normalize();
                camera.Position = new Point3D(camera.Position.X - (vectord.X * UpAmount), camera.Position.Y - (vectord.Y * UpAmount), camera.Position.Z - (vectord.Z * UpAmount));
            }
            
            if (!CheckKeyState(System.Windows.Forms.Keys.F))
            {
                if (DownAmount > 0.0)
                    DownAmount -= CameraSpeed * Speed2;
                else
                    DownAmount = 0.0;
            }
            else if (DownAmount < CameraSpeed)
                DownAmount += CameraSpeed * Speed1;
            else
                DownAmount = CameraSpeed;

            if (DownAmount != 0.0)
            {
                var vectord2 = Vector3D.CrossProduct(camera.LookDirection, Vector3D.CrossProduct(camera.LookDirection, camera.UpDirection));
                vectord2.Normalize();
                camera.Position = new Point3D(camera.Position.X + (vectord2.X * DownAmount), camera.Position.Y + (vectord2.Y * DownAmount), camera.Position.Z + (vectord2.Z * DownAmount));
            }
            #endregion

            #region Check +/-
            if (CheckKeyState(System.Windows.Forms.Keys.Oemplus))
                LookSensitivity = Math.Min(LookSensitivity + 0.01, 100.0);
            if (CheckKeyState(System.Windows.Forms.Keys.OemMinus))
                LookSensitivity = Math.Max(LookSensitivity - 0.01, 1.0);
            #endregion

            camera.Position = new Point3D(
                ClipValue(camera.Position.X, MinPosition.X, MaxPosition.X),
                ClipValue(camera.Position.Y, MinPosition.Y, MaxPosition.Y),
                ClipValue(camera.Position.Z, MinPosition.Z, MaxPosition.Z));

            SetDebugInfo(camera);
        }

        private void UpdateCameraDirection(System.Windows.Point point)
        {
            var camera = (PerspectiveCamera)viewport.Camera;
            var locationFromWindow = TranslatePoint(new Point(0, 0), this);
            var locationFromScreen = PointToScreen(locationFromWindow);

            if (MiddleButtonDown)
            {
                if (point.X < locationFromScreen.X + 1)
                    SetCursorPos((int)(locationFromScreen.X + base.ActualWidth - 2), (int)point.Y);
                else if (point.X > locationFromScreen.X + base.ActualWidth - 1)
                    SetCursorPos((int)(locationFromScreen.X + 2), (int)point.Y);

                if (point.Y < locationFromScreen.Y + 1)
                    SetCursorPos((int)point.X, (int)(locationFromScreen.Y + base.ActualHeight - 2));
                else if (point.Y > locationFromScreen.Y + base.ActualHeight - 1)
                    SetCursorPos((int)point.X, (int)(locationFromScreen.Y + 2));

                if (point.X < locationFromScreen.X + 1
                    || point.X > locationFromScreen.X + base.ActualWidth - 1
                    || point.Y < locationFromScreen.Y + 1
                    || point.Y > locationFromScreen.Y + base.ActualHeight - 1)
                {
                    var cursorPos = new System.Drawing.Point();
                    GetCursorPos(out cursorPos);
                    point = new System.Windows.Point(cursorPos.X, cursorPos.Y);
                    LastPosition = point;
                }

                if (LastPosition.X > point.X)
                    Yaw -= (((((LastPosition.X - point.X) * RAD_360) / 54321.0) * camera.FieldOfView) * (LookSensitivity * 0.01));
                else if (LastPosition.X < point.X)
                    Yaw += (((((point.X - LastPosition.X) * RAD_360) / 54321.0) * camera.FieldOfView) * (LookSensitivity * 0.01));
                if (LastPosition.Y > point.Y)
                    Pitch += (((((LastPosition.Y - point.Y) * RAD_360) / 54321.0) * camera.FieldOfView) * (LookSensitivity * 0.01));
                else if (LastPosition.Y < point.Y)
                    Pitch -= (((((point.Y - LastPosition.Y) * RAD_360) / 54321.0) * camera.FieldOfView) * (LookSensitivity * 0.01));
            }

            Yaw %= RAD_360;
            Pitch = ClipValue(Pitch, -RAD_089, RAD_089);

            SetDebugInfo(camera);
            camera.LookDirection = new Vector3D((camera.Position.X + Math.Sin(Yaw)) - camera.Position.X, (camera.Position.Y + Math.Cos(Yaw)) - camera.Position.Y, (camera.Position.Z + Math.Tan(Pitch)) - camera.Position.Z);
            LastPosition = point;
        }

        private double ClipValue(double value, double min, double max) =>
            Math.Min(Math.Max(min, value), max);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern short GetAsyncKeyState(int KeyID);
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out System.Drawing.Point Point);
        [DllImport("user32.dll")]
        private static extern int SetCursorPos(int X, int Y);

        private static bool CheckKeyState(System.Windows.Forms.Keys keys) =>
            ((GetAsyncKeyState((int)keys) & 32768) != 0);
    }
}
