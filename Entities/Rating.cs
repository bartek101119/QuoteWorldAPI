namespace QuoteWorldAPI.Entities
{
    public class Rating : BaseDomainEntities
    {
        public int Value { get; set; }

        public Quote Quote { get; set; }
        public int QuoteId { get; set; }
    }
}
