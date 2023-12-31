using System;
using System.Data.Entity;
using System.Linq;

namespace OgrenciSecme.Models.Entities
{
    public partial class SeciciContext : DbContext
    {
        public SeciciContext()
            : base("name=SeciciContext")
        {
        }

        public virtual DbSet<BolognaYil> BolognaYils { get; set; }
        public virtual DbSet<Ders> Ders { get; set; }
        public virtual DbSet<Donem> Donems { get; set; }
        public virtual DbSet<Egitim> Egitims { get; set; }
        public virtual DbSet<Grup> Grups { get; set; }
        public virtual DbSet<Kullanici> Kullanicis { get; set; }
        public virtual DbSet<Ogrenci> Ogrencis { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BolognaYil>()
                .Property(e => e.ad)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BolognaYil>()
                .HasMany(e => e.Donems)
                .WithOptional(e => e.BolognaYil)
                .HasForeignKey(e => e.yilID);

            modelBuilder.Entity<Ders>()
                .Property(e => e.kod)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Ders>()
                .HasMany(e => e.Egitims)
                .WithRequired(e => e.Ders)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Donem>()
                .HasMany(e => e.Ders)
                .WithRequired(e => e.Donem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Grup>()
                .HasMany(e => e.Egitims)
                .WithRequired(e => e.Grup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Egitims)
                .WithRequired(e => e.Kullanici)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ogrenci>()
                .Property(e => e.ogrenciNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Ogrenci>()
                .HasMany(e => e.Egitims)
                .WithRequired(e => e.Ogrenci)
                .WillCascadeOnDelete(false);
        }
    }
}
