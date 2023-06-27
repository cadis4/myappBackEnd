using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IQuizRepo
    {
        Task AddQuizAsync(Quiz quiz);
        Task<IEnumerable<Quiz>> GetAllQuizzesAsync();
        Task DeleteQuizByIdAsync(int quizId);
        Task<Quiz> GetQuizByIdAsync(int quizId);
    }
}
