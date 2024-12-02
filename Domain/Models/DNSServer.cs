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
        public string IPAdresaServera { get; set; } = string.Empty;

        public int MaksimalanBrojUredjaja = -1;

        public string SimbolickaAresa { get; set; } = string.Empty;

        public TipOperativnogStanja TipOperativnogStanja { get; set; }

        public DNSServer()
        { }

        public DNSServer(string iPAdresaServera, int maksimalanBrojUredjaja, 
            string simbolickaAresa, TipOperativnogStanja tipOperativnogStanja)
        {
            IPAdresaServera = iPAdresaServera;
            MaksimalanBrojUredjaja = maksimalanBrojUredjaja;
            SimbolickaAresa = simbolickaAresa;
            TipOperativnogStanja = tipOperativnogStanja;
        }

        public override string? ToString()
        {
            return "\nDNS Server: \n" + $"Ip adresa servera: {IPAdresaServera}" +
                $"\nMaksimalan broj povezanih uredjaja: {MaksimalanBrojUredjaja}" +
                $"\nSimbolicka adresa: {SimbolickaAresa}" +
                $"\nTip operativnog stanja: {TipOperativnogStanja}";
        }
    }
}
