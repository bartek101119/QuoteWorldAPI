namespace QuoteWorldAPI.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        public Quote Quote { get; set; }
        public int QuoteId { get; set; }

    }
}
