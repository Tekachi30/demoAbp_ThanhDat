using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Dto
{
    public class BookInputDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public int Pages { get; set; }
    }

}
