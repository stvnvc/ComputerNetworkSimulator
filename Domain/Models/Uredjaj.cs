using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public abstract class Uredjaj
    {
        public string SerijskiBrojProizvodjaca { get; set; } = string.Empty;

        protected Uredjaj() { }
        protected Uredjaj(string serijskiBrojProizvodjaca)
        {
            SerijskiBrojProizvodjaca = serijskiBrojProizvodjaca;
        }

        public override string? ToString()
        {
            return $"Serijski broj uredjaja: " + base.ToString();
        }
    }
}
