using _70321_1_Lankevich.DAL.Entities;
using _70321_1_Lankevich.DAL.Interfaces;
using _70321_1_Lankevich.Models;
using System.Linq;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace _70321_1_Lankevich.Controllers
{
    public class BookController : Controller
    {
        IRepository<Book> repository;
        int pageSize = 3;
        public BookController(IRepository<Book> repo)
        {
            repository = repo;
        }
        // GET: Book
        public ActionResult List(string genre, int page=1)
        {
            var lst = repository.GetAll()
                                .Where(d => genre == null
                                || d.GenreName.Equals(genre))
                                .OrderBy(d => d.Price);
            var model = PageListViewModel<Book>.CreatePage(lst, page, pageSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("ListPartial", model);
            }
            return View(PageListViewModel<Book>.CreatePage(lst, page, pageSize));
        }

        public FileContentResult GetImage(int id)
        {
            var book = repository.Get(id);
            if (book != null)
            {
                return new FileContentResult(book.Image, book.MimeType);
            }
            else return null;
        }

        public async Task<FileResult> GetImageAsync(int id)
        {
            var book = await repository.GetAsync(id);
            if (book != null)
            {
                return new FileContentResult(book.Image, book.MimeType);
            }
            else return null;
        }
    }
}