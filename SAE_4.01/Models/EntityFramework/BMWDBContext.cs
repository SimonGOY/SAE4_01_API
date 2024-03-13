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
        public virtual DbSet<ContenuCommande> ContenuCommandes { get; set; } = null!;
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
        public virtual DbSet<Parametres> Parametres { get; set; } = null!;
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
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

                optionsBuilder.UseLoggerFactory(MyLoggerFactory)
                    .EnableSensitiveDataLogging()
                    .UseNpgsql("Server=localhost;port=5432;Database=BMWDB; uid=postgres; password=postgres;");
                //optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accessoire>(entity =>
            {
                entity.HasKey(e => e.IdAccessoire)
                    .HasName("pk_acc");
            });

            modelBuilder.Entity<Adresse>(entity =>
            {
                entity.HasKey(e => e.NumAdresse)
                    .HasName("pk_adr");
            });

            modelBuilder.Entity<Caracteristique>(entity =>
            {
                entity.HasKey(e => e.IdCaracteristique)
                    .HasName("pk_car");

                entity.HasOne(d => d.ModeleMotoCaracteristique)
                    .WithMany(p => p.CaracteristiqueModeleMoto)
                    .HasForeignKey(d => d.IdCaracteristique)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_car_mod");

                entity.HasOne(d => d.CategorieCaracteristiqueCaracteristique)
                    .WithMany(p => p.CaracteristiqueCategorieCaracteristique)
                    .HasForeignKey(d => d.IdCatCaracteristique)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_car_ctc");
            });

            modelBuilder.Entity<CategorieAccessoire>(entity =>
            {
                entity.HasKey(e => e.IdCatAcc)
                    .HasName("pk_cta");
            });

            modelBuilder.Entity<CategorieCaracteristique>(entity =>
            {
                entity.HasKey(e => e.IdCatCaracteristique)
                    .HasName("pk_ctc");
            });

            modelBuilder.Entity<CategorieEquipement>(entity =>
            {
                entity.HasKey(e => e.IdCatEquipement)
                    .HasName("pk_cte");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("pk_clt");
            });

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.HasKey(e => e.IdCollection)
                    .HasName("pk_cln");
            });

            modelBuilder.Entity<Coloris>(entity =>
            {
                entity.HasKey(e => e.IdColoris)
                    .HasName("pk_cls");
            });

            modelBuilder.Entity<Commande>(entity =>
            {
                entity.HasKey(e => e.IdCommande)
                    .HasName("pk_cmd");
            });

            modelBuilder.Entity<Concessionnaire>(entity =>
            {
                entity.HasKey(e => e.IdConcessionnaire)
                    .HasName("pk_con");
            });

            modelBuilder.Entity<ContactInfo>(entity =>
            {
                entity.HasKey(e => e.IdContact)
                    .HasName("pk_ctf");
            });

            modelBuilder.Entity<ContenuCommande>(entity =>
            {
                entity.HasKey(e => new { e.IdEquipement, e.IdTaille, e.IdColoris, e.IdCommande })
                    .HasName("pk_ccm");
            });

            modelBuilder.Entity<Couleur>(entity =>
            {
                entity.HasKey(e => e.IdCouleur)
                    .HasName("pk_clr");
            });

            modelBuilder.Entity<DemandeEssai>(entity =>
            {
                entity.HasKey(e => e.IdDemandeEssai)
                    .HasName("pk_dmd");
            });

            modelBuilder.Entity<Equipement>(entity =>
            {
                entity.HasKey(e => e.IdEquipement)
                    .HasName("pk_equ");
            });

            modelBuilder.Entity<EstInclus>(entity =>
            {
                entity.HasKey(e => new { e.IdOption, e.IdStyle })
                    .HasName("pk_ecl");
            });

            modelBuilder.Entity<EstLie>(entity =>
            {
                entity.HasKey(e => new { e.IdEquipement, e.EquIdEquipement })
                    .HasName("pk_eli");
            });

            modelBuilder.Entity<GammeMoto>(entity =>
            {
                entity.HasKey(e => e.IdGamme)
                    .HasName("pk_gam");
            });

            modelBuilder.Entity<Garage>(entity =>
            {
                entity.HasKey(e => new { e.IdMotoConfigurable, e.IdClient })
                    .HasName("pk_grg");
            });

            modelBuilder.Entity<InfoCB>(entity =>
            {
                entity.HasKey(e => e.IdCarte)
                    .HasName("pk_icb");
            });

            modelBuilder.Entity<Media>(entity =>
            {
                entity.HasKey(e => e.IdMedia)
                    .HasName("pk_med");
            });

            modelBuilder.Entity<ModeleMoto>(entity =>
            {
                entity.HasKey(e => e.IdMoto)
                    .HasName("pk_mod");
            });

            modelBuilder.Entity<MotoConfigurable>(entity =>
            {
                entity.HasKey(e => e.IdMotoConfigurable)
                    .HasName("pk_mcf");
            });

            modelBuilder.Entity<MotoDisponible>(entity =>
            {
                entity.HasKey(e => e.IdMotoDisponible)
                    .HasName("pk_mdp");

                entity.HasOne(d => d.ModeleMotoMotoDisponible)
                    .WithMany(p => p.MotoDisponibleModeleMoto)
                    .HasForeignKey(d => d.IdMotoDisponible)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_mdp_mod");
            });

            modelBuilder.Entity<Offre>(entity =>
            {
                entity.HasKey(e => e.IdOffre)
                    .HasName("pk_ofr");
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.HasKey(e => e.IdOption)
                    .HasName("pk_opt");
            });

            modelBuilder.Entity<Pack>(entity =>
            {
                entity.HasKey(e => e.IdPack)
                    .HasName("pk_pck");
            });

            modelBuilder.Entity<Parametres>(entity =>
            {
                entity.HasKey(e => e.NomParametre)
                    .HasName("pk_par");
            });

            modelBuilder.Entity<Pays>(entity =>
            {
                entity.HasKey(e => e.NomPays)
                    .HasName("pk_pay");
            });

            modelBuilder.Entity<Prefere>(entity =>
            {
                entity.HasKey(e => new { e.IdClient, e.IdConcessionnaire })
                    .HasName("pk_prf");
            });

            modelBuilder.Entity<PresentationEquipement>(entity =>
            {
                entity.HasKey(e => e.IdPresentation)
                    .HasName("pk_pre");
            });

            modelBuilder.Entity<Prive>(entity =>
            {
                entity.HasKey(e => e.IdPrive)
                    .HasName("pk_prv");
            });

            modelBuilder.Entity<Professionnel>(entity =>
            {
                entity.HasKey(e => e.IdPro)
                    .HasName("pk_pro");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.IdReservation)
                    .HasName("pk_res");

                entity.HasOne(d => d.MotoDisponibleReservation)
                    .WithMany(p => p.ReservationMotoDisponible)
                    .HasForeignKey(d => d.IdMotoDisponible)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_mdp_mod");
            });

            modelBuilder.Entity<SeCompose>(entity =>
            {
                entity.HasKey(e => new { e.IdPack, e.IdOption })
                    .HasName("pk_scp");
            });

            modelBuilder.Entity<Specifie>(entity =>
            {
                entity.HasKey(e => new { e.IdMoto, e.IdOption })
                    .HasName("pk_spe");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => new { e.IdTaille, e.IdColoris, e.IdEquipement })
                    .HasName("pk_stk");
            });

            modelBuilder.Entity<Style>(entity =>
            {
                entity.HasKey(e => e.IdStyle)
                    .HasName("pk_sty");
            });

            modelBuilder.Entity<Taille>(entity =>
            {
                entity.HasKey(e => e.IdTaille)
                    .HasName("pk_tle");
            });

            modelBuilder.Entity<Telephone>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("pk_tel");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.IdTransaction)
                    .HasName("pk_tct");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("pk_usr");
            });

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

            modelBuilder.Entity<Prefere>(entity =>
            {
                entity.HasKey(e => new { e.IdClient, e.IdConcessionnaire })
                    .HasName("pk_prf");
                entity.HasOne(d => d.ClientPrefere)
                    .WithMany(p => p.PrefereClient)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_prf_clt");

                entity.HasOne(d => d.ConcessionnairePrefere)
                    .WithMany(p => p.PrefereConcessionnaire)
                    .HasForeignKey(d => d.IdConcessionnaire)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_prf_con");
            });


            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasOne(d => d.CommandeTransaction)
                    .WithMany(p => p.TransactionCommande)
                    .HasForeignKey(d => d.IdCommande)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_tct_cmd");
            });

            modelBuilder.Entity<ContactInfo>(entity =>
            {
                entity.HasOne(d => d.OffreContactInfo)
                    .WithMany(p => p.ContactInfoOffre)
                    .HasForeignKey(d => d.IdOffre)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_ctf_ofr");
            });

            modelBuilder.Entity<Offre>(entity =>
            {
                entity.HasOne(d => d.MotoConfigurableOffre)
                    .WithMany(p => p.OffreMotoConfigurable)
                    .HasForeignKey(d => d.IdMotoConfigurable)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_ofr_mcf");

                entity.HasOne(d => d.ConcessionnaireOffre)
                  .WithMany(p => p.OffreConcessionnaire)
                  .HasForeignKey(d => d.IdConcessionnaire)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("fk_ofr_con");
            });

            modelBuilder.Entity<Adresse>(entity =>
            {
                entity.HasOne(d => d.PaysAdresse)
                    .WithMany(p => p.AdressePays)
                    .HasForeignKey(d => d.NomPays)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_adr_pay");
            });

            modelBuilder.Entity<InfoCB>(entity =>
            {
                entity.HasOne(d => d.ClientInfoCB)
                    .WithMany(p => p.InfoCBClient)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_icb_clt");
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
                    .HasConstraintName("fk_stk_cls");

                entity.HasOne(d => d.EquipementStock)
                    .WithMany(p => p.StockEquipement)
                    .HasForeignKey(d => d.IdEquipement)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_stk_equ");
            });

            modelBuilder.Entity<Garage>(entity =>
            {
                entity.HasKey(g => new { g.IdMotoConfigurable, g.IdClient })
                    .HasName("pk_grg");

                entity.HasOne(d => d.MotoConfigurableGarage)
                    .WithMany(p => p.GarageMotoConfigurable)
                    .HasForeignKey(d => d.IdMotoConfigurable)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_grg_mcf");

                entity.HasOne(d => d.ClientGarage)
                    .WithMany(p => p.GarageClient)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_grg_clt");

            });

            modelBuilder.Entity<Professionnel>(entity =>
            {

                entity.HasOne(d => d.ClientProfessionnel)
                    .WithMany(p => p.ProfessionnelClient)
                    .HasForeignKey(d => d.IdPro)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_pro_clt");

            });

            modelBuilder.Entity<Prive>(entity =>
            {

                entity.HasOne(d => d.ClientPrive)
                    .WithMany(p => p.PriveClient)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_prv_clt");

            });

            modelBuilder.Entity<Users>(entity =>
            {

                entity.HasOne(d => d.ClientUsers)
                    .WithMany(p => p.UsersClient)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_usr_clt");

            });

            modelBuilder.Entity<Client>(entity =>
            {

                entity.HasOne(d => d.AdresseClient)
                    .WithMany(p => p.ClientAdresse)
                    .HasForeignKey(d => d.NumAdresse)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_clt_adr");

            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
