using BusinessLogic.DTOS;
using BusinessLogicLayer.Interfaces;
using DataAccesLayer.Models;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Identity;


namespace BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo UserRepo;

        public UserService(IUserRepo UserRepo)
        {
            this.UserRepo = UserRepo;
        }

        public async Task AddUser(UserDto user)
        {
            var User = new User
            {
                Username = user.Username,
                PasswordHash = HashPassword(user.Password),
                Role = user.Role,
                lastScoreAE = 0,
                maxScoreAE = 0,
                lastScorePseudocod = 0,
                maxScorePseudocod = 0,
                lastScoreBD = 0,
                maxScoreBD = 0,
                lastScoreCpp = 0,
                maxScoreCpp = 0,
                lastScoreTB = 0,
                maxScoreTB = 0,
                lastScoreRec = 0,
                maxScoreRec = 0,
                lastScoreSC = 0,
                maxScoreSC = 0,
                lastScoreTU = 0,
                maxScoreTU = 0,
                AEPassed = false,
                BDPassed = false,
                cppPassed = false,
                pseudocodPassed = false,
                TBPassed = false,
                TUPassed = false,
                recPassed = false

            };

            await UserRepo.AddUser(User);
        }

        public async Task UpdateUser(UserDto user)
        {
            var userUpdated = new User
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role,
                PasswordHash = HashPassword(user.Password)
              ,
            };

            await UserRepo.UpdateUser(userUpdated);
        }

        public async Task UpdateUserGrades(UserDtoGrades user)
        {
            var userUpdated = new User
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role,
                Password = user.Password,
                PasswordHash = user.PasswordHash,
                lastScoreAE=user.lastScoreAE,
                maxScoreAE=user.maxScoreAE,
                lastScorePseudocod=user.lastScorePseudocod,
                maxScorePseudocod=user.maxScorePseudocod,
                lastScoreBD=user.lastScoreBD,
                maxScoreBD=user.lastScoreBD,
                lastScoreCpp=user.lastScoreCpp,
                maxScoreCpp=user.maxScoreCpp,
                lastScoreTB=user.lastScoreTB,
                maxScoreTB=user.maxScoreTB,
                lastScoreRec=user.lastScoreRec,
                maxScoreRec=user.maxScoreRec,
                lastScoreSC=user.maxScoreSC,
                maxScoreSC=user.maxScoreSC,
                lastScoreTU=user.lastScoreTU,
                AEPassed = user.AEPassed,
                BDPassed = user.BDPassed,
                cppPassed = user.cppPassed,
                pseudocodPassed = user.pseudocodPassed,
                TBPassed = user.TBPassed,
                TUPassed = user.TUPassed,
                recPassed = user.recPassed,
                SCPassed = user.SCPassed
              ,
            };

            await UserRepo.UpdateUser(userUpdated);
        }

        public async Task<bool> IsUsernameTaken(string username)
        {
            var user = await UserRepo.GetUserByUsername(username);
            return user != null;
        }

        public async Task DeleteUserById(int id)
        {
            await UserRepo.DeleteUserById(id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var userExistent = await UserRepo.GetAllUsers();
            var users = new List<User>();

            foreach (var user in userExistent)
            {
                users.Add(user);
            }

            return users;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await UserRepo.GetUserById(id);

            if (user == null) return null;

            return user;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var user = await UserRepo.GetUserByUsername(username);

            if (user == null) return null;

            return user;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await UserRepo.FindByName(username);
            if (user != null && await UserRepo.CheckPassword(user, password))
            {
               
                return user;
            }

            return null;
        }

        private string HashPassword(string password)
        {
            var hashpassword = new PasswordHasher<User>();
            return hashpassword.HashPassword(null, password);
        }

    }
}
