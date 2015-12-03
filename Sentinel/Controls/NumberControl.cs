using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sentinel.Controls
{
    public partial class NumberControl : UserControl
    {
        public NumberControl()
        {
            InitializeComponent();
        }

        public NumberControl(string valueName, string valueText = "")
        {
            InitializeComponent();
            ValueName = valueName;
            ValueText = valueText;
        }

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
