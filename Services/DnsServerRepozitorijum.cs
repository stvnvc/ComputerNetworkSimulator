using Domain.Interfaces;
using Domain.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DnsServerRepozitorijum : IDnsServerRepozitorijum
    {
        //Cuvanje DNS evidencije u tekstualnu datoteku
        private const string PutanjaDoDatoteke = "dns_log.txt";

        public void SacuvajEvidenciju(MrezniPaket paket)
        {
            try
            {
                string logZapis = $"Vreme: {paket.VremePrijema:dd.MM.yyyy HH:mm:ss}, Odredisna IP: {paket.IPAdresaPrimaoca}";
                File.AppendAllText(PutanjaDoDatoteke, logZapis + Environment.NewLine);
            }
            catch (Exception ex) {
                Console.WriteLine($"Greska prilikom upisa u datoteku evidencije: {ex.Message}");
            } 
        }
    }
}
