using OnlineBookStoreProject.Models.Domain;

namespace OnlineBookStoreProject.Models.DTO
{
    public class BookListVm
    {
        public IQueryable<Book> BookList { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? Term { get; set; }
        public IQueryable<Genre> Genres { get; set; }
        public int GenreId { get; set; } = 0;
        public IQueryable<Genre> Books { get; set; }
        public string STerm { get; set; } = "";


    }
}
