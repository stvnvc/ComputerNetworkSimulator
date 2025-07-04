using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAutentifikacioniServis
    {
        //Proverava validnost kredencijala
        bool Autentifikuj(string korisnickoIme, string Lozinka);

    }
}
