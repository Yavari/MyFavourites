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

        public ActionResult Create(Document document)
        {
            document.Save();
            var parameters = new {id = document.Id};
            return RedirectToAction("Details", parameters);
        }

        public ActionResult Edit(int id)
        {
            return View("Edit", Document.Find(id));
        }

        public ActionResult Edit(int id, Document document)
        {
            var original = Document.Find(id);
            original.Title = document.Title;
            original.Text = document.Text;
            original.Save();
            return RedirectToAction("Details", new {Id = id});
        }

        public ActionResult Delete(int id)
        {
            var document = Document.Find(id);
            document.Delete();
            return RedirectToAction("Index");
        }
    }
}