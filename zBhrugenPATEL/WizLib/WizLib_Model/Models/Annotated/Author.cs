using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizLib_Model.Models
{
    public class Author
    {
        [Key]
        public int Author_Id { get; set; } //REM. : par défaut non reconnu comme PK car, par défaut, EF Core comprend qu'un champ de model, ayant pour nom "Id" ou "NomDuModeleId", est le champ PK et auto-increment !

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; } //Une DateTime est quand même NOT NUILL en base <<<<

        public string Location { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }


        public List<Book> ParticipatedBooks { get; set; }


    }
}
