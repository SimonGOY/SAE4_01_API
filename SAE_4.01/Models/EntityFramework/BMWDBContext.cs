using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SAE_4._01.Models.EntityFramework
{
    public partial class BMWDBContext : DbContext
    {
        public BMWDBContext() { }
        public BMWDBContext(DbContextOptions<BMWDBContext> options)
            : base(options) { }

        public virtual DbSet<Accessoire> Accessoires { get; set; } = null!;
        public virtual DbSet<Adresse> Adresses { get; set; } = null!;
        public virtual DbSet<Caracteristique> Caracteristiques { get; set; } = null!;
        public virtual DbSet<CategorieAccessoire> CategorieAccessoires { get; set; } = null!;
        public virtual DbSet<CategorieCaracteristique> CategorieCaracteristiques { get; set; } = null!;
        public virtual DbSet<CategorieEquipement> CategorieEquipements { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Collection> Collections { get; set; } = null!;
        public virtual DbSet<Coloris> LesColoris { get; set; } = null!;
        public virtual DbSet<Commande> Commandes { get; set; } = null!;
        public virtual DbSet<Concessionnaire> Concessionnaires { get; set; } = null!;
        public virtual DbSet<ContactInfo> ContactInfos { get; set; } = null!;
        public virtual DbSet<Couleur> Couleurs { get; set; } = null!;
        public virtual DbSet<DemandeEssai> DemandeEssais { get; set; } = null!;
        public virtual DbSet<Equipement> Equipements { get; set; } = null!;
        public virtual DbSet<EstInclus> SontInclus { get; set; } = null!;
        public virtual DbSet<EstLie> SontLies { get; set; } = null!;
        public virtual DbSet<GammeMoto> GammeMotos { get; set; } = null!;
        public virtual DbSet<Garage> Garages { get; set; } = null!;
        public virtual DbSet<InfoCB> InfoCBs { get; set; } = null!;
        public virtual DbSet<Media> Medias { get; set; } = null!;
        public virtual DbSet<ModeleMoto> ModeleMotos { get; set; } = null!;
        public virtual DbSet<MotoConfigurable> MotoConfigurables { get; set; } = null!;
        public virtual DbSet<MotoDisponible> MotoDisponibles { get; set; } = null!;
        public virtual DbSet<Offre> Offres { get; set; } = null!;
        public virtual DbSet<Option> Options { get; set; } = null!;
        public virtual DbSet<Pack> Packs { get; set; } = null!;
        public virtual DbSet<Pays> LesPays { get; set; } = null!;
        public virtual DbSet<Prefere> Preferes { get; set; } = null!;
        public virtual DbSet<PresentationEquipement> PresentationEquipements { get; set; } = null!;
        public virtual DbSet<Prive> Prives { get; set; } = null!;
        public virtual DbSet<Professionnel> Professionnels { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<SeCompose> SeComposes { get; set; } = null!;
        public virtual DbSet<Specifie> Specifies { get; set; } = null!;
        public virtual DbSet<Stock> Stocks { get; set; } = null!;
        public virtual DbSet<Style> Styles { get; set; } = null!;
        public virtual DbSet<Taille> Tailles { get; set; } = null!;
        public virtual DbSet<Telephone> Telephones { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<Users> LesUsers { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
