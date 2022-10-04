using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizLib_Model.Models
{
    public class Fluent_Book
    {
        public int Book_Id { get; set; }  //REM. : par défaut non reconnu comme PK car, par défaut, EF Core comprend qu'un champ de model, ayant pour nom "Id" ou "NomDuModeleId", est le champ PK et auto-increment !

        public string Title { get; set; }


        public string ISBN { get; set; }

           
        public double Price { get; set; }


        public int PagesNumber { get; set; }

        public string AutreInfo { get; set; }
        public int AutreNumberInfo { get; set; } //NOT nullable en base car pas de type "int?"
        public int? NumberInfoNullable { get; set; } //nullable en base car de type "int?"


        public Fluent_Category Categorie { get; set; }
        public Fluent_Publisher MyPublisher { get; set; }

        public List<Fluent_Page> Pages { get; set; } //Un livre a plusieurs pages, et une page correspond à un seul livre.
                                                     //une FK vers le livre, sera donc AUTOMATIQUEMENT créée dans la table corresp. au model Fluent_Page.

        public List<Fluent_Author> Authors { get; set; } //Un livre peut avoir été écrit par plusieurs auteurs (et vice versa)
                                                         //Une table d'association (Fluent_AuthorFluent_Book) à double PK (PK composée), va donc être créée AUTOMATIQUEMENT.


    }
}
