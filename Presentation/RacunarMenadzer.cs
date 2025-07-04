using Domain.Enums;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class RacunarMenadzer
    {

        private readonly IAplikativniServis _appService;

        public RacunarMenadzer(IAplikativniServis appService)
        {
            _appService = appService;
        }

        public void DodajNovi()
        {
            try
            {
                Console.WriteLine("\n-- Unos novog računara --");
                var racunar = new Racunar();
                Console.Write("Serijski broj: ");
                racunar.SerijskiBrojProizvodjaca = Console.ReadLine();
                Console.Write("Lokalna IP adresa: ");
                racunar.LokalnaIPAdresa = Console.ReadLine();
                Console.Write("Kapacitet RAM (GB): ");
                racunar.KapacitetRadneMemorije = int.Parse(Console.ReadLine());
                Console.Write("Kapacitet diska (GB): ");
                racunar.KapacitetSkladisneMemorije = int.Parse(Console.ReadLine());
                Console.WriteLine("Tip skladista: (0 za SSD, 1 za HDD)");
                racunar.TipSkladisneMemorije = (TipSkladisneMemorije)int.Parse(Console.ReadLine());

                _appService.DodajRacunar(racunar);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Racunar uspesno dodat.");
                Console.ResetColor();
            }
            catch (Exception ex)
            { 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Greska pri unosu: {ex.Message}");
                Console.ResetColor();
            }
        }

        public void ObrisiPostojeci()
        {
            Console.Write("\nUnesite serijski broj racunara za brisanje: ");
            string serijskiBroj = Console.ReadLine();
            if (_appService.ObrisiRacunar(serijskiBroj))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Racunar uspesno obrisan.");
                Console.ResetColor();
            }else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Racunar sa unetim serijskim broj nije pronadjen.");
                Console.ResetColor();
            }
        }
    }
}
