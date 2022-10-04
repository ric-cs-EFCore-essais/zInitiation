namespace WizLib_Model.Models
{
    public class Fluent_Sexe
    {

        public int Sexe_Id { get; set; }  //REM. : par défaut non reconnu comme PK car, par défaut, EF Core comprend qu'un champ de model, ayant pour nom "Id" ou "NomDuModeleId", est le champ PK et auto-increment !


        public string Label { get; set; }


    }
}
