using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotatnikPluginAPI;

namespace WtyczkaCzasu
{
    public class Czas
    {
        [PozycjaMenu("Wstaw godzinę", "Czas", ToolTip ="Wstawia aktualną godzinę z minutami")]
        public static string WstawGodzine(string zaznaczenie)
        {
            return DateTime.Now.ToString("HH:mm");
        }
        [PozycjaMenu("Wstaw długą datę", "Czas", ToolTip = "np. niedziela, 5 maja 2020")]
        public static string WstawDate(string zaznaczenie)
        {
            return DateTime.Now.ToString("dddd, dd MMMM yyyy");
        }
    }
}
