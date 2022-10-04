

namespace WizLib_Model.Models
{
    public class Fluent_Personne
    {

        public int Id { get; set; } //REM. : par défaut, EF Core comprendra qu'un champ de model, ayant pour nom "Id" ou "NomDuModeleId", sera le champ PK et auto-increment !
        public string Name { get; set; }


        public Fluent_Sexe Sexe { get; set; }


    }
}
