using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Dto;
using TodoApp.Interfaces;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetListBook()
        {
            try
            {
                var books = await _bookService.GetListBook();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBook([FromBody] BookInputDto inputDto)
        {
            try
            {
                var book = await _bookService.CreateBook(inputDto.Title, inputDto.Description, inputDto.Author, inputDto.Price, inputDto.Pages);
                return CreatedAtAction(nameof(GetListBook), book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BookDto>> DeleteBook(Guid id)
        {
            try
            {
                await _bookService.DeleteBook(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
