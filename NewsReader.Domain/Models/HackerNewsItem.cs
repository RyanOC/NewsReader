namespace NewsReader.Domain.Models
{
    public class HackerNewsItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public int Score { get; set; }
        public string Type { get; set; }
        public int Time { get; set; }
    }
}
