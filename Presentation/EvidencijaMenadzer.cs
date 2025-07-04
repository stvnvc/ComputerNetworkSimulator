using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class EvidencijaMenadzer
    {
        private readonly IAplikativniServis _appService;
        private readonly IServiceProvider _serviceProvider;

        public EvidencijaMenadzer (IAplikativniServis appService, IServiceProvider serviceProvider)
        {
            _appService = appService;
            _serviceProvider = serviceProvider;
        }

        public void PrikaziNaKonzoli()
        {
            var logger = (IEvidencijaLogger)_serviceProvider.GetService(typeof(Services.KonzolniLogger));
            string rezultat = _appService.PrikaziIliSacuvajEvidenciju(logger);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(rezultat);
            Console.ResetColor();
        }

        public void SacuvajUXml()
        {
            var logger = (IEvidencijaLogger)_serviceProvider.GetService(typeof(Services.XmlLogger));
            string rezultat = _appService.PrikaziIliSacuvajEvidenciju(logger);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(rezultat);
            Console.ResetColor();
        }
    }
}
