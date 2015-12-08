using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blam.Tags;
using static System.Reflection.BindingFlags;
using static System.Windows.Forms.AutoSizeMode;
using static System.Drawing.Color;

namespace Sentinel.Controls
{
    public partial class TagFieldPanel : TableLayoutPanel
    {
        public TagFieldPanel() :
            base()
        {
            SuspendLayout();

            AutoSize = true;
            AutoSizeMode = GrowAndShrink;
            BackColor = Transparent;
            RowStyles.Clear();

            ResumeLayout(false);
        }

        private IEnumerable<FieldInfo> _Fields = null;

        private TagDefinition _Definition = null;

        public TagDefinition Definition
        {
            get { return _Definition; }
            set
            {
                _Definition = value;

                if (value == null)
                    return;

                Application.DoEvents();
                BuildDefinitionLayout();
            }
        }

        public void GetValues(object value)
        {
            for (var i = 0; i < _Fields.Count(); i++)
                if (Controls[i].GetType().GetInterface(typeof(ITagFieldControl).Name) != null)
                    ((ITagFieldControl)Controls[i]).LoadValue(_Fields.ElementAt(i), value);
        }

        public void SetValues(object value)
        {
            for (var i = 0; i < _Fields.Count(); i++)
                if (Controls[i].GetType().GetInterface(typeof(ITagFieldControl).Name) != null)
                    ((ITagFieldControl)Controls[i]).SaveValue(_Fields.ElementAt(i), value);
        }

        private void BuildDefinitionLayout()
        {
            SuspendLayout();

            _Fields = _Definition.Types.Reverse<Type>() // order from base to child
                .SelectMany(type => type.GetFields(Instance | Public | DeclaredOnly));

            var currentRow = 0;

            foreach (var field in _Fields)
            {
                var type = field.FieldType;

                Control control = null;

                if (type == typeof(byte))
                    control = new NumberControl<byte>();
                else if (type == typeof(sbyte))
                    control = new NumberControl<sbyte>();
                else if (type == typeof(short))
                    control = new NumberControl<short>();
                else if (type == typeof(ushort))
                    control = new NumberControl<ushort>();
                else if (type == typeof(int))
                    control = new NumberControl<int>();
                else if (type == typeof(uint))
                    control = new NumberControl<uint>();
                else if (type == typeof(float))
                    control = new NumberControl<float>();
                else
                {
                    var debugLabel = new Label();
                    debugLabel.Dock = DockStyle.Fill;
                    debugLabel.Text = $"<Unimplemented: {type.Name}>";
                    debugLabel.TextAlign = ContentAlignment.MiddleCenter;

                    control = debugLabel;
                }

                RowStyles.Add(new RowStyle(SizeType.AutoSize));
                Controls.Add(control, 0, currentRow++);
            }

            ResumeLayout(false);
        }
    }
}
