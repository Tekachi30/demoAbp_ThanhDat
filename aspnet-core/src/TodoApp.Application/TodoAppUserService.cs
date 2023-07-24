using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TodoApp
{
    public class TodoAppUserService : ApplicationService, ITodoAppUserService
    {
        private readonly IRepository<TodoUser, Guid> _userRepository;


        public TodoAppUserService(IRepository<TodoUser, Guid> UserRepository)
        {
            _userRepository = UserRepository;
        }
        // TODO: Implement the methods here...

        //Lấy danh sách user
        public async Task<List<TodoUserDto>> GetListUserAsync()
        {
            var users = await _userRepository.GetListAsync();
            return users
                .Select(users => new TodoUserDto
                {
                    Id = users.Id,
                    UserName = users.UserName
                }).ToList();
        }

        // Thêm tên user vào
        public async Task<TodoUserDto> CreateUserAsync(string name)
        {
            var todoUser = await _userRepository.InsertAsync(
                new TodoUser { UserName = name }
                );

            return new TodoUserDto { Id = todoUser.Id, UserName = todoUser.UserName };
        }


        public async Task DeleteUserAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }


    }
}