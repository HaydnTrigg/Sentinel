using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Blam.Tags;
using System.Collections;

namespace Sentinel.Controls
{
    public partial class BlockControl : UserControl
    {
        public object BlockOwner { get; set; }

        public FieldInfo BlockFieldInfo { get; set; }

        public TagDefinition BlockDefinition { get; set; }

        public IList BlockValue { get; set; }

        private bool _Toggled = false;
        public bool Toggled
        {
            get { return _Toggled; }
            set { _Toggled = value; OnToggle(); }
        }
        
        public BlockControl(object owner, FieldInfo fieldInfo, TagDefinition definition)
        {
            BlockOwner = owner;
            BlockFieldInfo = fieldInfo;
            BlockDefinition = definition;

            if (owner != null)
                BlockValue = (IList)fieldInfo.GetValue(owner);

            InitializeComponent();

            Load += BlockControl_Load;
        }

        private void BlockControl_Load(object sender, EventArgs e)
        {
            controlPanel.Location = new Point(0, headerPanel.Height + Margin.Bottom);

            if (BlockValue != null)
                for (var i = 0; i < BlockValue.Count; i++)
                    indexBox.Items.Add(i.ToString());

            object selectedIndex = null;

            if (indexBox.Items.Count != 0)
            {
                selectedIndex = BlockValue[0];
                indexBox.SelectedIndex = 0;
                Toggled = false;
            }
            else
            {
                Toggled = true;
                Enabled = false;
            }

            nameLabel.Text = BlockFieldInfo.Name;

            TagEditorControl.AddTagDefinitionControls(
                BlockDefinition,
                selectedIndex,
                new Point(),
                controlPanel);
        }

        public Panel ControlPanel => controlPanel;

        private void OnToggle()
        {
            controlPanel.Visible = !Toggled;
            toggleButton.Text = Toggled ? "+" : "-";
        }

        private void toggleButton_Click(object sender, EventArgs e)
        {
            Toggled = !Toggled;
        }
    }
}
