using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizLib_Model.Models
{
    public class Fluent_Publisher
    {
        public int Fluent_PublisherId { get; set; } //REM. : par défaut, EF Core comprendra qu'un champ de model, ayant pour nom "Id" ou "NomDuModeleId", sera le champ PK et auto-increment !

        public string Nom { get; set; }


    }
}
