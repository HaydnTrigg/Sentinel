using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blam.Common;
using System.Reflection;

namespace Sentinel.Controls
{
    public partial class AngleControl : UserControl
    {
        public object Owner { get; set; }

        public FieldInfo Info { get; set; }

        public Angle Value { get; set; }

        public AngleControl(object owner, FieldInfo info)
        {
            Owner = owner;
            Info = info;
            Value = (Angle)info.GetValue(owner);

            InitializeComponent();

            Load += AngleControl_Load;
        }
        
        private void AngleControl_Load(object sender, EventArgs e)
        {
            nameLabel.Text = Info.Name;
            modeBox.SelectedIndex = 0;
        }

        private void modeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modeBox.SelectedIndex == 0) // Degrees
                valueBox.Text = Value.Degrees.ToString();
            else if (modeBox.SelectedIndex == 1) // Radians
                valueBox.Text = Value.Radians.ToString();
        }

        private void valueBox_TextChanged(object sender, EventArgs e)
        {
            var oldValue = Value;
            float value = 0.0f;

            if (!float.TryParse(valueBox.Text, out value))
                modeBox_SelectedIndexChanged(this, new EventArgs());
            else if (modeBox.SelectedIndex == 0)
                Value = Angle.FromDegrees(value);
            else if (modeBox.SelectedIndex == 1)
                Value = Angle.FromRadians(value);

            if (oldValue != Value)
                Info.SetValue(Owner, Value);
        }
    }
}
