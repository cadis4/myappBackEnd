using BusinessLogic.DTOS;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IQuizService
    {
        Task AddQuizAsync(Quiz quiz);
        Task<IEnumerable<QuizDto>> GetAllQuizzesAsync();
        Task DeleteQuizByIdAsync(int quizId);
        Task<Quiz> GetQuizByIdAsync(int quizId);
    }
}
