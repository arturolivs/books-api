
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("authors")]
    public class Author
    {
        [Column("id")]
        public Guid Id { get; init; }

        [Column("first_name")]
        public string FirstName { get; private set; }

        [Column("last_name")]
        public string LastName { get; private set; }

        [Column("birth_date")]
        public DateTime BirthDate { get; private set; }


        public Author(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public void SetFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            LastName = lastName;
        }

        public void SetBirthDate(DateTime birthDate)
        {
            BirthDate = birthDate;
        }

  
    }
}