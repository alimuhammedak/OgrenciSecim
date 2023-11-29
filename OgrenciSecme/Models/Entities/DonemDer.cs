namespace OgrenciSecme.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DonemDer
    {
        [Key]
        public int donemDersID { get; set; }

        public int? dersID { get; set; }

        public int? ogrenciID { get; set; }

        public int? donemID { get; set; }

        public virtual Ders Der { get; set; }

        public virtual Donem Donem { get; set; }

        public virtual Ogrenci Ogrenci { get; set; }
    }
}
