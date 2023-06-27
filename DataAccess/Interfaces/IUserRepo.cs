using DataAccesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUserRepo
    {
        Task AddUser(User user);

        Task UpdateUser(User user);

        Task DeleteUserById(int id);

        Task<IEnumerable<User>> GetAllUsers();

        public Task<User> GetUserById(int id);

        public Task<User> FindByName(string username);

        public Task<User> GetUserByUsername(string username);
        public Task<bool> CheckPassword(User user, string password);
    }
}