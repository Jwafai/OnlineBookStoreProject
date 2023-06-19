using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreProject.Models.Domain;
using OnlineBookStoreProject.Models.DTO;
using OnlineBookStoreProject.Repositries.Abstract;
using System.Diagnostics;

namespace OnlineBookStoreProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public  IActionResult Index(string sterm = "", int currentPage = 1)
        {
            var books = _bookService.List(sterm, true, currentPage); 
            return View(books);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult BookDetail(int bookId)
        {
            var book = _bookService.GetById(bookId);
            return View(book);
        }
    }
}