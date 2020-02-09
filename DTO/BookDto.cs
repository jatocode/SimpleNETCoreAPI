namespace SimpleApi 
{
    public class BookDto 
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public int Pages { get; set; }
        public AuthorDto Author { get; set; }
    }
}