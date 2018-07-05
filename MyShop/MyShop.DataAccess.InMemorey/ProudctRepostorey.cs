using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;
namespace MyShop.DataAccess.InMemorey
{
    public class ProudctRepostorey
    {
        ObjectCache cache = MemoryCache.Default;
        List<Proudct> proudcts;
        public ProudctRepostorey()
        {
            proudcts = cache["proudcts"] as List<Proudct>;
            if (proudcts == null)
            {
                proudcts = new List<Proudct>();
            }
        }
        public void Commit()
        {
            cache["proudcts"] = proudcts;
        }
        public void Insert(Proudct p)
        {
            proudcts.Add(p);
        }
        public void Update(Proudct proudct)
        {
            Proudct proudctToUpdate = proudcts.Find(p => p.Id == proudct.Id);
            if (proudctToUpdate != null)
            {
                proudctToUpdate = proudct;

            }
            else
            {
                throw new Exception(" Proudct not found ");
            }
        }
                public Proudct Find(string Id)
        {
            Proudct proudct = proudcts.Find(p => p.Id ==Id);
            if (proudct != null)
            {
                return proudct;
            }
            else
            {
                throw new Exception(" Proudct not found ");

            }

        }
        public IQueryable<Proudct> Collection()
        {
            return proudcts.AsQueryable();
        }
        public void Delete(string Id)
        {
            Proudct proudctToDelete = proudcts.Find(p => p.Id == Id);
            if (proudctToDelete != null)
            {
                proudcts.Remove(proudctToDelete);

            }
            else
            {
                throw new Exception(" Proudct not found ");

            }
        }

        }
    }

