using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class ProudctCatgory
    {
        public string Id { get; set; }
        public string Catgory { get; set; }

        public ProudctCatgory()
        {
            this.Id = Guid.NewGuid().ToString();
        }

    }
}
