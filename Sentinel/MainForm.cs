using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Sentinel
{
    public partial class MainForm : Form
    {
        public Dictionary<string, TabPage> MapPages { get; set; } = new Dictionary<string, TabPage>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Halo Online Maps (*.map)|*.map";

                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                var mapInfo = new FileInfo(ofd.FileName);
                if (!mapInfo.Exists)
                    return;

                if (MapPages.ContainsKey(mapInfo.FullName))
                    return;

                var mapPage = new TabPage(mapInfo.Name);
                mapPage.Tag = mapInfo;
                mapPage.Controls.Add(new MapControl(mapInfo));
                mapPage.Controls[0].Dock = DockStyle.Fill;

                tabControl.TabPages.Add(MapPages[mapInfo.FullName] = mapPage);
                tabControl.SelectedTab = mapPage;
                SetWindowTitle();
            }
        }

        private void SetWindowTitle()
        {
            var mapControl = (MapControl)tabControl.SelectedTab.Controls[0];
            Text = string.Format("Sentinel - {0}", mapControl.MapInfo.FullName);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetWindowTitle();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.RemoveAt(tabControl.SelectedIndex);
            SetWindowTitle();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
