using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AutentifikacioniServis : IAutentifikacioniServis
    {
        private const string KorisnickoIme = "admin";
        private const string Lozinka = "password123";

        public bool Autentifikuj(string korisnickoIme, string lozinka)
        {
            return korisnickoIme == KorisnickoIme && lozinka == Lozinka;
        }
    }
}
