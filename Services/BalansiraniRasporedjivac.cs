using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BalansiraniRasporedjivac : IRasporedjivacOpterecenja
    {
        public void Rasporedi(IEnumerable<MrezniPaket> paketi, IEnumerable<Ruter> ruteri)
        {
            var listaRutera = ruteri.ToList();
            if (!listaRutera.Any()) return;

            int trenutniRuterIndex = 0;

            foreach(var paket in paketi)
            {
                var trenutniRuter = listaRutera[trenutniRuterIndex];
                trenutniRuter.BrojPrimljenihPaketa++;
                trenutniRuterIndex = (trenutniRuterIndex+1)%listaRutera.Count;
            }

        }
    }
}
