using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WizLib_Model.Models;

namespace WizLib_DataAccess.SomeFluentAPIConfigs
{
    public class Sexe_FluentAPIConfig : IEntityTypeConfiguration<Fluent_Sexe>
    {
        public void Configure(EntityTypeBuilder<Fluent_Sexe> entityModelBuilder)
        {
            //----- Config. pour la table des sexes -----

            entityModelBuilder
                .HasKey("Sexe_Id"); //On précise que ce champ du modèle Fluent_Sexe, est la PK auto-increment.

            entityModelBuilder
                .Property(sx => sx.Label) //Champ
                .IsRequired();            // Obligatoire

        }
    }
}
