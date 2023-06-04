using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineBookStoreProject.Models.Domain;
using OnlineBookStoreProject.Repositries.Abstract;

namespace OnlineBookStoreProject.Controllers
{
    //to protect the controller, later we can authorize it to specific roles,it can be used to,this also logs us out whenever we close the application 
    //[Authorize]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IFileService _fileService;
        private readonly IGenreService _genreService;

        public BookController (IBookService BookService, IFileService fileService, IGenreService genreService)
        {
            _bookService = BookService;
            _fileService = fileService;
            _genreService = genreService;
        }

        public IActionResult Add()
        {
            var model = new Book(); 
            model.GenreList = _genreService.List().Select(a=> new SelectListItem{ Text= a.GenreName , Value = a.Id.ToString()});
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Book model )
        {
            model.GenreList = _genreService.List().Select(a => new SelectListItem { Text = a.GenreName, Value = a.Id.ToString() });
            if (!ModelState.IsValid) { return View(model); }
            if(model.ImageFile!= null)
            { 
                var fileResult = this._fileService.SaveImage(model.ImageFile);
                if( fileResult.Item1 == 0 )
                {
                    TempData["msg"] = "Image couldnt be saved";
                    return View(model);
                }
                var imageName = fileResult.Item2;
                model.BookImage = imageName;
            }
            var result = _bookService.Add(model);

           if(result)
            {
                TempData["msg"] = "Updated successfully";
                return RedirectToAction(nameof(Add));
            }
           else
            {
                TempData["msg"] = "Error on the server side ";
                return View(model);
            }
            
        }

        //This is for the Updating
        public IActionResult Edit(int id)
        {
            var model = _bookService.GetById(id);
            var selectedGenre = _bookService.GetGenreByBookId(model.Id);
            MultiSelectList multiGenreList = new MultiSelectList(_genreService.List(), "Id", "GenreName", selectedGenre);
            model.MultiGenreList = multiGenreList;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Book model)
        {


            var selectedGenre = _bookService.GetGenreByBookId(model.Id);
            MultiSelectList multiGenreList = new MultiSelectList(_genreService.List(), "Id", "GenreName", selectedGenre);
            model.MultiGenreList = multiGenreList;
            if (!ModelState.IsValid) { return View(model); }
            if (model.ImageFile != null)
            {
                var fileResult = this._fileService.SaveImage(model.ImageFile);
                if (fileResult.Item1 == 0)
                {
                    TempData["msg"] = "Image couldnt be saved";
                    return View(model);
                }
                var imageName = fileResult.Item2;
                model.BookImage = imageName;
            }
            var result = _bookService.Update(model);
            if (result)
            {
                TempData["msg"] = "Updated successfully";
                return RedirectToAction(nameof(BookList));
            }
            else
            {
                TempData["msg"] = "Error on the server side ";
                return View(model);
            }
        }

        //Getting list
        public IActionResult BookList()
        {
            var data = this._bookService.List();

            return View(data);
        }

        //Deleting
      
        public IActionResult Delete(int id)
        {
            
           var result = _bookService.Delete(id);
            return RedirectToAction(nameof(BookList));

        }
    }
}
