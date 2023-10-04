namespace QuoteWorldAPI.Entities
{
    public class Comment : BaseDomainEntities
    {
        public string Text { get; set; }
        public Quote Quote { get; set; }
        public int QuoteId { get; set; }

    }
}
