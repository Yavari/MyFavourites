using System.Web.Mvc;
using MyFavourites.Models;

namespace MyFavourites.Controllers
{
    public class ResearchersController : Controller
    {
        public ActionResult Index()
        {
            return View("Index", Researcher.FindAll());
        }


        public ActionResult Details(int id)
        {
            return View("Details", Researcher.Find(id));
        }


        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            var researcher = new Researcher();
            TryUpdateModel(researcher);
            researcher.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View("Edit", Researcher.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            var researcher = Researcher.Find(id);
            TryUpdateModel(researcher);
            researcher.Save();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var user = Researcher.Find(id);
            user.Delete();
            return RedirectToAction("Index");
        }
    }
}
