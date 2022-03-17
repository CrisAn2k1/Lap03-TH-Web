namespace Lab03_DuongQuocAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Rubik")]
    public partial class Rubik
    {
        public int id { get; set; }

        public int? maloai { get; set; }

        [Required]
        [StringLength(100)]
        public string ten { get; set; }

        public string mota { get; set; }

        [StringLength(50)]
        public string hang { get; set; }

        public decimal? gia { get; set; }

        [StringLength(50)]
        public string hinh { get; set; }

        public int? soluongton { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ngaycapnhat { get; set; }

        public virtual Loai Loai { get; set; }
        public static List<Rubik> getAll()
        {
            RubikModel context = new RubikModel();
            return context.Rubik.ToList();
        }

        public static List<Rubik> getAll(string searchKey)
        {
            RubikModel context = new RubikModel();
            searchKey = searchKey + "";
            return context.Rubik.Where(p => p.ten.Contains(searchKey)).ToList();
        }
        public void insert()
        {
            RubikModel context = new RubikModel();
            try
            {
                context.Rubik.Add(this);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Rubik FindRubikByID(int iD)
        {
            RubikModel context = new RubikModel();

            return context.Rubik.FirstOrDefault(p => p.id == iD);
        }

        public void Update()
        {
            RubikModel context = new RubikModel();
            try
            {
                Rubik find = context.Rubik.FirstOrDefault(p => p.id == id);
                if (find != null)
                {
                    find.ten = this.ten;
                    find.gia = this.gia;
                    find.mota = this.mota;
                    find.hinh = this.hinh;
                    find.hang = this.hang;
                    find.maloai = this.maloai;
                    find.soluongton = this.soluongton;
                    find.ngaycapnhat = this.ngaycapnhat;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
