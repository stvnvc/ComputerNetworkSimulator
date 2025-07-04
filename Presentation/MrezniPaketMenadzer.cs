using Domain.Enums;
using Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class MrezniPaketMenadzer
    {

        public List<MrezniPaket> KreirajPaketeOdKorisnika()
        {
            var paketi = new List<MrezniPaket>();
            try
            {
                Console.WriteLine("\n --- Kreiranje paketa za slanje ---");
                Console.WriteLine("Unesite broj paketa za slanje: ");
                int brojPaketa = int.Parse(Console.ReadLine());

                for (int i = 0; i < brojPaketa; i++)
                {
                    Console.WriteLine($"\n --- Unos podataka za paket #{i + 1} ---");
                    var paket = new MrezniPaket();
                    Console.WriteLine("Sadrzaj paketa: ");
                    paket.SadrzajPaketa = Console.ReadLine();
                    Console.Write("Protokol (0=SMTP, 1=HTTP, 2=HTTPS, 3=FTP): ");
                    paket.MrezniProtokol = (TipMreznogProtokola)int.Parse(Console.ReadLine());
                    paket.VelicinaZaglavlja = 20; //Fiksno, zbog jednostavnosti
                    paket.VelicinaPodataka = paket.SadrzajPaketa.Length * 2;
                    paket.IPAdresaPrimaoca = DNSServer.Instanca.IPAdresaServera;

                    paketi.Add(paket);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Paketi su uspesno kreirani");
                Console.ResetColor();
                return paketi;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine($"Greska prilikom unosa paketa: {ex.Message}");
                Console.ResetColor();
                return new List<MrezniPaket>();

            }
        }

    }
}
