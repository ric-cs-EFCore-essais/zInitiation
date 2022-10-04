using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizLib_Model.Models
{
    public class Fluent_Page //Page de livre
    {
        public int Id { get; set; } //REM. : par défaut, EF Core comprendra qu'un champ de model, ayant pour nom "Id" ou "NomDuModeleId", sera le champ PK et auto-increment !
        public int Numero { get; set; }

        public string Contenu { get; set; }

    }
}
