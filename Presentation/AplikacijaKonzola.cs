using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class AplikacijaKonzola
    {
        private readonly Autentifikacija _autentifikacija;
        private readonly MeniMenadzer _meniMenadzer;

        public AplikacijaKonzola(Autentifikacija autentifikacija, MeniMenadzer meniMenadzer)
        {
            _autentifikacija = autentifikacija;
            _meniMenadzer = meniMenadzer;
        }
        public void Pokreni()
        {
            if (_autentifikacija.IzvrsiAutentifikaciju())
            {
                _meniMenadzer.PokreniGlavnuPetlju();
            }
            Console.WriteLine("Dovidjednja!");

        }
    }
}
