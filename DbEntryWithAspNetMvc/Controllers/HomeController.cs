using Leafing.Data;
using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(Article.Find(Condition.Empty));
        }

        public ActionResult Show(long id)
        {
            return View(Article.FindById(id));
        }

        public ActionResult Edit(long id, Article article)
        {
            if(article != null)
            {
                article.Save();
            }
            return View(article);
        }

        public ActionResult Delete(long id)
        {
            if(id > 0)
            {
                Article.DeleteBy(p => p.Id == id);
            }
            return RedirectToAction("Index");
        }
    }
}
