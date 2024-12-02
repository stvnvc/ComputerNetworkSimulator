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
            public int VelicinaPodataka { get; set; }
            public string SadrzajPaketa { get; set; } = string.Empty;
            public string IPAdresaPrimaoca { get; set; } = string.Empty;

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
                return $"Protokol: {MrezniProtokol}, Zaglavlje: {VelicinaZaglavlja} bajtova, Podaci: {VelicinaPodataka} bajtova, " +
                       $"Sadržaj: {SadrzajPaketa}, IP Primaoca: {IPAdresaPrimaoca}";
            }
    }

}
