
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("genres")]
    public class Genre
    {
        [Column("id")]
        public Guid Id { get; init; }

        [Column("name")]
        public string Name { get; private set; }

        public Genre(string name)
        {
            Name = name;
        }

        public void SetName(string name)
        {
            Name = name;
        }
    }
}