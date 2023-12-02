namespace OgrenciSecme.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ders()
        {
            Egitims = new HashSet<Egitim>();
        }

        [Key]
        public Guid dersID { get; set; }

        public Guid donemID { get; set; }

        [Required]
        [StringLength(10)]
        public string kod { get; set; }

        [Required]
        [StringLength(50)]
        public string ad { get; set; }

        public virtual Donem Donem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Egitim> Egitims { get; set; }
    }
}
