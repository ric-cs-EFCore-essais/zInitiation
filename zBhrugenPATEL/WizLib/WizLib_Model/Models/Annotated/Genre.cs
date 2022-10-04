using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizLib_Model.Models
{
    [Table("tb_genres")]
    public class Genre
    {
        public int GenreId { get; set; }  //REM. : par défaut, EF Core comprendra qu'un champ de model, ayant pour nom "Id" ou "NomDuModeleId", sera le champ PK et auto-increment !
        
        [Column("MyNameColumn")]
        public string GenreName { get; set; }

    }
}
