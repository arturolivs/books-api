
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
            Title = title;
        }
        public void SetTitle(string title)
        {
            Title = title;
        }
    }
}
