using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WizLib_Model.Models;

namespace WizLib_DataAccess.SomeFluentAPIConfigs
{
    public class Personne_FluentAPIConfig : IEntityTypeConfiguration<Fluent_Personne>
    {
        public void Configure(EntityTypeBuilder<Fluent_Personne> entityModelBuilder)
        {
            //----- Config. pour la table des personnes -----

            entityModelBuilder
                .Property(pers => pers.Name) //Champ
                .IsRequired();               // Obligatoire

            entityModelBuilder
                .HasOne(pers => pers.Sexe) //1 personne n'est associée qu'à un seul sexe
                .WithMany() //Car a un type de sexe peut correspondre plusieurs personnes
                .HasForeignKey("TheSexeId") //Forçage du nom par défaut de la FK(vers table des sexes), qui sera créée dans la table des personnes.
                .IsRequired(); //Le sexe de la perosnne doit obligatoirement être renseigné (NOT NULL en base)
        }
    }
}
