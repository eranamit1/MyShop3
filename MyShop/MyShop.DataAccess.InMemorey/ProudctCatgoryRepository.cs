using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemorey
{
    public class ProudctCatgoryRepository
    {


        ObjectCache cache = MemoryCache.Default;
        List<ProudctCatgory> proudctCatgries;
        public ProudctCatgoryRepository()
        {
            proudctCatgries = cache["proudctCatgries"] as List<ProudctCatgory>;
            if (proudctCatgries == null)
            {
                proudctCatgries = new List<ProudctCatgory>();
            }
        }
        public void Commit()
        {
            cache["proudctCatgries"] = proudctCatgries;
        }
        public void Insert(ProudctCatgory p)
        {
            proudctCatgries.Add(p);
        }
        public void Update(ProudctCatgory proudctCatgory)
        {
            ProudctCatgory proudctCatgoryToUpdate = proudctCatgries.Find(p => p.Id == proudctCatgory.Id);
            if (proudctCatgoryToUpdate != null)
            {
                proudctCatgoryToUpdate = proudctCatgory;

            }
            else
            {
                throw new Exception(" Catgory  not found ");
            }
        }
        public ProudctCatgory Find(string Id)
        {
            ProudctCatgory proudctCatgory = proudctCatgries.Find(p => p.Id == Id);
            if (proudctCatgory != null)
            {
                return proudctCatgory;
            }
            else
            {
                throw new Exception(" Proudct Catgory not found ");

            }

        }
        public IQueryable<ProudctCatgory> Collection()
        {
            return proudctCatgries.AsQueryable();
        }
        public void Delete(string Id)
        {
            ProudctCatgory proudctCatgoryToDelete = proudctCatgries.Find(p => p.Id == Id);
            if (proudctCatgoryToDelete != null)
            {
                proudctCatgries.Remove(proudctCatgoryToDelete);

            }
            else
            {
                throw new Exception(" ProudctCatgory not found ");

            }
        }
    }
}