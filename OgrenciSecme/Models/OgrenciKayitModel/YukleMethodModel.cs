using OgrenciSecme.Models.Entities;
using System;
using System.Linq;

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
