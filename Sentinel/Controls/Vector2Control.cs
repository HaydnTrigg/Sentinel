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
    public partial class Vector2Control : UserControl
    {
        public object Owner { get; set; } = null;

        public Vector2 Value { get; set; } = new Vector2();

        public FieldInfo Info { get; set; } = null;

        public Vector2Control(object owner, FieldInfo fieldInfo)
        {
            Owner = owner;
            Info = fieldInfo;

            InitializeComponent();

            Load += Vector2Control_Load;
        }

        private void Vector2Control_Load(object sender, EventArgs e)
        {
            nameLabel.Text = Info.Name + " X:";

            var value = Info.GetValue(Owner);

            if (value == null)
            {
                value = new Vector2();
                Info.SetValue(Owner, value);
            }

            Value = (Vector2)value;

            xValueBox.Text = Value.X.ToString();
            yValueBox.Text = Value.Y.ToString();
        }

        private void xValueBox_TextChanged(object sender, EventArgs e)
        {
            var oldValue = Value;
            float xValue = 0.0f;

            if (!float.TryParse(xValueBox.Text, out xValue))
                xValueBox.Text = Value.X.ToString();
            else
                Value = new Vector2(xValue, Value.Y);

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
                Value = new Vector2(Value.X, yValue);

            if (oldValue != Value)
                Info.SetValue(Owner, Value);
        }
    }
}
