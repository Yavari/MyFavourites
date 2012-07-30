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
    }
}