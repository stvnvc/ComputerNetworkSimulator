using Domain.Interfaces;
using Domain.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class SimulacijaMenadzer
    {
        private readonly IAplikativniServis _appService;
        private readonly IServiceProvider _serviceProvider;
        private readonly MrezniPaketMenadzer _paketMenadzer;

        public SimulacijaMenadzer(IAplikativniServis appService, IServiceProvider serviceProvider, MrezniPaketMenadzer paketMenadzer)
        {
            _appService = appService;
            _serviceProvider = serviceProvider;
            _paketMenadzer = paketMenadzer;
        }

        public void Pokreni()
        {
            try
            {
                List<MrezniPaket> paketiZaSlanje = _paketMenadzer.KreirajPaketeOdKorisnika();

                if (paketiZaSlanje.Count == 0)
                {
                    Console.WriteLine("Nema paketa za slanje");
                    return;
                }

                Console.WriteLine("Izaberite algoritam (1 za nasumicni, 2 za balansirani): ");
                string algoriatm = Console.ReadLine();

                IRasporedjivacOpterecenja rasporedjivac;
                if(algoriatm == "1")
                {
                    rasporedjivac = (IRasporedjivacOpterecenja)_serviceProvider.GetService(typeof(Services.NasumicniRasporedjivac));
                }else if (algoriatm == "2")
                {
                    rasporedjivac = (IRasporedjivacOpterecenja)_serviceProvider.GetService(typeof(Services.BalansiraniRasporedjivac));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nepoznat algoritam.");
                    Console.ResetColor();
                    return;
                }
                _appService.PokreniSlanjePaketa(paketiZaSlanje, rasporedjivac);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Simulacija je uspesno izvrsena. ");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Greska tokom simulacije: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}
