using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace TodoApp.Repositories
{
    public class BookRepository : ITransientDependency
    {
        //private readonly ITodoAppDbContext _dbcontext;
        //public BookRepository(ITodoAppDbContext dbcontext)
        //{
        //    _dbcontext = dbcontext;
        //}
        private readonly IRepository<Book, Guid> _bookRepository;

        public BookRepository(IRepository<Book, Guid> bookRepository) { _bookRepository = bookRepository; }

        ////Lấy danh sách user
        public async Task<List<Book>> GetListAsync()
        {
            try
            {
                var books = await _bookRepository.GetListAsync();
                return books
                    .Select(book => new Book
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Description = book.Description,
                        Author = book.Author,
                        Price = book.Price,
                        Pages = book.Pages
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Message", ex.Message);
            }
        }

        // Thêm mới sách
        public async Task<Book> CreateAsync(Book book)
        {
            try
            {
                var createdBook = await _bookRepository.InsertAsync(book);
                return createdBook;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Message", ex.Message);

            }
        }

        // Xóa sách
        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _bookRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Message", ex.Message);
            }
        }
    }

    //// Thêm tên user vào
    //public async Task<TodoUserDto> CreateUserAsync(string name)
    //{
    //    var todoUser = await _userRepository.InsertAsync(
    //        new TodoUser { UserName = name }
    //        );

    //    return new TodoUserDto { Id = todoUser.Id, UserName = todoUser.UserName };
    //}


    //public async Task DeleteUserAsync(Guid id)
    //{
    //    await _userRepository.DeleteAsync(id);
    //}
}
