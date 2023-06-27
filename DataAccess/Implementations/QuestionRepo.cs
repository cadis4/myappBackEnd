using DataAccesLayer.Models;
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
    public class QuestionRepo : IQuestionRepo
    {
        public readonly QuizAppContext quizContext;

        public QuestionRepo()
        {
            this.quizContext = new QuizAppContext();
        }

        public async Task AddQuestionAsync(Question question)
        {
            await quizContext.Questions.AddAsync(question);
            await quizContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            return await quizContext.Questions.OrderBy(d => d.Name).Include(d => d.Quiz).ToListAsync();
        }

        public async Task DeleteQuestionByIdAsync(int questionId)
        {
            var existingQuestion = await GetQuestionByIdAsync(questionId);

            quizContext.Questions.Remove(existingQuestion);
            await quizContext.SaveChangesAsync();
        }

        public async Task<Question> GetQuestionByIdAsync(int questionId)
        {
            var question = await quizContext.Questions
                .Include(d => d.Quiz)
                .FirstOrDefaultAsync(d => d.QuestionId == questionId);

            return question;
        }

        public async Task<IEnumerable<Question>> GetQuestionsByQuizNameAsync(string name)
        {
            var question = await quizContext.Questions
                .Include(d => d.Quiz).Where(d => d.Quiz.Name == name).
                ToListAsync();

            return question;
        }

        public async Task UpdateQuestionAsync(Question question)
        {
            quizContext.Questions.Update(question);
            await quizContext.SaveChangesAsync();
        }


    }
}
