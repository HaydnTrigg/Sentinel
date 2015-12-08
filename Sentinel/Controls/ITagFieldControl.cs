using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sentinel.Controls
{
    public interface ITagFieldControl
    {
        void LoadValue(FieldInfo field, object owner);
        void SaveValue(FieldInfo field, object owner);
    }
}
