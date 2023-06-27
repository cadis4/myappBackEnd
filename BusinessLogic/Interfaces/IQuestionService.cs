using BusinessLogic.DTOS;
using DataAccesLayer.Models;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IQuestionService
    {
        Task AddQuestionAsync(QuestionDto questionDto);
        Task<IEnumerable<Question>> GetAllQuestionsAsync();
        Task DeleteQuestionByIdAsync(int questionId);
        Task<Question> GetQuestionByIdAsync(int questionId);

        Task<IEnumerable<Question>> GetQuestionsByQuizNameAsync(string name);
        Task UpdateQuestionAsync(QuestionDto questionDto);

        Task<Question> GetQuestionById(int id);
    }
}
