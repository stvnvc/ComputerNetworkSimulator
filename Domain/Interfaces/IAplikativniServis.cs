using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAplikativniServis
    {
        void DodajRacunar(Racunar racunar);

        void DodajRuter(Ruter ruter);

        bool ObrisiRacunar(string serijskiBroj);

        void PokreniSlanjePaketa(List<MrezniPaket> paketi, IRasporedjivacOpterecenja rasporedjivac);

        string PrikaziIliSacuvajEvidenciju(IEvidencijaLogger logger);

        IEnumerable<Racunar> VratiSveRacunare();

        IEnumerable<Ruter> VratiSveRutere();


    }
}
