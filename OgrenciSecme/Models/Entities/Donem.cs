namespace OgrenciSecme.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Donem")]
    public partial class Donem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Donem()
        {
            Ders = new HashSet<Ders>();
        }

        public Guid donemID { get; set; }

        public Guid? yilID { get; set; }

        [Required]
        [StringLength(70)]
        public string ad { get; set; }

        public virtual BolognaYil BolognaYil { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ders> Ders { get; set; }
    }
}
