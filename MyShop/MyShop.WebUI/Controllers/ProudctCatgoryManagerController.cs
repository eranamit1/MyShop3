using MyShop.Core.Models;
using MyShop.DataAccess.InMemorey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class ProudctCatgoryManagerController : Controller
    {


        InMemoreyRepositey<ProudctCatgory> context;
        public ProudctCatgoryManagerController()
        {
            context = new InMemoreyRepositey<ProudctCatgory>();
        }
        // GET: ProudctMnager
        public ActionResult Index()
        {
            List<ProudctCatgory> proudctCatgories = context.Collection().ToList();
            return View(proudctCatgories);
        }
        public ActionResult Create()
        {
            ProudctCatgory proudctCatgory = new ProudctCatgory();
            return View(proudctCatgory);
        }
        [HttpPost]
        public ActionResult Create(ProudctCatgory proudctCatgory)
        {
            if (!ModelState.IsValid)
            {
                return View(proudctCatgory);
            }
            else
            {
                context.Insett(proudctCatgory);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(string Id)
        {
            ProudctCatgory proudctCatgory = context.Find(Id);
            if (proudctCatgory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(proudctCatgory);
            }
        }
        [HttpPost]
        public ActionResult Edit(ProudctCatgory proudctCatgory, string Id)
        {
            ProudctCatgory proudctCatgoryToEdit = context.Find(Id);
            if (proudctCatgoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(proudctCatgory);
                }
                proudctCatgoryToEdit.Catgory = proudctCatgory.Catgory;

                context.Commit();
                return RedirectToAction("Index");
            }

        }
        public ActionResult Delete(string Id)
        {
            ProudctCatgory proudctCatgotyToDelete = context.Find(Id);
            if (proudctCatgotyToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(proudctCatgotyToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProudctCatgory proudctCatgoryToDelete = context.Find(Id);
            if (proudctCatgoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }

        }
    }
}