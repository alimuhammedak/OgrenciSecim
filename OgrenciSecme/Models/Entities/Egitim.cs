namespace OgrenciSecme.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Egitim")]
    public partial class Egitim
    {
        public Guid egitimID { get; set; }

        public Guid ogrenciID { get; set; }

        public Guid kullaniciID { get; set; }

        public Guid grupID { get; set; }

        public Guid dersID { get; set; }

        public virtual Ders Der { get; set; }

        public virtual Grup Grup { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Ogrenci Ogrenci { get; set; }
    }
}
