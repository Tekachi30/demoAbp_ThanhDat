using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace TodoApp
{
    public class TodoUser : BasicAggregateRoot<Guid>
    {
        public string UserName { get; set; }
    }
}
