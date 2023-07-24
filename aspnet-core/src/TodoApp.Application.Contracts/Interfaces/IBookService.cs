using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Dto;
using Volo.Abp.Application.Services;

namespace TodoApp.Interfaces
{
    public interface IBookService : IApplicationService
    {
        Task<List<BookDto>> GetListAsync();
        Task<BookDto> CreateAsync(string title, string description, string author, double price, int pages);
        Task<BookDto> DeleteAsync(Guid id);
    }
}
