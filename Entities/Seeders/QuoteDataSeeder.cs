namespace QuoteWorldAPI.Entities.Seeders
{
    public class QuoteDataSeeder
    {
        private readonly QuoteWorldContext _context;
        private readonly ILogger<QuoteDataSeeder> _logger;
        public QuoteDataSeeder(QuoteWorldContext context, ILogger<QuoteDataSeeder> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void SeedData()
        {
            if (_context.Database.CanConnect())
            {
                if (!_context.Quotes.Any())
                {
                    try
                    {
                        var quote = new Quote
                        {
                            Text = "Pomyliłeś niebo z gwiazdami odbitymi nocą na powierzchni stawu.",
                            Comments = new List<Comment>
                        {
                            new Comment
                            {
                                Text = "Często powtarzane zdanie przez Sapkowskiego"
                            }
                        },
                            Ratings = new List<Rating>
                        {
                            new Rating
                            {
                                Value = 5
                            }
                        }
                        };

                        _context.Quotes.Add(quote);
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Something went wrong");
                    }

                }
            }
        }
    }
}
