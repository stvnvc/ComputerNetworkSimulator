using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class Autentifikacija
    {
        private readonly IAutentifikacioniServis _authService;

        public Autentifikacija(IAutentifikacioniServis authService)
        {
            _authService = authService;
        }

        public bool IzvrsiAutentifikaciju()
        {
            Console.WriteLine("--- SIMULACIJA MREZE ---");
            Console.Write("Korisničko ime: ");
            string korisnickoIme = Console.ReadLine();
            Console.Write("Lozinka: ");
            string lozinka = Console.ReadLine();

            if (!_authService.Autentifikuj(korisnickoIme, lozinka))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Greška: Pogrešno korisničko ime ili lozinka.");
                Console.ResetColor();
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Uspešna prijava!");
            Console.ResetColor();
            return true;


        }
    }
}
