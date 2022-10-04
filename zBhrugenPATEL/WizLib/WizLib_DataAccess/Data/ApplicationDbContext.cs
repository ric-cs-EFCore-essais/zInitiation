using Microsoft.EntityFrameworkCore;


using WizLib_Model.Models;
using WizLib_DataAccess.SomeFluentAPIConfigs;


namespace WizLib_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //--------------------------------------
        public DbSet<Category> Categories { get; set; } //Spécifie qu'il faudra avoir une table de nom Categories, pour y mettre les Entity de type Category.
        public DbSet<Genre> table_Genres { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }


        //---------------------------------------
        public DbSet<Fluent_Book> Fluent_Books { get; set; }

        public DbSet<Fluent_Category> Fluent_Categories { get; set; }

        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }

        public DbSet<Fluent_Page> Fluent_PagesDeLivre { get; set; }
        public DbSet<Fluent_Author> Fluent_AuteursDeLivres { get; set; }

        //---------------------------------------
        public DbSet<Fluent_Personne> tb_Personnes { get; set; }
        public DbSet<Fluent_Sexe> tb_Sexes { get; set; }




        //Fluent API, permet de paramétrer sans passer par des annotations.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //*--- Pour mon modèle Fluent_Book ----*
            //Equivalent de l'annotation [Key]
            modelBuilder.Entity<Fluent_Book>()
                .HasKey(book => book.Book_Id); //Champ Book_Id en tant que PK auto-incr.

            //Equivalent de l'annotation [Required] (NOT NULL en base).
            modelBuilder.Entity<Fluent_Book>()
                .Property(book => book.Title) //Champ
                .IsRequired();                // Obligatoire
            //Equivalent de l'annotation [Required] (NOT NULL en base), et [MaxLength(...)].
            modelBuilder.Entity<Fluent_Book>()
                .Property(book => book.ISBN) //Champ
                .IsRequired()                // Obligatoire
                .HasMaxLength(15);           // et de longueur max. 15 en base (nvarchar(15))

            //Equivalent de l'annotation [NotMapped]
            modelBuilder.Entity<Fluent_Book>()
                .Ignore(book => book.Price);  //Champ du modèle à ne pas créer en base.

            //Equivalent de l'annotation [Column(...)]
            modelBuilder.Entity<Fluent_Book>()
                .Property(book => book.PagesNumber) //Champ du modèle
                .HasColumnName("NumberOfPages"); //Nom du champ corresp. dans la table


            //Equivalent de l'annotation [Required] (NOT NULL en base).
            // Dans la classe Fluent_Book, commme il existe un champ Categorie (de type Fluent_Category),
            // une clef FK (de nom par défaut "CategorieId") va être automatiquement créée dans la table Fluent_Books.
            //             (concaténation du nom du champ dans Fluent_Book, et du nom de la PK dans Fluent_Category)
            //  CEPENDANT, celle-ci sera par défaut nullable en base !
            //   Ici on choisit de spécifier que Categrorie devra être renseignée (not NULL).
            //   Rem. : ci-dessous, HasOne(...) parce-qu'un Fluent_Book a au max. 1 Categorie,
            //          et WithMany() parce-qu'une catégorie peut être affectée à plusieurs Fluent_Book.
            modelBuilder.Entity<Fluent_Book>()
                .HasOne(book => book.Categorie)
                .WithMany()
                //.HasForeignKey("CategorieId") //<<< Pas nécessaire car le nom de la FK corresp. en base, sera bien par défaut celui là.
                .IsRequired() //Rend la FK oon nullable en base !
            ;

            //Equivalent de l'annotation [Required] (NOT NULL en base) et de l'annotation [ForeignKey(...)].
            // Dans la classe Fluent_Book, commme il existe un champ MyPublisher (de type Fluent_Publisher),
            // une clef FK (de nom par défaut "MyPublisherFluentPublisher_Id") va par défaut être automatiquement créée dans la table Fluent_Books.
            //             (concaténation du nom du champ dans Fluent_Book, et du nom de la PK dans Fluent_Publisher)  
            //  CEPENDANT, celle-ci sera par défaut nullable en base !
            //   Ici on choisit de spécifier que MyPublisher devra être renseigné (not NULL).
            //   Rem. : ci-dessous, HasOne(...) parce-qu'un Fluent_Book a au max. 1 Publisher,
            //          et WithMany() parce-qu'un publicateur peut être affecté à plusieurs Fluent_Book.
            // DE PLUS, ici on souhaite que la FK dans la table Fluent_Books, s'appelle "MyPublisher__Id" et non "MyPublisherFluentPublisher_Id" (val. par défaut).
            modelBuilder.Entity<Fluent_Book>()
                .HasOne(book => book.MyPublisher)
                .WithMany()
                .HasForeignKey("MyPublisher__Id") //On souhaite ici, forcer à un autre nommage pour cette FK.
                .IsRequired() //Rend la FK non nullable en base !
            ;


            //*--- Pour mon modèle Fluent_Category ----*
            //Equivalent de l'annotation [Required] (NOT NULL en base).
            modelBuilder.Entity<Fluent_Category>()
                .Property(categ => categ.Name) //Champ
                .IsRequired();                // Obligatoire

            //*--- Pour mon modèle Fluent_Publisher ----*
            //Equivalent de l'annotation [Required] (NOT NULL en base).
            modelBuilder.Entity<Fluent_Publisher>()
                .Property(categ => categ.Nom) //Champ
                .IsRequired();                // Obligatoire

            //*--- Pour mon modèle Fluent_Page ----*
            //On va spécifier que dans la table créée pour le modèle Fluent_Page,
            // la FK (id du livre (FK qui y a été créée automatiquement car dans Fluent_Book on a un champ de type List<Fluent_Page>)),
            // ne sera pas NULLABLE (val. par défaut) et on va également changer son nom (qui par défaut est "Fluent_BookBook_Id"), en "Fluent_Book_Id".
            modelBuilder.Entity<Fluent_Book>() //On part de Fluent_Book, car c'est lui seul qui est le modèle ayant une réf. vers l'autre (List<Fluent_Page>).
                .HasMany(book => book.Pages) //Car Fluent_Book a un membre de type : List<Fluent_Page>
                .WithOne() //Une Fluent_Page ne correspond / n'appartient qu'à un seul Fluent_Book
                .HasForeignKey("Fluent_Book_Id") //On souhaite ici, forcer à un autre nommage pour cette FK.
                .IsRequired();  //Rend la FK non nullable en base !

            //*--- Pour mon modèle Fluent_Author ----*
            modelBuilder.Entity<Fluent_Author>()
                .HasKey("A_Id"); //On précise que ce champ est sa PK auto-incr.

            modelBuilder.Entity<Fluent_Author>()
                .Property(author => author.Nom)
                .IsRequired();




            //===================================================================================================================
            //========== AUTRE FACON de procéder : on met le code de config. utilisant la Fluent API (modelBuilder), ============
            //                                     dans des sources à part, et on invoque ces configs.
            //                                     Exemples :
            //===================================================================================================================
            modelBuilder.ApplyConfiguration(new Personne_FluentAPIConfig());
            modelBuilder.ApplyConfiguration(new Sexe_FluentAPIConfig());

        }

    }
}
