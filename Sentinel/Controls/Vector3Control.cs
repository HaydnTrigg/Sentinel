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
using Blam.Common;

namespace Sentinel.Controls
{
    public partial class Vector3Control : UserControl
    {
        public object Owner { get; set; } = null;

        public Vector3 Value { get; set; } = new Vector3();

        public FieldInfo Info { get; set; } = null;
        
        public Vector3Control(object owner, FieldInfo fieldInfo)
        {
            Owner = owner;
            Info = fieldInfo;

            InitializeComponent();

            Load += Vector3Control_Load;
        }

        private void Vector3Control_Load(object sender, EventArgs e)
        {
            nameLabel.Text = Info.Name;

            var value = Info.GetValue(Owner);

            if (value == null)
            {
                value = new Vector3();
                Info.SetValue(Owner, value);
            }

            Value = (Vector3)value;

            xValueBox.Text = Value.X.ToString();
            yValueBox.Text = Value.Y.ToString();
            zValueBox.Text = Value.Z.ToString();
        }
        
        private void xValueBox_TextChanged(object sender, EventArgs e)
        {
            var oldValue = Value;
            float xValue = 0.0f;

            if (!float.TryParse(xValueBox.Text, out xValue))
                xValueBox.Text = Value.X.ToString();
            else
                Value = new Vector3(xValue, Value.Y, Value.Z);

            if (oldValue != Value)
                Info.SetValue(Owner, Value);
        }

        private void yValueBox_TextChanged(object sender, EventArgs e)
        {
            var oldValue = Value;
            float yValue = 0.0f;

            if (!float.TryParse(yValueBox.Text, out yValue))
                yValueBox.Text = Value.Y.ToString();
            else
                Value = new Vector3(Value.X, yValue, Value.Z);

            if (oldValue != Value)
                Info.SetValue(Owner, Value);
        }

        private void zValueBox_TextChanged(object sender, EventArgs e)
        {
            var oldValue = Value;
            float zValue = 0.0f;

            if (!float.TryParse(zValueBox.Text, out zValue))
                zValueBox.Text = Value.Z.ToString();
            else
                Value = new Vector3(Value.X, Value.Y, zValue);

            if (oldValue != Value)
                Info.SetValue(Owner, Value);
        }
    }
}
