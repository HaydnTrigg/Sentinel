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

namespace Sentinel.Controls
{
    public partial class NumberControl : UserControl
    {
        public object Owner { get; set; }

        public FieldInfo Info { get; set; }

        public object Value { get; set; }

        public NumberControl(object owner, FieldInfo fieldInfo)
        {
            Owner = owner;
            Info = fieldInfo;

            InitializeComponent();

            Load += NumberControl_Load;
        }

        private void NumberControl_Load(object sender, EventArgs e)
        {
            nameLabel.Text = Info.Name;

            var value = Info.GetValue(Owner);

            if (value == null)
            {
                value = Activator.CreateInstance(Info.FieldType);
                Info.SetValue(Owner, value);
            }

            Value = value;
            valueBox.Text = Value.ToString();
        }

        private void valueBox_TextChanged(object sender, EventArgs e)
        {
            if (Info.FieldType == typeof(sbyte))
            {
                sbyte value;
                if (!sbyte.TryParse(valueBox.Text, out value))
                    valueBox.Text = Value.ToString();
                else
                    Value = value;
            }
            else if (Info.FieldType == typeof(byte))
            {
                byte value;
                if (!byte.TryParse(valueBox.Text, out value))
                    valueBox.Text = Value.ToString();
                else
                    Value = value;
            }
            else if (Info.FieldType == typeof(short))
            {
                short value;
                if (!short.TryParse(valueBox.Text, out value))
                    valueBox.Text = Value.ToString();
                else
                    Value = value;
            }
            else if (Info.FieldType == typeof(ushort))
            {
                ushort value;
                if (!ushort.TryParse(valueBox.Text, out value))
                    valueBox.Text = Value.ToString();
                else
                    Value = value;
            }
            else if (Info.FieldType == typeof(int))
            {
                int value;
                if (!int.TryParse(valueBox.Text, out value))
                    valueBox.Text = Value.ToString();
                else
                    Value = value;
            }
            else if (Info.FieldType == typeof(uint))
            {
                uint value;
                if (!uint.TryParse(valueBox.Text, out value))
                    valueBox.Text = Value.ToString();
                else
                    Value = value;
            }
            else if (Info.FieldType == typeof(float))
            {
                float value;
                if (!float.TryParse(valueBox.Text, out value))
                    valueBox.Text = Value.ToString();
                else
                    Value = value;
            }
            else return;

            Info.SetValue(Owner, Value);
        }
    }
}
