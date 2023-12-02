using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciSecme.Models.OgrenciKayitModel
{
    internal class YukleMethodModel
    {
        public Egitim Egitim { get; set; }
        public Ogrenci Ogrenci { get; set; }

        public YukleMethodModel()
        {
            Egitim = new Egitim();
            Ogrenci = new Ogrenci();
        }
    }
}
