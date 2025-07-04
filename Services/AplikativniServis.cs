using Domain.Interfaces;
using Domain.Models;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AplikativniServis : IAplikativniServis
    {
        //Centralna logika aplikacije
        private readonly List<Racunar> _racunari = new List<Racunar>();

        private readonly List<Ruter> _ruteri = new List<Ruter>();

        private readonly DNSServer _dnsServer;

        private readonly IDnsServerRepozitorijum _dnsRepozitorijum;

        public AplikativniServis(IDnsServerRepozitorijum dnsRepozitorijum)
        {
            _dnsRepozitorijum = dnsRepozitorijum ?? throw new ArgumentNullException(nameof(dnsRepozitorijum));
            _dnsServer = DNSServer.Instanca;
        }

        public void DodajRacunar(Racunar racunar)
        {
            if (racunar != null && !_racunari.Any(r => r.SerijskiBrojProizvodjaca == racunar.SerijskiBrojProizvodjaca))
            {
                _racunari.Add(racunar);
            }   
         
        }

        public void DodajRuter(Ruter ruter)
        {
            if (ruter != null && !_ruteri.Any(r => r.SerijskiBrojProizvodjaca == ruter.SerijskiBrojProizvodjaca))
            {
                _ruteri.Add(ruter);
            }

        }

        public IEnumerable<Racunar> VratiSveRacunare()
        {
            return _racunari;
        }

        public IEnumerable<Ruter> VratiSveRutere()
        {
            return _ruteri; 
        }

        public bool ObrisiRacunar(string serijskiBroj)
        {
            var racunarZaBrisanje = _racunari.FirstOrDefault(r => r.SerijskiBrojProizvodjaca == serijskiBroj);
            if (racunarZaBrisanje != null) 
            {
                _racunari.Remove(racunarZaBrisanje);
                return true;
            }
            return false;


       }

        public void PokreniSlanjePaketa(List<MrezniPaket> paketiZaSlanje, IRasporedjivacOpterecenja rasporedjivac)
        {
            if (paketiZaSlanje == null || !paketiZaSlanje.Any()) return;
            if (!_ruteri.Any())
            {
                throw new InvalidOperationException("Greska: Nema rutera u mrezi za slanje paketa");
            }
            if(rasporedjivac == null)
            {
                throw new ArgumentNullException(nameof(rasporedjivac), "Strategija rasporedjivanja nije prosledjen");
            }

            rasporedjivac.Rasporedi(paketiZaSlanje, _ruteri);

            foreach(var paket in paketiZaSlanje)
            {
                paket.VremePrijema = DateTime.Now;
                _dnsServer.PrimljeniPaketi.Add(paket);
                _dnsRepozitorijum.SacuvajEvidenciju(paket);
            }

        }
        
        public string PrikaziIliSacuvajEvidenciju(IEvidencijaLogger logger)
        {
            return logger.ObradiEvidenciju(_dnsServer.PrimljeniPaketi);
        }
        

    }
}
