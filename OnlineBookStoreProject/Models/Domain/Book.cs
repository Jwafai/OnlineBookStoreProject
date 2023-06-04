using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace OnlineBookStoreProject.Models.Domain
{
    public class Book
    {
        public int Id {get; set;}

        [Required]
        public string? BookName { get; set;}
        [Required]
        public string? RealeaseYear { get; set;}
        [Required]
        public string? BookImage { get; set;}
        [Required]
        public string? AuthorName { get; set;}
        

        [NotMapped]
        public IFormFile? ImageFile { get; set;}
        [NotMapped]
        [Required]
        public List<int>? Genres { get; set;}
        public IEnumerable<SelectListItem>? GenreList;
        [NotMapped]
        public string? GenreNames { get; set;}
        [NotMapped]
        public MultiSelectList? MultiGenreList { get; set;}
    }
}
