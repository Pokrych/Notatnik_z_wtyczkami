using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotatnikPluginAPI
{
    [AttributeUsage(AttributeTargets.Method)]
    public class PozycjaMenuAttribute : Attribute
    {
        public string Tekst;
        public string Grupa;
        public string ToolTip;

        public PozycjaMenuAttribute(string Tekst, string Grupa)
        {
            this.Tekst = Tekst;
            this.Grupa = Grupa;
            this.ToolTip = null;
        }

    }
}
