using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MrezniPaket
    {
        public TipMreznogProtokola MrezniProtokol { get; set; }
        public int VelicinaZaglavlja { get; set; }
        = -1;
        public int VelicinaPodataka { get; set; } = -1;

        public string SadrzajPaketa { get; set; } = string.Empty;

        public string IPAdresaPrimaoca { get; set; } = string.Empty;

        public DateTime VremePrijema { get; set; }

        public MrezniPaket() { }

        public MrezniPaket(TipMreznogProtokola mrezniProtokol, int velicinaZaglavlja, int velicinaPodataka, string sadrzajPaketa, string ipAdresaPrimaoca)
        {
            MrezniProtokol = mrezniProtokol;
            VelicinaZaglavlja = velicinaZaglavlja;
            VelicinaPodataka = velicinaPodataka;
            SadrzajPaketa = sadrzajPaketa;
            IPAdresaPrimaoca = ipAdresaPrimaoca;
        }

        public override string ToString()
        {
            return $"\nProtokol: {MrezniProtokol}" +
            $"\nZaglavlje: {VelicinaZaglavlja} bajtova" +
            $"\nPodaci: {VelicinaPodataka} bajtova" +
            $"\nSadržaj: {SadrzajPaketa}" +
            $"\nIP Primaoca: {IPAdresaPrimaoca}" +
            $"\nVrme prijema: {VremePrijema}";
        }
    }
}
