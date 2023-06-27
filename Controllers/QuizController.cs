using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebRestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService quizService;

        public QuizController(IQuizService quiz)
        {
            this.quizService = quiz;
        }

        [HttpPost]
        public async Task<IActionResult> AddQuizAsync([FromBody] Quiz quiz)
        {
            if (quiz == null)
            {
                return BadRequest("Null quiz. Please provide a valid quiz !");
            }

            if (string.Equals(quiz.Name, "string"))
            {
                return BadRequest("Invalid quiz name. Please provide a valid quiz name !");
            }

            try
            {
                await quizService.AddQuizAsync(quiz);

                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        [HttpGet]
        [Route("getAllQuizzes")]
        public async Task<IActionResult> GetAllQuizzesAsync()
        {
            try
            {
                var quizDtos = await quizService.GetAllQuizzesAsync();

                return Ok(quizDtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("{quizId}")]
        public async Task<IActionResult> DeleteQuizByIdAsync(int quizId)
        {
            if (quizId == 0)
            {
                return BadRequest("invalid");
            }

            try
            {
                await quizService.DeleteQuizByIdAsync(quizId);

                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
