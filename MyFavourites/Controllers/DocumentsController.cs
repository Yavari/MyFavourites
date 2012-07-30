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
    }
}