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
        public Vector3Control()
        {
            InitializeComponent();
        }

        public Vector3Control(object owner, FieldInfo fieldInfo)
        {
            InitializeComponent();
            Owner = owner;
            Info = fieldInfo;
            ValueName = Info.Name;

            var value = Info.GetValue(Owner);
            if (value == null)
            {
                value = new Vector3();
                Info.SetValue(owner, value);
            }

            Value = (Vector3)value;
            XValueText = Value.X.ToString();
            YValueText = Value.Y.ToString();
            ZValueText = Value.Z.ToString();
        }

        public object Owner { get; set; } = null;

        public Vector3 Value { get; set; } = new Vector3();

        public FieldInfo Info { get; set; } = null;

        public string ValueName
        {
            get { return nameLabel.Text; }
            set { nameLabel.Text = value + " X:"; }
        }

        public string XValueText
        {
            get { return xValueBox.Text; }
            set { xValueBox.Text = value; }
        }

        public string YValueText
        {
            get { return yValueBox.Text; }
            set { yValueBox.Text = value; }
        }

        public string ZValueText
        {
            get { return zValueBox.Text; }
            set { zValueBox.Text = value; }
        }

        private void xValueBox_TextChanged(object sender, EventArgs e)
        {
            var oldValue = Value;
            float xValue = 0.0f;

            if (!float.TryParse(YValueText, out xValue))
                YValueText = Value.Y.ToString();
            else
                Value = new Vector3(xValue, Value.Y, Value.Z);

            if (oldValue != Value)
                Info.SetValue(Owner, Value);
        }

        private void yValueBox_TextChanged(object sender, EventArgs e)
        {
            var oldValue = Value;
            float yValue = 0.0f;

            if (!float.TryParse(YValueText, out yValue))
                YValueText = Value.Y.ToString();
            else
                Value = new Vector3(Value.X, yValue, Value.Z);

            if (oldValue != Value)
                Info.SetValue(Owner, Value);
        }

        private void zValueBox_TextChanged(object sender, EventArgs e)
        {
            var oldValue = Value;
            float zValue = 0.0f;

            if (!float.TryParse(ZValueText, out zValue))
                ZValueText = Value.Z.ToString();
            else
                Value = new Vector3(Value.X, Value.Y, zValue);

            if (oldValue != Value)
                Info.SetValue(Owner, Value);
        }
    }
}
