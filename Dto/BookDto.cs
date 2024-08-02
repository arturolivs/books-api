using Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace books_api.Dto
{
    public class BookDto
    {
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public string Description { get; set; }
        public Guid GenreId { get; set; }
        public Guid AuthorId { get; set; }
    }
}
