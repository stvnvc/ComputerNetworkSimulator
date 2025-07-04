using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class DNSServer
    {
        public string IPAdresaServera { get; set; }

        public int MaksimalanBrojUredjaja;

        public string SimbolickaAresa { get; set; }

        public TipOperativnogStanja TipOperativnogStanja { get; set; }

        public List<MrezniPaket> PrimljeniPaketi { get; private set; }

        private static readonly DNSServer _instanca = new DNSServer();

        public static DNSServer Instanca => _instanca;

        private DNSServer() 
        {
            IPAdresaServera = "192.168.1.1";
            SimbolickaAresa = "dns.local";
            TipOperativnogStanja = TipOperativnogStanja.OPERATIVAN;
            MaksimalanBrojUredjaja = 100;
            PrimljeniPaketi = new List<MrezniPaket>(); 
        }

        public override string? ToString()
        {
            return "\nDNS Server: \n" + $"Ip adresa servera: {IPAdresaServera}" +
                $"\nMaksimalan broj povezanih uredjaja: {MaksimalanBrojUredjaja}" +
                $"\nSimbolicka adresa: {SimbolickaAresa}" +
                $"\nTip operativnog stanja: {TipOperativnogStanja}" +
                $"\nBroj primljenih paketa: {PrimljeniPaketi.Count}";
        }
    }
}
