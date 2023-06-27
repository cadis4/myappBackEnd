using BusinessLogic.DTOS;
using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace BusinessLogic.Services
{
    public class QuizService : IQuizService
    {

        private readonly IQuizRepo quizRepository;

        public QuizService(IQuizRepo quizRepository)
        {
            this.quizRepository = quizRepository;
        }

        public async Task AddQuizAsync(Quiz quiz)
        { 

            await quizRepository.AddQuizAsync(quiz);
        }

        public async Task<IEnumerable<QuizDto>> GetAllQuizzesAsync()
        {
            var quizzesFromDb = await quizRepository.GetAllQuizzesAsync();
            var quizzesDtos = new List<QuizDto>();

            foreach (var quiz in quizzesFromDb)
            {
                var devideTypeDto = new QuizDto
                {
                    QuizId = quiz.QuizId,
                    Name = quiz.Name
                };

                quizzesDtos.Add(devideTypeDto);
            }

            return quizzesDtos;
        }

        public async Task<Quiz> GetQuizByIdAsync(int quizId)
        {
            var quiz = await quizRepository.GetQuizByIdAsync(quizId);

            if (quiz == null)
            {
                return null;
            }

            return quiz;
        }

        public async Task DeleteQuizByIdAsync(int quizId)
        {
            if (quizId == 0)
            {
                throw new ArgumentException("invalid");
            }

            await quizRepository.DeleteQuizByIdAsync(quizId);
        }
    }
}
