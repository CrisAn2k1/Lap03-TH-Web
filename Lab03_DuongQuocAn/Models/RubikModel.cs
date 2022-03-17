using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Lab03_DuongQuocAn.Models
{
    public partial class RubikModel : DbContext
    {
        public RubikModel()
            : base("name=RubikModel")
        {
        }

        public virtual DbSet<Loai> Loai { get; set; }
        public virtual DbSet<Rubik> Rubik { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rubik>()
                .Property(e => e.gia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Rubik>()
                .Property(e => e.hinh)
                .IsUnicode(false);
        }
    }
}
