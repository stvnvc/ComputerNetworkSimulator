using Domain.Enums;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class RuterMenadzer
    {
        private readonly IAplikativniServis _appService;

        public RuterMenadzer(IAplikativniServis appService)
        {
            _appService = appService;
        }

        public void DodajNovi()
        {
            try
            {
                Console.WriteLine("\n --- Unos novog rutera ---");
                var ruter = new Ruter();
                Console.Write("Serijski broj: ");
                ruter.SerijskiBrojProizvodjaca = Console.ReadLine();
                Console.Write("Maksimalna brzina prenosa (Mbps): ");
                ruter.MaksBrzPrenosaPodataka = int.Parse(Console.ReadLine());
                Console.Write("Broj LAN prikljucaka: ");
                ruter.BrojLANPrikljucaka = int.Parse(Console.ReadLine());
                Console.Write("Vrsta rutera(0 za Bezicni, 1 za obicni): ");
                ruter.VrstaRutera = (TipVrstaRutera)int.Parse(Console.ReadLine());
                ruter.BrojPrimljenihPaketa = 0;

                _appService.DodajRuter(ruter);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ruter uspesno dodat");
                Console.ResetColor();

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Greska pri unosu: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}
