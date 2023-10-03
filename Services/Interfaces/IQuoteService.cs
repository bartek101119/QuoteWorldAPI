using QuoteWorldAPI.Dtos;
using QuoteWorldAPI.Entities;

namespace QuoteWorldAPI.Services.Interfaces
{
    public interface IQuoteService
    {
        Task<IEnumerable<QuoteDto>> GetAllQuotesAsync();
        Task<QuoteDto> GetQuoteByIdAsync(int id);
        Task AddQuoteAsync(QuoteDto quote);
        Task UpdateQuoteAsync(QuoteDto quote, int id);
        Task DeleteQuoteAsync(int id);
    }
}
