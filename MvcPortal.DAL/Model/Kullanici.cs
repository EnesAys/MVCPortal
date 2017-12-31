using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcPortal.DAL.Model
{
    [Table("Kullanici")]
    public class Kullanici:BaseEntity
    {

        [MaxLength(100, ErrorMessage = "Lütfen 100 karakterden fazla değer girmeyiniz")]
        [Display(Name = "Ad Soyad")]
        public string AdSoyad { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Mail Alanı Zorunludur")]
        [EmailAddress(ErrorMessage ="Geçerli bir mail adresi giriniz")]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre Alanı Zorunludur")]
        [MaxLength(16,ErrorMessage ="Lütfen 16 karakterden fazla girmeyiniz !")]
        public string Sifre { get; set; }


        //Mapping
        public virtual Rol Rol { get; set; }
    }
}
