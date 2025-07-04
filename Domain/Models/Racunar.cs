using Domain.Enums;

namespace Domain.Models
{
    public class Racunar
    {
        public string SerijskiBrojProizvodjaca { get; set; } = string.Empty;
        public double KapacitetRadneMemorije { get; set; } = 0;
        public double KapacitetSkladisneMemorije { get; set; } = 0;

        public TipSkladisneMemorije TipSkladisneMemorije { get; set; }

        public string LokalnaIPAdresa { get; set; } = string.Empty;

        public Racunar() { }

        public Racunar(string serijskiBrojProizvodjaca, double kapacitetRadneMemorije,
            double kapacitetSkladisneMemorije, TipSkladisneMemorije tipSkladisneMemorije, string lokalnaIPAdresa)
        {
            SerijskiBrojProizvodjaca = serijskiBrojProizvodjaca;
            KapacitetRadneMemorije = kapacitetRadneMemorije;
            KapacitetSkladisneMemorije = kapacitetSkladisneMemorije;
            TipSkladisneMemorije = tipSkladisneMemorije;
            LokalnaIPAdresa = lokalnaIPAdresa;
        }

        public override string? ToString()
        {
            return "\nRacunar: \n" +
                $"\nSerijski broj proizvodjaca: {SerijskiBrojProizvodjaca}" +
                $"\nKapaciteta radne memorije: {KapacitetRadneMemorije}\n" +
                $"Kapaciteta skladisne memorije: {KapacitetSkladisneMemorije}\n" +
                $"Tipa skladisne memorije: {TipSkladisneMemorije}\n" +
                $"Lokalna IP Adresa: {LokalnaIPAdresa}\n";
        }
    }
}
