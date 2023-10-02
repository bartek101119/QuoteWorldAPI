namespace QuoteWorldAPI.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime CreatedAt { get; set; }

        public Quote Quote { get; set; }
        public int QuoteId { get; set; }
    }
}
