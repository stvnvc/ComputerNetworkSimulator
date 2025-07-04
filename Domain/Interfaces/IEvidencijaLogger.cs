using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEvidencijaLogger
    {
        //Obradjuje listu primljenih paketa i generise statusnu poruku ili putanju do fajla
        string ObradiEvidenciju(IEnumerable<MrezniPaket> primljeniPaketi);
    }
}
