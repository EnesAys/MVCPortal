using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcPortal.DAL.Model
{
    [Table("Yazı")]
    public class Yazi:BaseEntity
    {

        [Display(Name ="Yazı Başlık")]
        [MaxLength(150,ErrorMessage ="Başlık 150 Karakterden Fazla Olamaz")]
        [Required]
        public string Baslik { get; set; }

        [Display(Name = "Özet Açıklama")]
        public string KisaAciklama { get; set; }

        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        public int Okuma { get; set; }//İp bazlı olmayan görüntülenme sayısı için

        [Display(Name = "Resim")]
        [MaxLength(255, ErrorMessage = "255 Karakterden Fazla Olamaz")]
        public string Resim { get; set; }

        //Mapping
        public virtual Kullanici Kullanici { get; set; }
        public virtual ICollection<Resim> Resimler { get; set; }
        public virtual Kategori Kategori { get; set; }
    }
}
