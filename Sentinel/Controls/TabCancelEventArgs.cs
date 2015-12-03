using System.ComponentModel;
using System.Windows.Forms;

namespace Sentinel.Controls
{
    public class TabCancelEventArgs : CancelEventArgs
    {
        public readonly TabPage Tab;

        public TabCancelEventArgs(TabPage tab)
        {
            this.Tab = tab;
        }
    }
}

