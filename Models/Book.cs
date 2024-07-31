
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

        [Column("publication_year")]
        public int PublicationYear { get; private set; }

        [Column("description")]
        public string Description { get; private set; }

        public Book(string title, string description, int publicationYear)
        {
            Title = title;
            Description = description;
            PublicationYear = publicationYear;
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetPublicationYear(int year)
        {
            PublicationYear = year;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }
    }
}
