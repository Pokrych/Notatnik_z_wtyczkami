using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotatnikPluginAPI;

namespace WtyczkaWielkosc
{
    public class Wielkosc
    {
        [PozycjaMenu("Na duże litery", "Zamień")]
        public static string DuzeLitery(string zaznaczenie)
        { 
            return zaznaczenie.ToUpper();
        }
        [PozycjaMenu("Na małe litery", "Zamień")]
        public static string MaleLitery(string zaznaczenie)
        {
            return zaznaczenie.ToLower();
        }
    }
}
