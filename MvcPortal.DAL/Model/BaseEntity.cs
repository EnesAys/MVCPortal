using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcPortal.DAL.Model
{
   public class BaseEntity
    {
        public int ID { get; set; }

        bool aktif = true;//Default value
        DateTime tarih = DateTime.Now;//Default Date

        [Display(Name ="Aktif Mi?")]
        public bool Aktifmi { get { return aktif; } set { aktif = value; } }


        [Display(Name = "Eklenme Tarihi")]
        public DateTime EklenmeTarihi { get { return tarih; } set { tarih = value; } }
    }
}
