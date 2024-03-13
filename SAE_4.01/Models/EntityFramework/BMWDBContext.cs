using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Runtime.Intrinsics.X86;

namespace SAE_4._01.Models.EntityFramework
{
    public partial class BMWDBContext : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        public BMWDBContext()
        {
        }

        public BMWDBContext(DbContextOptions<BMWDBContext> options)
            : base(options)
        {
        }

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

                optionsBuilder.UseLoggerFactory(MyLoggerFactory)
                    .EnableSensitiveDataLogging()
                    .UseNpgsql("Server=localhost;port=5432;Database=BMWDB; uid=postgres; password=postgres;");
                //optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Notation>(entity =>
            {
                entity.HasKey(e => new { e.UtilisateurId, e.FilmId })
                    .HasName("pk_not");

                entity.HasOne(d => d.FilmNote)
                    .WithMany(p => p.NotesFilm)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_not_flm");

                entity.HasOne(d => d.UtilisateurNotant)
                    .WithMany(p => p.NotesUtilisateur)
                    .HasForeignKey(d => d.UtilisateurId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_not_utl");
            });

            modelBuilder.Entity<Utilisateur>().Property(e => e.DateCreation).HasDefaultValueSql("now()");
            modelBuilder.Entity<Utilisateur>().Property(e => e.Pays).HasDefaultValue("France");*/

            modelBuilder.Entity<Commande>(entity =>
            {
                entity.HasOne(d => d.ClientCommande)
                    .WithMany(p => p.CommandeClient)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_cmd_clt");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(s => new { s.IdTaille, s.IdColoris, s.IdEquipement })
                    .HasName("pk_stk");

                entity.HasOne(d => d.TailleStock)
                    .WithMany(p => p.StockTaille)
                    .HasForeignKey(d => d.IdTaille)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_stk_tle");

                entity.HasOne(d => d.ColorisStock)
                    .WithMany(p => p.StockColoris)
                    .HasForeignKey(d => d.IdColoris)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_cls_tle");

                entity.HasOne(d => d.EquipementStock)
                    .WithMany(p => p.StockEquipement)
                    .HasForeignKey(d => d.IdEquipement)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_equ_tle");
            });

            modelBuilder.Entity<Garage>(entity =>
            {
                entity.HasKey(g => new { g.IdMotoConfigurable, g.IdClient })
                    .HasName("pk_grg");

                entity.HasOne(d => d.MotoConfigurableGarage)
                    .WithMany(p => p.GarageMotoConfigurable)
                    .HasForeignKey(d => d.IdMotoConfigurable)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_stk_tle");

                entity.HasOne(d => d.ClientGarage)
                    .WithMany(p => p.GarageClient)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_cls_tle");

            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
