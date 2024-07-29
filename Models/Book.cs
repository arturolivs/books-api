
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("books")]
    public class Book
    {
        [Column("id")]
        public Guid Id { get; init; }

        [Column("title")]
        public string Title { get; private set; }

        public Book(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
        }
    }
}
