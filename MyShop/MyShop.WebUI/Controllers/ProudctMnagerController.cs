using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.Models;
using MyShop.DataAccess.InMemorey;

namespace MyShop.WebUI.Controllers
{
    public class ProudctMnagerController : Controller
    {
        ProudctRepostorey context;
        public ProudctMnagerController()
        {
            context = new ProudctRepostorey();
        }
        // GET: ProudctMnager
        public ActionResult Index()
        {
            List<Proudct> proudcts = context.Collection().ToList();
            return View(proudcts);
        }
        public ActionResult Create() { 
            Proudct proudct = new Proudct();
            return View(proudct);
        }
        [HttpPost]
        public ActionResult Create(Proudct proudct)
        {
            if (!ModelState.IsValid)
            {
                return View(proudct);
            }
            else
            {
                context.Insert(proudct);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(string Id)
        {
            Proudct proudct = context.Find(Id);
            if (proudct == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(proudct);
            }
        }
        [HttpPost]
        public ActionResult Edit(Proudct proudct,string Id)
        {
            Proudct proudctToEdit = context.Find(Id);
            if (proudctToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(proudct);
                }
                proudctToEdit.Catgorey = proudct.Catgorey;
                proudctToEdit.Descrition = proudct.Descrition;
                proudctToEdit.Image = proudct.Image;
                proudctToEdit.Name = proudct.Name;
                proudctToEdit.Price = proudct.Price;
                context.Commit();
                return RedirectToAction("Index");
            }
            
        }
        public ActionResult Delete(string Id)
        {
            Proudct proudctToDelete = context.Find(Id);
            if (proudctToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(proudctToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Proudct proudctToDelete = context.Find(Id);
            if (proudctToDelete == null)
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
