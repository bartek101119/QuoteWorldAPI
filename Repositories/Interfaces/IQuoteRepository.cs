using QuoteWorldAPI.Entities;

namespace QuoteWorldAPI.Repositories.Interfaces
{
    public interface IQuoteRepository
    {
        Task<IEnumerable<Quote>> GetAllQuotesAsync();
        Task<Quote> GetQuoteByIdAsync(int id);
        Task AddQuoteAsync(Quote quote);
        Task UpdateQuoteAsync(Quote quote);
        Task DeleteQuoteAsync(int id);
    }
}
