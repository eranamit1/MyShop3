using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
   public  class Proudct
    {
        public string Id { get; set; }
        [StringLength(20)]
        [DisplayName("Proudct Name")]
        public string Name { get; set; }
        public string Descrition { get; set; }
        [Range(0,1000)]
        public decimal Price { get; set; }
        public string Catgorey { get; set; }
        public string Image { get; set; }
        public Proudct()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
