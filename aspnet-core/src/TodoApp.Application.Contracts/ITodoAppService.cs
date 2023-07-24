using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace TodoApp
{
    public interface ITodoAppService : IApplicationService
    {
        Task<List<TodoItemDto>> GetListAsync();
        Task<TodoItemDto> CreateAsync(string text);
        Task DeleteAsync(Guid id);

    }

    public interface ITodoAppUserService : IApplicationService
    {
        Task<List<TodoUserDto>> GetListUserAsync();
        Task<TodoUserDto> CreateUserAsync(string name);
        Task DeleteUserAsync(Guid id);

    }
}