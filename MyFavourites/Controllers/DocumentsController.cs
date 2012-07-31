using System.Web.Mvc;
using Castle.ActiveRecord;
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
            if (TryUpdateModel(document))
            {
                document.Save();
                return RedirectToAction("Details", new {id = document.Id});
            }
            return View("Create");
        }

        public ActionResult Edit(int id)
        {
            return View("Edit", Document.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            using (var transaction = new TransactionScope(TransactionMode.Inherits))
            {
                var original = Document.Find(id);
                if (TryUpdateModel(original))
                {
                    original.Save();
                    return RedirectToAction("Details", new { Id = id });
                }
                transaction.VoteRollBack();
                return View("Edit"); 
            }
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