using Microsoft.EntityFrameworkCore;
using QuoteWorldAPI.Entities;
using QuoteWorldAPI.Repositories.Interfaces;

namespace QuoteWorldAPI.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly QuoteWorldContext _context;

        public QuoteRepository(QuoteWorldContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Quote>> GetAllQuotesAsync()
        {
            return await _context.Quotes
                .Include(q => q.Comments)
                .Include(q => q.Ratings)
                .ToListAsync();
        }

        public async Task<Quote> GetQuoteByIdAsync(int id)
        {
            return await _context.Quotes
                .Include(q => q.Comments)
                .Include(q => q.Ratings)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task AddQuoteAsync(Quote quote)
        {
            await _context.Quotes.AddAsync(quote);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateQuoteAsync(Quote quote)
        {
            _context.Quotes.Update(quote);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuoteAsync(int id)
        {
            var quote = await GetQuoteByIdAsync(id);
            if (quote != null)
            {
                _context.Quotes.Remove(quote);
                await _context.SaveChangesAsync();
            }
        }
    }
}
