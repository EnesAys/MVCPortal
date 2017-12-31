using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcPortal.DAL.Model
{
    [Table("Resim")]
  public class Resim:BaseEntity
    {

        public string ResimUrl { get; set; }

        //Mapping
        public Yazi Yazi { get; set; }
    }
}
