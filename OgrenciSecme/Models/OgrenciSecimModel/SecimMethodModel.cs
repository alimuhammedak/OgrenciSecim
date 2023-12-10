using OgrenciSecme.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OgrenciSecme.Models.OgrenciSecimModel
{
    internal class SecimMethodModel
    {
        public Egitim Egitim { get; set; }
        public BolognaYil BolognaYil { get; set; }
        public Donem Donem { get; set; }
        public List<Ogrenci> Ogrencis { get; set; }

        public SecimMethodModel()
        {
            Egitim = new Egitim();
            Donem = new Donem();
            BolognaYil = new BolognaYil();
        }

    }
}
