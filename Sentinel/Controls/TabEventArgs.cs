using System;
using System.Windows.Forms;

namespace Sentinel.Controls
{
    public class TabEventArgs : EventArgs
    {
        public readonly TabPage Tab;

        public TabEventArgs(TabPage tab)
        {
            this.Tab = tab;
        }
    }
}

