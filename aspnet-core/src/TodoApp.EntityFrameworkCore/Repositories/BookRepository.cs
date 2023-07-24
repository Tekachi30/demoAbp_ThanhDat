using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using TodoApp.Dto;
using TodoApp.EntityFrameworkCore;
using TodoApp.Repositories;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace TodoApp.Repositories
{
    public class BookRepository : ITransientDependency
    {
        //private readonly ITodoAppDbContext _dbcontext;
        private readonly IRepository<Book, Guid> _bookRepository;
        public BookRepository(ITodoAppDbContext dbContext, IRepository<Book, Guid> bookRepository)
        {
            //_dbcontext = dbContext;
            _bookRepository = bookRepository;
        }

        ////Lấy danh sách user
        public async Task<List<Book>> GetListAsync()
        {
            try
            {
                //var books = await _bookRepository.GetListAsync();
                //return books.ToList();
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
        public async Task<Book> CreateAsync(string title, string description, string author, double price, int pages)
        {
            try
            {
                // cách 1:
                var book = new Book
                {
                    Title = title,
                    Description = description,
                    Author = author,
                    Price = price,
                    Pages = pages
                };
                var createdBook = await _bookRepository.InsertAsync(book);
                return createdBook;

                //cách 2:
                //var book = await _bookRepository.InsertAsync(
                //    new Book
                //    {
                //        Title = title,
                //        Description = description,
                //        Author = author,
                //        Price = price,
                //        Pages = pages
                //    });
                //return new BookDto { Id = book.Id, Title = book.Title, Description = book.Description, Author = book.Author, Price = book.Price };

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

}
