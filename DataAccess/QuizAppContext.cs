using DataAccesLayer.Models;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer
{
    public class QuizAppContext : DbContext
    {
        public DbSet<Quiz> Quizzes { get; set; }

        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Server=DESKTOP-MA30UTV\\SQLEXPRESS; Database=QuizDB; Trusted_Connection=True; TrustServerCertificate=True; \r\n");
    }
}