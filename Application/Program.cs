using Domain.Enums;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Presentation;
using Services;

namespace Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Konfiguracija Dependency Injection kontejnera
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IDnsServerRepozitorijum, DnsServerRepozitorijum>()
                .AddTransient<IAutentifikacioniServis, AutentifikacioniServis>()
                .AddSingleton<IAplikativniServis, AplikativniServis>()
                .AddTransient<BalansiraniRasporedjivac>()
                .AddTransient<NasumicniRasporedjivac>()
                .AddTransient<KonzolniLogger>()
                .AddTransient<XmlLogger>()

                .AddTransient<Autentifikacija>()
                .AddTransient<RacunarMenadzer>()
                .AddTransient<SimulacijaMenadzer>()
                .AddTransient<EvidencijaMenadzer>()
                .AddTransient<MeniMenadzer>()
                .AddTransient<RuterMenadzer>()
                .AddTransient<TestPodaciMenadzer>()
                .AddTransient<MrezniPaketMenadzer>()

                .AddTransient<AplikacijaKonzola>()
                .BuildServiceProvider();

            var app = (AplikacijaKonzola)serviceProvider.GetService(typeof(AplikacijaKonzola));

            app.Pokreni();
        }
    }
}
