using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Ruter
    {
        public string SerijskiBrojProizvodjaca { get; set; } = string.Empty;
        
        public int MaksBrzPrenosaPodataka { get; set; }
        
        public int BrojLANPrikljucaka { get; set; }
        
        public TipVrstaRutera VrstaRutera { get; set; }

        public int BrojPrimljenihPaketa { get; set; } = 0;

        public Ruter() { }

        public Ruter(string serijskiBroj, int maksBrzPrenosaPodataka, int brojLANPrikljucaka, TipVrstaRutera vrstaRutera)
        {
            SerijskiBrojProizvodjaca = serijskiBroj;
            MaksBrzPrenosaPodataka = maksBrzPrenosaPodataka;
            BrojLANPrikljucaka = brojLANPrikljucaka;
            VrstaRutera = vrstaRutera;
        }

        public override string ToString()
        {
            return "\nRuter:" + 
                $"\nSerijski Broj proizvodjaca: {SerijskiBrojProizvodjaca}"+ 
                $"\nBrzina: {MaksBrzPrenosaPodataka} Mbps" +
                $"\nLAN priključci: {BrojLANPrikljucaka}" + 
                $"\nTip: {VrstaRutera}" +
                $"\nBroj primljenih paketa: {BrojPrimljenihPaketa}";
        }
    }
}
