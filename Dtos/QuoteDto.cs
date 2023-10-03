using QuoteWorldAPI.Entities;

namespace QuoteWorldAPI.Dtos
{
    public class QuoteDto
    {
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
        public List<RatingDto> Ratings { get; set; } = new List<RatingDto>();
    }
}
