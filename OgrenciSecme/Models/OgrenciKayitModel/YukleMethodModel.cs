using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OgrenciSecme.Models.Entities;

namespace OgrenciSecme.Models.OgrenciKayitModel
{
    internal class YukleMethodModel
    {
        public Egitim Egitim { get; set; }
        public Ogrenci Ogrenci { get; set; }
        public Donem Donem { get; set; }
        public BolognaYil BolognaYil { get; set; }

        public YukleMethodModel()
        {
            Egitim = new Egitim();
            Ogrenci = new Ogrenci();
            Donem = new Donem();
            BolognaYil = new BolognaYil();
        }
    }
}
