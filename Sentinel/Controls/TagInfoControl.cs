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
    public partial class TagInfoControl : UserControl
    {
        public TagInfoControl()
        {
            InitializeComponent();
        }

        public TagInfoControl(string tagIndexText, string tagOffsetText, string tagSizeText)
        {
            InitializeComponent();
            TagIndexText = tagIndexText;
            TagOffsetText = tagOffsetText;
            TagSizeText = tagSizeText;
        }

        public string TagIndexText
        {
            get { return tagIndexLabel.Text; }
            set { tagIndexLabel.Text = value; }
        }

        public string TagOffsetText
        {
            get { return tagOffsetLabel.Text; }
            set { tagOffsetLabel.Text = value; }
        }

        public string TagSizeText
        {
            get { return tagSizeLabel.Text; }
            set { tagSizeLabel.Text = value; }
        }
    }
}
