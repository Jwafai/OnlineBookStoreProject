using OnlineBookStoreProject.Models.Domain;
using OnlineBookStoreProject.Models.DTO;

namespace OnlineBookStoreProject.Repositries.Abstract
{
    public interface IBookService
    {
        bool Add(Book model);
        bool Update(Book model);
        bool Delete(int id);
        Book GetById(int id);
        BookListVm List(string term="", bool paging = false, int currentPage = 0);
        List<int> GetGenreByBookId(int id);
    }
}
