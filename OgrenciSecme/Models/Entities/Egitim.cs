namespace OgrenciSecme.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Egitim")]
    public partial class Egitim
    {
        public int egitimID { get; set; }

        public int? ogrenciID { get; set; }

        public int? donemID { get; set; }

        public int? kullaniciID { get; set; }

        public int? grupID { get; set; }

        public int? dersID { get; set; }

        public virtual Ders Der { get; set; }

        public virtual Donem Donem { get; set; }

        public virtual Grup Grup { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Ogrenci Ogrenci { get; set; }
    }
}
