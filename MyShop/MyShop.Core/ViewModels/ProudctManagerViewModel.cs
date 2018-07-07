using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.ViewModels
{
  public   class ProudctManagerViewModel
    {
     public Proudct proudct { get; set; }
        public IEnumerable<ProudctCatgory> proudctCatgories { get; set; }
    }
}
