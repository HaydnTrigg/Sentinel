using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blam.Tags;
using System.Reflection;

namespace Sentinel.Controls
{
    public partial class NumberControl<T> : UserControl, ITagFieldControl
    {
        public NumberControl()
        {
            InitializeComponent();
        }

        public virtual void LoadValue(FieldInfo field, object owner)
        {
            Name = field.Name;
            Value = (T)field.GetValue(owner);
        }

        public virtual void SaveValue(FieldInfo field, object owner)
        {
            field.SetValue(owner, Value);
        }

        public new string Name
        {
            get { return base.Name; }
            set
            {
                base.Name = value;
                nameLabel.Text = GuiStringUtils.GetDisplayName(value);
            }
        }

        public string Help
        {
            get { return helpLabel.Text; }
            set { helpLabel.Text = value; }
        }

        private T _Value;
        public T Value
        {
            get { return _Value; }
            set
            {
                _Value = value;
                valueBox.Text = value.ToString();
            }
        }
    }
}
