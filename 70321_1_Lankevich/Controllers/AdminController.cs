using System.Web;
using System.Web.Mvc;
using _70321_1_Lankevich.DAL.Entities;
using _70321_1_Lankevich.DAL.Interfaces;

namespace _70321_1_Lankevich.Controllers
{
    public class AdminController : Controller
    {
        IRepository<Book> repository;
        public AdminController(IRepository<Book> repo)
        {
            repository = repo;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }


        // GET: Admin/Create
        public ActionResult Create()
        {
            return View(new Book());
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Book book, HttpPostedFileBase imageUpload = null)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    var count = imageUpload.ContentLength;
                    book.Image = new byte[count];
                    imageUpload.InputStream.Read(book.Image, 0, (int)count);
                    book.MimeType = imageUpload.ContentType;
                }
                try
                {
                    repository.Create(book);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else return View(book);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Book book, HttpPostedFileBase imageUpload = null)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    var count = imageUpload.ContentLength;
                    book.Image = new byte[count];
                    imageUpload.InputStream.Read(book.Image, 0, (int)count);
                    book.MimeType = imageUpload.ContentType;
                }
                try
                {
                    repository.Update(book);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(book);
                }
            }
            else return View(book);
        }


        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
            //return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
