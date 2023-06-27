using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DTOS;
using DataAccesLayer.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
        Task AddUser(UserDto user);

        Task UpdateUser(UserDto user);

        Task DeleteUserById(int id);

        Task<IEnumerable<User>> GetAllUsers();
        public Task<User> GetUserById(int id);

        public Task<User> Authenticate(string username, string password);
        public Task<User> GetUserByUsername(string username);

        public Task<bool> IsUsernameTaken(string username);

        public Task UpdateUserGrades(UserDtoGrades user);


    }
}