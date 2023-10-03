using AutoMapper;
using QuoteWorldAPI.Dtos;
using QuoteWorldAPI.Entities;
using QuoteWorldAPI.Repositories.Interfaces;
using QuoteWorldAPI.Services.Interfaces;

namespace QuoteWorldAPI.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteRepository _quoteRepository;
        private readonly IMapper _mapper;
        public QuoteService(IQuoteRepository quoteRepository, IMapper mapper)
        {
            _quoteRepository = quoteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuoteDto>> GetAllQuotesAsync()
        {
            var quotes = await _quoteRepository.GetAllQuotesAsync();
            var qutotesDto = _mapper.Map<IEnumerable<QuoteDto>>(quotes);
            return qutotesDto;
        }

        public async Task<QuoteDto> GetQuoteByIdAsync(int id)
        {
            var quote = await _quoteRepository.GetQuoteByIdAsync(id);
            return _mapper.Map<QuoteDto>(quote);
        }

        public async Task AddQuoteAsync(QuoteDto quoteDto)
        {
            var quote = _mapper.Map<Quote>(quoteDto);
            await _quoteRepository.AddQuoteAsync(quote);
        }

        public async Task UpdateQuoteAsync(QuoteDto quoteDto, int id)
        {
            var quote = await _quoteRepository.GetQuoteByIdAsync(id);
            if (quote != null)
            {
                _mapper.Map(quoteDto, quote);
                await _quoteRepository.UpdateQuoteAsync(quote);
            }
            else
            {
                // Obsłuż sytuację, gdy cytat nie istnieje
            }
        }

        public async Task DeleteQuoteAsync(int id)
        {
            await _quoteRepository.DeleteQuoteAsync(id);
        }
    }
}
