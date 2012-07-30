using System.Web.Mvc;
using MyFavourites.Models;

namespace MyFavourites.Controllers
{
    public class DocumentsController : Controller
    {
        public ActionResult Index()
        {
            var documents = Document.FindAll();
            return View("Index", documents);
        }

        public ActionResult Details(int id)
        {
            var document = Document.Find(id);
            return View("Details", document);
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            var document = new Document();
            TryUpdateModel(document);
            document.Save();
            return RedirectToAction("Details", new {id = document.Id});
        }

        public ActionResult Edit(int id)
        {
            return View("Edit", Document.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            var original = Document.Find(id);
            TryUpdateModel(original);
            original.Save();
            return RedirectToAction("Details", new {Id = id});
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var document = Document.Find(id);
            document.Delete();
            return RedirectToAction("Index");
        }
    }
}