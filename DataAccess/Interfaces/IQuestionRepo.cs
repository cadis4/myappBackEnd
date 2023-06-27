using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IQuestionRepo
    {
        Task AddQuestionAsync(Question question);
        Task<IEnumerable<Question>> GetAllQuestionsAsync();
        Task DeleteQuestionByIdAsync(int questionId);
        Task<Question> GetQuestionByIdAsync(int questionId);
        Task<IEnumerable<Question>> GetQuestionsByQuizNameAsync(string name);
        Task UpdateQuestionAsync(Question question);


    }
}
