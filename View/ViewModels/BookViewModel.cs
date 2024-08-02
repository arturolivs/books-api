using Models;

namespace books_api.View.ViewModels
{
    public class BookViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public string Description { get; set; }
        private Genre GenreEntity { get; set; }
        private Author AuthorEntity { get; set; }

        public string Author
        {
            get
            {
                if (AuthorEntity != null)
                {
                    return $"{AuthorEntity.FirstName} {AuthorEntity.LastName}";
                }
                return "";
            }
        }

        public string Genre
        {
            get
            {
                if (GenreEntity != null)
                {
                    return GenreEntity.Name;
                }
                return "";
            }
        }

        public BookViewModel(Guid id, string title, int publicationYear, string description, Genre genre, Author author)
        {
            Id = id;
            Title = title;
            PublicationYear = publicationYear;
            Description = description;
            GenreEntity = genre;
            AuthorEntity = author;
        }
    }

}
