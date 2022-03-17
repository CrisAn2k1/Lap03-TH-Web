namespace Lab03_DuongQuocAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Loai")]
    public partial class Loai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Loai()
        {
            Rubik = new HashSet<Rubik>();
        }

        [Key]
        public int maloai { get; set; }

        [StringLength(30)]
        public string tenloai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rubik> Rubik { get; set; }
        public static List<Loai> getAll()
        {
            RubikModel context = new RubikModel();
            return context.Loai.ToList();
        }
    }
}
