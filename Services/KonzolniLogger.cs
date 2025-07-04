using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class KonzolniLogger : IEvidencijaLogger
    {
        public string ObradiEvidenciju(IEnumerable<MrezniPaket> primljeniPaketi)
        {
            var sb = new StringBuilder();
            sb.AppendLine("\n--- EVIDENCIJA PRIMLJENIH PAKETA ---");

            if (primljeniPaketi == null || !primljeniPaketi.Any())
            {
                sb.AppendLine("Nema evidentiranih paketa.");
            }
            else
            {
                foreach (var paket in primljeniPaketi)
                {
                    sb.AppendLine($"[Vreme: {paket.VremePrijema:dd.MM.yyyy HH:mm:ss}] [Protokol: {paket.MrezniProtokol}] [Sadrzaj: {paket.SadrzajPaketa}]");
                }
            }
            sb.AppendLine("-----------------------------");

            Console.WriteLine(sb.ToString());

            return "Evidencija je uspesno prikazana na konzoli.";
        }
    }
}
