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
        public NumberControl()
        {
            InitializeComponent();
        }

        public NumberControl(object owner, FieldInfo fieldInfo)
        {
            InitializeComponent();
            Owner = owner;
            Info = fieldInfo;
            ValueName = Info.Name;
            var value = Info.GetValue(Owner);
            ValueText = value == null ? "<NULL>" : value.ToString();
        }

        public object Owner { get; set; } = null;

        public FieldInfo Info { get; set; } = null;

        public string ValueName
        {
            get { return nameLabel.Text; }
            set { nameLabel.Text = value; }
        }

        public string ValueText
        {
            get { return valueBox.Text; }
            set { valueBox.Text = value; }
        }
    }
}
