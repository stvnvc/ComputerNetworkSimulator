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
    public class MeniMenadzer
    {
        private readonly IAplikativniServis _appService;
        private readonly RacunarMenadzer _racunarMenadzer;
        private readonly SimulacijaMenadzer _simulacijaMenadzer;
        private readonly EvidencijaMenadzer _evidencijaMenadzer;
        private readonly RuterMenadzer _ruterMenadzer;
        private readonly TestPodaciMenadzer _testPodaciMenadzer;

        public MeniMenadzer(IAplikativniServis appService, RacunarMenadzer racunarMenadzer, SimulacijaMenadzer simulacijaMenadzer, EvidencijaMenadzer evidencijaMenadzer, RuterMenadzer ruterMenadzer, TestPodaciMenadzer testPodaciMenadzer)
        {
            _appService = appService;
            _racunarMenadzer = racunarMenadzer;
            _simulacijaMenadzer = simulacijaMenadzer;
            _evidencijaMenadzer = evidencijaMenadzer;
            _ruterMenadzer = ruterMenadzer;
            _testPodaciMenadzer = testPodaciMenadzer;
        }


        public void PokreniGlavnuPetlju()
        {
            bool running = true;
            while (running)
            {
                PrikaziMeni();
                string opcija = Console.ReadLine();

                switch (opcija)
                {
                    case "1":
                        _racunarMenadzer.DodajNovi();
                        break;
                    case "2":
                        _ruterMenadzer.DodajNovi();
                        break;
                    case "3":
                        _racunarMenadzer.ObrisiPostojeci();
                        break;
                    case "4":
                        _simulacijaMenadzer.Pokreni();
                        break;
                    case "5":
                        PrikaziStanjeMreze();
                        break;
                    case "6":
                        _evidencijaMenadzer.PrikaziNaKonzoli();
                        break;
                    case "7":
                        _evidencijaMenadzer.SacuvajUXml();
                        break;
                    case "8":
                        _testPodaciMenadzer.Generisi();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Nepoznata opcija, pokušajte ponovo.");
                        Console.ResetColor();
                        break;
                }
            }
        }

        private void PrikaziMeni()
        {
            Console.WriteLine("\n--- GLAVNI MENI ---");
            Console.WriteLine("1. Dodaj novi računar");
            Console.WriteLine("2. Dodaj novi ruter");
            Console.WriteLine("3. Obriši računar");
            Console.WriteLine("4. Pokreni slanje paketa");
            Console.WriteLine("5. Prikaži stanje mreže");
            Console.WriteLine("6. Prikaži evidenciju DNS servera na konzoli");
            Console.WriteLine("7. Sačuvaj evidenciju DNS servera u XML");
            Console.WriteLine("8. Generisi test podatke: ");
            Console.WriteLine("0. Izlaz");
            Console.Write("Izaberite opciju: ");
        }

        private void PrikaziStanjeMreze()
        {
            Console.WriteLine("\n--- TRENUTNO STANJE MREŽE ---");

            var dns = DNSServer.Instanca;
            Console.WriteLine("\nDNS Server:");
            Console.WriteLine($" IP: {dns.IPAdresaServera}, Simbolicka adresa: {dns.SimbolickaAresa}, Stanje: {dns.TipOperativnogStanja}");

            Console.WriteLine("\nRačunari:");
            var racunari = _appService.VratiSveRacunare();
            if (!racunari.Any()) Console.WriteLine("Nema računara u mreži.");
            foreach (var r in racunari)
            {
                Console.WriteLine($"- SN: {r.SerijskiBrojProizvodjaca}, IP: {r.LokalnaIPAdresa}, RAM: {r.KapacitetRadneMemorije}GB, Disk: {r.KapacitetSkladisneMemorije}GB {r.TipSkladisneMemorije}");
            }

            Console.WriteLine("\nRuteri:");
            var ruteri = _appService.VratiSveRutere();
            if (!ruteri.Any()) Console.WriteLine("Nema rutera u mreži.");
            foreach (var rt in ruteri)
            {
                Console.WriteLine($"- SN: {rt.SerijskiBrojProizvodjaca}, Vrsta: {rt.VrstaRutera}, Primljeno paketa: {rt.BrojPrimljenihPaketa}");
            }
            Console.WriteLine("---------------------------------");
        }

    }
}
