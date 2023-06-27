using BusinessLogic.DTOS;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using BusinessLogicLayer.Services;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using static Azure.Core.HttpHeader;

namespace myappBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService questionService;

        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }

        [HttpPost]
        [Route("addQuestion")]
        public async Task<IActionResult> AddQuestionAsync([FromBody] QuestionDto question)
        {
            if (question == null)
            {
                return BadRequest("Null question. Please provide a valid question !");
            }

            if (string.Equals(question.Name, "string"))
            {
                return BadRequest("Invalid question name. Please provide a valid quiz name !");
            }

            try
            {
                await questionService.AddQuestionAsync(question);

                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        [HttpGet]

        [Route("getAllQuestions")]
        public async Task<IActionResult> GetAllQuestionsAsync()
        {
            try
            {
                var questionDtos = await questionService.GetAllQuestionsAsync();

                return Ok(questionDtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("{questionId}")]
        public async Task<IActionResult> DeleteQuestionByIdAsync(int questionId)
        {
            if (questionId == 0)
            {
                return BadRequest("invalid");
            }

            try
            {
                await questionService.DeleteQuestionByIdAsync(questionId);

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

        [HttpPut]
        [Route("updateQuestion")]
        public async Task<IActionResult> UpdateQuestionAsync([FromBody] QuestionDto questionDto)
        {
            if (questionDto == null)
            {
                return BadRequest("Null!");
            }

            try
            {
                await questionService.UpdateQuestionAsync(questionDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("getQuestion/{id}")]
        public async Task<IActionResult> GetQuestionByIdAsync(int id)
        {
            try
            {
                var user = await questionService.GetQuestionById(id);

                if (user == null)
                {
                    return BadRequest("Not Found");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("getAllQuestionsByQuizName/{name}")]
        public async Task<IActionResult> GetQuestionsByQuizNameAsync(string name)
        {
            try
            {
                var question = await questionService.GetQuestionsByQuizNameAsync(name);

                if (question == null)
                {
                    return BadRequest($"Could not find ");
                }

                return Ok(question);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
