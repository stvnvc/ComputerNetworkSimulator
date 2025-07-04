using Domain.Interfaces;
using Domain.Models;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class TestPodaciMenadzer
    {
        private readonly IAplikativniServis _appService;

        public TestPodaciMenadzer(IAplikativniServis appService)
        {
            _appService = appService;
        }

        public void Generisi()
        {
            Console.WriteLine("\nGenerisanje test podataka ...");
            _appService.DodajRuter(new Ruter
            {
                SerijskiBrojProizvodjaca = "RT-001",
                VrstaRutera = TipVrstaRutera.BEZICNI,
                MaksBrzPrenosaPodataka = 1000,
                BrojLANPrikljucaka = 4

            });
            _appService.DodajRuter(new Ruter
            {
                SerijskiBrojProizvodjaca = "RT-002",
                VrstaRutera = TipVrstaRutera.OBICNI,
                MaksBrzPrenosaPodataka = 100,
                BrojLANPrikljucaka = 8

            });

            _appService.DodajRacunar(new Racunar
            {
                SerijskiBrojProizvodjaca = "PC-Dell-1",
                LokalnaIPAdresa = "192.168.1.10",
                KapacitetRadneMemorije = 16,
                KapacitetSkladisneMemorije = 256,
                TipSkladisneMemorije = TipSkladisneMemorije.SSD
            });
            _appService.DodajRacunar(new Racunar
            {
                SerijskiBrojProizvodjaca = "PC-HP-2",
                LokalnaIPAdresa = "192.168.1.11",
                KapacitetRadneMemorije = 12,
                KapacitetSkladisneMemorije = 1024,
                TipSkladisneMemorije = TipSkladisneMemorije.HDD
            });
            _appService.DodajRacunar(new Racunar
            {
                SerijskiBrojProizvodjaca = "PC-Lenovo-3",
                LokalnaIPAdresa = "192.168.1.10",
                KapacitetRadneMemorije = 18,
                KapacitetSkladisneMemorije = 512,
                TipSkladisneMemorije = TipSkladisneMemorije.HDD
            });
        }
    }
}
