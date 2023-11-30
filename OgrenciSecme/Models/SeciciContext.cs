using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace OgrenciSecme.Models
{
    public partial class SeciciContext : DbContext
    {
        public SeciciContext()
            : base("name=SeciciContext")
        {
        }

        public virtual DbSet<Ders> Ders { get; set; }
        public virtual DbSet<Donem> Donems { get; set; }
        public virtual DbSet<Egitim> Egitims { get; set; }
        public virtual DbSet<Grup> Grups { get; set; }
        public virtual DbSet<Kullanici> Kullanicis { get; set; }
        public virtual DbSet<Ogrenci> Ogrencis { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ders>()
                .Property(e => e.kod)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Ogrenci>()
                .Property(e => e.ogrenciNo)
                .IsUnicode(false);
        }
    }
}
