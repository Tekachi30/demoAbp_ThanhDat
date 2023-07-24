using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    public class BookController : TodoAppController
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<List<BookDto>> GetListAsync()
        {
            return await _bookService.GetListAsync();
        }

        [HttpPost]
        public async Task<BookDto> CreateAsync([FromBody] string title)
        {
            return await _bookService.CreateAsync(title);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _bookService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
