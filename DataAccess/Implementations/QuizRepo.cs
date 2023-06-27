using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class QuizRepo : IQuizRepo
    {
        public readonly QuizAppContext quizContext;

        public QuizRepo()
        {
            this.quizContext = new QuizAppContext();
        }

        public async Task AddQuizAsync(Quiz quiz)
        {   
            await quizContext.Quizzes.AddAsync(quiz);
            await quizContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Quiz>> GetAllQuizzesAsync()
        {
            return await quizContext.Quizzes.OrderBy(d => d.Name).ToListAsync();
        }

        public async Task<Quiz> GetQuizByIdAsync(int quizId)
        {
            var quiz = await quizContext.Quizzes
                .FirstOrDefaultAsync(d => d.QuizId == quizId);

            return quiz;
        }

        public async Task DeleteQuizByIdAsync(int quizId)
        {
            var existingQuiz = await GetQuizByIdAsync(quizId);

            quizContext.Quizzes.Remove(existingQuiz);
            await quizContext.SaveChangesAsync();
        }
    }
}
