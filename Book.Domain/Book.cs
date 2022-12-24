using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Books.Domain
{
    public class Book
    {
        public int id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? Year { get; set; }
        public Author? Author { get; set; }
        public int AuthorId { get; set; }
    }
}