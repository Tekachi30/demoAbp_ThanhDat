using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TodoApp.EntityFrameworkCore
{
    [ConnectionStringName(TodoAppConsts.ConnectionStringName)]
    public interface ITodoAppDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here.Example:
         * DbSet<Question> Questions { get; }
         */
        public DbSet<TodoItem> TodoItems { get; }
        public DbSet<TodoUser> TodoUsers { get;  }
        public DbSet<Book> Books { get;  }

    }
}
