using Microsoft.AspNetCore.Mvc;
using QuoteWorldAPI.Dtos;
using QuoteWorldAPI.Services.Interfaces;

namespace QuoteWorldAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _quoteService;

        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuotes()
        {
            var quotes = await _quoteService.GetAllQuotesAsync();
            return Ok(quotes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuoteById(int id)
        {
            var quote = await _quoteService.GetQuoteByIdAsync(id);
            if (quote == null)
            {
                return NotFound();
            }
            return Ok(quote);
        }

        [HttpPost]
        public async Task<IActionResult> AddQuote([FromBody] QuoteDto quoteDto)
        {
            await _quoteService.AddQuoteAsync(quoteDto);
            return CreatedAtAction(nameof(GetQuoteById), null, quoteDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuote(int id, [FromBody] QuoteDto quoteDto)
        {
            await _quoteService.UpdateQuoteAsync(quoteDto, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuote(int id)
        {
            await _quoteService.DeleteQuoteAsync(id);
            return NoContent();
        }
    }
}
