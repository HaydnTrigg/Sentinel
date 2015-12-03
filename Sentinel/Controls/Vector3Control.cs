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
            Value = value == null ? new Vector3() : (Vector3)value;
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
            set { nameLabel.Text = value; }
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
    }
}
