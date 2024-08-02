using System.ComponentModel.DataAnnotations.Schema;
using Models;

namespace books_api.View.ViewModels
{
    public class AuthorViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private DateTime RawBirthDate { get; set; }

        public string BirthDate => RawBirthDate.ToString("dd/MM/yyyy");

        public AuthorViewModel(Guid id, string firstName, string lastName, DateTime birthDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            RawBirthDate = birthDate;
        }
    }

}
