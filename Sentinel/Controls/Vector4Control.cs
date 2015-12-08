using System;
using System.Reflection;
using System.Windows.Forms;
using Blam.Common;

namespace Sentinel.Controls
{
    public partial class Vector4Control : UserControl
    {
        public object Owner { get; set; } = null;

        public Vector4 Value { get; set; } = new Vector4();

        public FieldInfo Info { get; set; } = null;

        public Vector4Control(object owner, FieldInfo fieldInfo)
        {
            Owner = owner;
            Info = fieldInfo;

            InitializeComponent();

            Load += Vector4Control_Load;
        }

        private void Vector4Control_Load(object sender, EventArgs e)
        {
            nameLabel.Text = Info.Name + " X:";
            
            var value = Info.GetValue(Owner);

            if (value == null)
            {
                value = new Vector4();
                Info.SetValue(Owner, value);
            }

            Value = (Vector4)value;

            xValueBox.Text = Value.X.ToString();
            yValueBox.Text = Value.Y.ToString();
            zValueBox.Text = Value.Z.ToString();
            wValueBox.Text = Value.W.ToString();
        }

        private void xValueBox_TextChanged(object sender, EventArgs e)
        {
            var oldValue = Value;
            float xValue = 0.0f;

            if (!float.TryParse(xValueBox.Text, out xValue))
                xValueBox.Text = Value.X.ToString();
            else
                Value = new Vector4(xValue, Value.Y, Value.Z, Value.W);

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
                Value = new Vector4(Value.X, yValue, Value.Z, Value.W);

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
                Value = new Vector4(Value.X, Value.Y, zValue, Value.W);

            if (oldValue != Value)
                Info.SetValue(Owner, Value);
        }

        private void wValueBox_TextChanged(object sender, EventArgs e)
        {
            var oldValue = Value;
            float wValue = 0.0f;

            if (!float.TryParse(wValueBox.Text, out wValue))
                wValueBox.Text = Value.W.ToString();
            else
                Value = new Vector4(Value.X, Value.Y, Value.Z, wValue);

            if (oldValue != Value)
                Info.SetValue(Owner, Value);
        }
    }
}
