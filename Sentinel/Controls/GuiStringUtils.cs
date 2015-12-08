using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentinel.Controls
{
    public static class GuiStringUtils
    {
        // TODO: fix this ugly piece of death hack
        public static string GetDisplayName(string name)
        {
            var result = "";
            var initialWord = true;

            for (var i = 0; i < name.Length; i++)
            {
                if (initialWord && Char.IsUpper(name[i]))
                {
                    result += name[i];
                    initialWord = false;
                    continue;
                }

                if (!Char.IsLetter(name[i]))
                {
                    result += ' ';
                    do
                    {
                        result += name[i++];
                    } while (i < name.Length && !Char.IsLetter(name[i]));
                }

                if (i >= name.Length)
                    break;

                if (Char.IsUpper(name[i]))
                {
                    result += $" {name[i]}";
                    continue;
                }

                result += name[i];
            }

            return result;
        }
    }
}
