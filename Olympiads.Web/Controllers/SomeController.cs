using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Olympiads.Core.Interfaces;
using Olympiads.Core.Models;
using Olympiads.Core.Providers;

namespace Olympiads.Web.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class SomeController : ControllerBase
    {
        private readonly IEntityDbContext _context;

        public SomeController(IEntityDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize(Policy = "Administrator")]
        public async Task<ActionResult> CreateOlympiad([FromBody] Olympiad olympiad)
        {
            var olympiadProvider = new OlympiadProvider(_context);
            int olympiadId;
            try
            {
                olympiadId = await olympiadProvider.CreateOlympiad(olympiad);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(olympiadId);
        }

        [HttpPost]
        [Authorize(Policy = "Administrator")]
        public async Task<ActionResult> CreateQuestion([FromBody] Question question)
        {
            var questionProvider = new QuestionProvider(_context);
            int questionId;
            try
            {
                questionId = await questionProvider.CraeteQuestion(question);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(questionId);
        }

        [HttpPost]
        public async Task<ActionResult> CreateQuestionAnswer([FromBody] QuestionAnswer answer)
        {
            var questionAnswerProvider = new QuestionAnswerProvider(_context);
            int answerId;
            try
            {
                answerId = await questionAnswerProvider.CreateQuestionAnswer(answer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(answerId);
        }

        [HttpGet]
        public async Task<ActionResult<Olympiad>> GetOlympiad()
        {
            var olympiadProvider = new OlympiadProvider(_context);
            Olympiad olympiad;
            try
            {
                olympiad = await olympiadProvider.GetOlympiad();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(olympiad);
        }
    }
}
