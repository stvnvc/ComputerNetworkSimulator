using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRasporedjivacOpterecenja
    {
        //Rasporedjuje prosledjene pakete na dostupne rutere
        void Rasporedi(IEnumerable<MrezniPaket> paketi, IEnumerable<Ruter> ruteri);
    }
}
