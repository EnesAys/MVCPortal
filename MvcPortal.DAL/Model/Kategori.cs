using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcPortal.DAL.Model
{
    [Table("Kategori")]
   public class Kategori:BaseEntity
    {
 

        [MinLength(2,ErrorMessage ="Kategori Adı {0} karakterden kısa olamaaz."),MaxLength(100,ErrorMessage ="Kategori Adı 100 karakterden fazla olamaz.")]
        [Required(ErrorMessage ="Bu Alan Boş Geçilemez")]
        public string KategoriAdi { get; set; }

        public int? ParentID { get; set; }//Üst Kategori İçin

        [MinLength(2, ErrorMessage = "{0} karakterden kısa olamaaz."), MaxLength(100, ErrorMessage = "100 karakterden fazla olamaz.")]
        public string URL { get; set; }




        //Mapping

        public virtual ICollection<Yazi> Yazi { get; set; }

    }
}
