using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciSecme.Models.MainModels
{
    internal class MainYukleModel
    {
        public Egitim Egitim { get; set; }
        public Ogrenci Ogrenci { get; set; }

        public MainYukleModel()
        {
            Egitim = new Egitim();
            Ogrenci = new Ogrenci();
        }
    }
}
