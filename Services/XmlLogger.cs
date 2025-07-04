using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Services
{
    public class XmlLogger : IEvidencijaLogger
    {
        private const string PutanjaDoDatoteke = "evidencija_paketa.xml";

        public string ObradiEvidenciju(IEnumerable<MrezniPaket> primljeniPaketi)
        {
            try
            {
                //XmlSerializer zahteva da kolekcija bude konkretnog tipa
                var listaPaketa = primljeniPaketi.ToList() ?? new List<MrezniPaket>();

                var serializer = new XmlSerializer(typeof(List<MrezniPaket>));
                using (var stream = new StreamWriter(PutanjaDoDatoteke))
                {
                    serializer.Serialize(stream, listaPaketa);
                }

                return $"Evidencija je uspesno sacuvana u datoteku: {Path.GetFullPath(PutanjaDoDatoteke)}";
            }
            catch(Exception ex) 
            {
                return $"Greska prilikom cuvanja XML datoteke: {ex.Message}";    
            }
        }

    }
}
