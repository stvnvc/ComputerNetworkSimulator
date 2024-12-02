using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Ruter : Uredjaj
    {
        

        public int MaksBrzPrenosaPodataka { get; set; }

        public int BrojLANPrikljucaka { get; set; }

        public TipVrstaRutera VrstaRutera { get; set; }

        public Ruter() { }

        public Ruter(string serijskiBroj, int maksBrzPrenosaPodataka, int brojLANPrikljucaka, TipVrstaRutera vrstaRutera) 
            : base(serijskiBroj)
        {
            MaksBrzPrenosaPodataka = maksBrzPrenosaPodataka;
            BrojLANPrikljucaka = brojLANPrikljucaka;
            VrstaRutera = vrstaRutera;
        }

        public override string ToString()
        {
            return "\nRuter:" + base.ToString() + 
                $"\nBrzina: {MaksBrzPrenosaPodataka} Mbps" +
                $"\nLAN priključci: {BrojLANPrikljucaka}" + 
                $"\nTip: {VrstaRutera}";
        }
    }
}
