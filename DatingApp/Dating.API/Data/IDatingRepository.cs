using System.Threading.Tasks;
using System.Collections.Generic;
using Dating.API.Models;
namespace Dating.API.Data
{
    public interface IDatingRepository
    {
         void Add<T>(T entity) where T: class;
         void DElete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<User>>GetUsers();
         Task<User>GetUser(int id );

    }
}