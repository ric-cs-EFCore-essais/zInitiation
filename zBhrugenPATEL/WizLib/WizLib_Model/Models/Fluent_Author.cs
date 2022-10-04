using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizLib_Model.Models
{
    public class Fluent_Author //Auteur de livreS
    {
        public int A_Id { get; set; }   //REM. : par défaut non reconnu comme PK car, par défaut, EF Core comprend qu'un champ de model, ayant pour nom "Id" ou "NomDuModeleId", est le champ PK et auto-increment !
        public string Nom { get; set; }


        public List<Fluent_Book> Livres { get; set; }  //Un auteur peut avoir écrit plusieurs livres (et vice versa)
                                                       //Une table d'association (Fluent_AuthorFluent_Book) à double PK (PK composée), va donc être créée AUTOMATIQUEMENT.

    }
}
