using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizLib_Model.Models
{
    public class Publisher
    {
        [Key]
        public int Publisher_Id { get; set; } //REM. : par défaut non reconnu comme PK car, par défaut, EF Core comprend qu'un champ de model, ayant pour nom "Id" ou "NomDuModeleId", est le champ PK et auto-increment !

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }


        public List<Book> Books { get; set; }


    }
}
