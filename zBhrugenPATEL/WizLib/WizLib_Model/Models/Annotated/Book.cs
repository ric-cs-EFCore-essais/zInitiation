using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizLib_Model.Models
{
    public class Book
    {
        [Key] //Mon champ malgré son nommage non reconnu en tant que PK auto-incr., sera alors qd même une PK auto-incr. en base.
        public int Book_Id { get; set; } //REM. : par défaut non reconnu comme PK car, par défaut, EF Core comprend qu'un champ de model, ayant pour nom "Id" ou "NomDuModeleId", est le champ PK et auto-increment !
        
        [Required] //Unauthorized NULL value in Database, for this field
        public string Title { get; set; }


        [Required]
        [MaxLength(15)]
        public string ISBN { get; set; }

            
        [Required]
        [NotMapped] //Ne sera pas ajouté en tant que champ à la table de la base.
        public double Price { get; set; }


        [ForeignKey("Category_Id")] //nom de la FK ici, correspondant à la PK de la table Category :
                                    //REM.: si cette annotation n'était pas mentionnée, la FK créée
                                    //      porterait par défaut donc, le nom de la PK de la table Category. 
        public Category Category { get; set; }


        [Required]
        public Publisher Publisher { get; set; }

        public List<Author> ParticipatingAuthors { get; set; }

    }
}
