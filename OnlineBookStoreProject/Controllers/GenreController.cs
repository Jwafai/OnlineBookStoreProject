using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreProject.Models.Domain;
using OnlineBookStoreProject.Repositries.Abstract;

namespace OnlineBookStoreProject.Controllers
{
    //to protect the controller, later we can authorize it to specific roles,it can be used to,this also logs us out whenever we close the application 
    //[Authorize]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController (IGenreService genreService)
        {
            _genreService = genreService;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Genre model )
        {
            if(!ModelState.IsValid) { return View(model); }

            var result = _genreService.Add(model);
           if(result)
            {
                TempData["msg"] = "Added successfully";
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
            var data = _genreService.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Genre model)
        {
            if (!ModelState.IsValid) { return View(model); }

            var result = _genreService.Update(model);
            if (result)
            {
                TempData["msg"] = "Updated successfully";
                return RedirectToAction(nameof(GenreList));
            }
            else
            {
                TempData["msg"] = "Error on the server side ";
                return View(model);
            }
        }

        //Getting list
        public IActionResult GenreList()
        {
            var data = this._genreService.List().ToList();

            return View(data);
        }

        //Deleting
      
        public IActionResult Delete(int id)
        {
            
           var result = _genreService.Delete(id);
            return RedirectToAction(nameof(GenreList));

        }
    }
}
