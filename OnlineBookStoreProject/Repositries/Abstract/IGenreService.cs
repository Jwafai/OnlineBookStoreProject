using OnlineBookStoreProject.Models.Domain;
using OnlineBookStoreProject.Models.DTO;

namespace OnlineBookStoreProject.Repositries.Abstract
{
    public interface IGenreService
    {
        bool Add(Genre model);
        bool Update(Genre model);
        bool Delete(int id);
        Genre GetById(int id);
        IQueryable<Genre> List();
    }
}
