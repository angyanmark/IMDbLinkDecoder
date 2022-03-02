namespace IMDbLinkDecoder.Models
{
    public class OutputOptions
    {
        public bool Counter { get; set; }
        public bool Title { get; set; }
        public bool Date { get; set; }
        public bool TMDb { get; set; }
        public bool Link { get; set; }
        public string Separator { get; set; }
    }
}
