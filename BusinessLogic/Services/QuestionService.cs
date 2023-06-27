using BusinessLogic.DTOS;
using BusinessLogic.Interfaces;
using DataAccesLayer.Models;
using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccessLayer.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;
using static System.Collections.Specialized.BitVector32;

namespace BusinessLogic.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepo questionRepository;
        private readonly IQuizService questionService;

        public QuestionService(IQuestionRepo questionRepository)
        {
            this.questionRepository = questionRepository;
        }

        public async Task AddQuestionAsync(QuestionDto questionDto)
        {
            var question = new Question();

            question.QuestionId = questionDto.QuestionId;
            question.AnswerOne = questionDto.AnswerOne;
            question.AnswerTwo = questionDto.AnswerTwo;
            question.AnswerThree = questionDto.AnswerThree;
            question.AnswerFour = questionDto.AnswerFour;
            question.QuizId = questionDto.Quiz.QuizId;
            question.VerifyAnswer = questionDto.VerifyAnswer;
            question.CorrectAnswer = questionDto.CorrectAnswer;
            question.Name = questionDto.Name;

            await questionRepository.AddQuestionAsync(question);
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            var questionsFromDb = await questionRepository.GetAllQuestionsAsync();
            var questions = new List<Question>();

            foreach (var question in questionsFromDb)
            {
                questions.Add(question);
            };

            return questions;
        }

        public async Task<Question> GetQuestionByIdAsync(int questionId)
        {
            var question = await questionRepository.GetQuestionByIdAsync(questionId);

            if (question == null)
            {
                return null;
            }

            return question;
        }

        public async Task<IEnumerable<Question>> GetQuestionsByQuizNameAsync(string name)
        {
            var question = await questionRepository.GetQuestionsByQuizNameAsync(name);

            if (question == null)
            {
                return null;
            }

            return question;
        }

        public async Task DeleteQuestionByIdAsync(int questionId)
        {
            if (questionId == 0)
            {
                throw new ArgumentException("invalid");
            }

            await questionRepository.DeleteQuestionByIdAsync(questionId);
        }

        public async Task UpdateQuestionAsync(QuestionDto questionDto)
        {
            var questionupdated = new Question
            {
               AnswerFour=questionDto.AnswerFour,
               AnswerOne=questionDto.AnswerOne,
               AnswerTwo=questionDto.AnswerTwo,
               AnswerThree=questionDto.AnswerThree,
               Name=questionDto.Name,
               Quiz=questionDto.Quiz,
               CorrectAnswer=questionDto.CorrectAnswer,
               VerifyAnswer=questionDto.VerifyAnswer,
               QuestionId=questionDto.QuestionId
            };

            await questionRepository.UpdateQuestionAsync(questionupdated);
        }

        public async Task<Question> GetQuestionById(int id)
        {
            var question = await questionRepository.GetQuestionByIdAsync(id);

            if (question == null) return null;

            return question;
        }
    }

}
