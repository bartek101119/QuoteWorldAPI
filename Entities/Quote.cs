namespace QuoteWorldAPI.Entities
{
    public class Quote : BaseDomainEntities
    {
        public string Text { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
