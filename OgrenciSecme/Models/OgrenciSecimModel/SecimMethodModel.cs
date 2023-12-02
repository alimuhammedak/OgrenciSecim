using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciSecme.Models.OgrenciSecimModel
{
    internal class SecimMethodModel
    {
        public Egitim Egitim { get; set; }
        public List<Ogrenci> Ogrencis { get; set; }

        public SecimMethodModel()
        {
            Egitim = new Egitim();
        }

    }
}
