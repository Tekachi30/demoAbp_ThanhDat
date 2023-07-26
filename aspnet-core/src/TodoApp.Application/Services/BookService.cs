using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Dto;
using TodoApp.Interfaces;
using TodoApp.Repositories;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace TodoApp.Services
{
    public class BookService : TodoAppAppService, IBookService
    {
        private readonly ILogger<BookService> _log;
        private readonly IBookRepository _bookRepository;


        public BookService(ILogger<BookService> log, IBookRepository bookRepository)
        {
            _log = log;
            _bookRepository = bookRepository;
        }

        public async Task<List<BookDto>> GetListBook()
        {
            try
            {
                _log.LogInformation("Đây là danh sách book");
                var bookList = await _bookRepository.GetListAsync();
                return new List<BookDto>(ObjectMapper.Map<List<Book>, List<BookDto>>(bookList));
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Message", ex.Message);
            }
        }

        public async Task<BookDto> CreateBook(string title, string description, string author, double price, int pages)
        {
            try
            {
                var createdBook = await _bookRepository.CreateAsync(title, description, author, price, pages);
                return ObjectMapper.Map<Book, BookDto>(createdBook);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Message", ex.Message);
            }
        }

        public async Task DeleteBook(Guid id)
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

        //public async Task<List<BookDto>> GetListAsync()
        //{
        //    try
        //    {
        //        _log.LogInformation("Đây là danh sách book");
        //        var bookList = await _bookRepository.GetListAsync();
        //        return new List<BookDto>(ObjectMapper.Map<List<Book>, List<BookDto>>(bookList));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new UserFriendlyException("Message", ex.Message);
        //    }
        //}

        //public async Task<BookDto> CreateAsync(string title, string description, string author, double price, int pages)
        //{
        //    try
        //    {
        //        var createdBook = await _bookRepository.CreateAsync(title, description, author, price, pages);
        //        return ObjectMapper.Map<Book, BookDto>(createdBook);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new UserFriendlyException("Message", ex.Message);
        //    }
        //}

        //public async Task DeleteAsync(Guid id)
        //{
        //    try
        //    {
        //        await _bookRepository.DeleteAsync(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new UserFriendlyException("Message", ex.Message);
        //    }
        //}
    }
}
