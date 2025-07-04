using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class NasumicniRasporedjivac : IRasporedjivacOpterecenja
    {
        private readonly Random _random = new Random();
        public void Rasporedi(IEnumerable<MrezniPaket> paketi, IEnumerable<Ruter> ruteri)
            { 
               var listaRutera = ruteri.ToList();
            if (!listaRutera.Any()) return;

            foreach (var paket in paketi)
            {
                var nasumicniRuter = listaRutera[_random.Next(listaRutera.Count)];

                nasumicniRuter.BrojPrimljenihPaketa++;
            }

            }
    }
}
