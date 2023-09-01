using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASPCurdOprations.Models;

namespace ASPCurdOprations.Controllers
{
    public class BookController : Controller
    {
        // GET: BookController

        private readonly IConfiguration configuration;
        private BookCurd crud;

        public BookController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new BookCurd(this.configuration);
        }

        public ActionResult Index()
        {
            var model = crud.GetAllBooks();
            return View(model);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                int result = crud.AddBook(book);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {

            var result = crud.GetBookById(id);
            return View(result);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            try
            {
                int result = crud.UpdateBook(book);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {

            var result = crud.GetBookById(id);
            return View(result);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = crud.DeleteBook(id);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
