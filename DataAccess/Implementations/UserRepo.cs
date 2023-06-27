using DataAccesLayer;
using DataAccesLayer.Models;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace DataAccessLayer.Implementation
{
    public class UserRepo : IUserRepo
    {
        public readonly QuizAppContext quizContext;

        public UserRepo()
        {
            this.quizContext = new QuizAppContext();
        }

        public async Task AddUser(User user)
        {
            await quizContext.Users.AddAsync(user);
            await quizContext.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            quizContext.Users.Update(user);
            await quizContext.SaveChangesAsync();
        }

        public async Task DeleteUserById(int id)
        {
            var existingUser = await GetUserById(id);

            quizContext.Users.Remove(existingUser);
            await quizContext.SaveChangesAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await quizContext.Users
                .Where(d => d.Id == id)
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var user = await quizContext.Users
                .Where(d => d.Username == username)
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await quizContext.Users.OrderBy(d => d.Username).ToListAsync();
        }

        public async Task<User> FindByName(string username)
        {
            var user = await quizContext.Users.Where(u => u.Username == username).FirstOrDefaultAsync();
            return user;
        }

        public async Task<bool> CheckPassword(User user, string password)
        {
            var hashpassword = new PasswordHasher<User>();
            return hashpassword.VerifyHashedPassword(user, user.PasswordHash, password) == PasswordVerificationResult.Success;
            
        }



    }
}