using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetListAsync();
        Task<Book> CreateAsync(string text);
        Task DeleteAsync(Guid id);
    }   
}
