



using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data;
using System.Runtime.Intrinsics.X86;
using System.Security.Policy;

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
        public virtual DbSet<Option> Options { get; set; } = null!;
        public virtual DbSet<Pack> Packs { get; set; } = null!;
        public virtual DbSet<Parametre> Parametres { get; set; } = null!;
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
        public virtual DbSet<User> LesUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("bmw");

            modelBuilder.Entity<Accessoire>(entity =>
            {
                entity.HasKey(e => e.IdAccessoire)
                    .HasName("pk_acc");

                entity.HasOne(d => d.CateAccessoire)
                    .WithMany(p => p.AccessoireCategorise)
                    .HasForeignKey(d => d.IdCatAcc)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_acc_cta");
                entity.HasOne(d => d.ModeleAccessoire)
                    .WithMany(p => p.AccessoireMoto)
                    .HasForeignKey(d => d.IdMoto)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_acc_mod");

                entity.HasAlternateKey(e => e.NomAccessoire);
            });

            modelBuilder.Entity<Adresse>(entity =>
            {
                entity.HasKey(e => e.NumAdresse)
                    .HasName("pk_adr");

                entity.HasOne(d => d.PaysAdresse)
                    .WithMany(p => p.AdressePays)
                    .HasForeignKey(d => d.NomPays)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_adr_pay");
            });

            modelBuilder.Entity<Caracteristique>(entity =>
            {
                entity.HasKey(e => e.IdCaracteristique)
                    .HasName("pk_car");

                entity.HasOne(d => d.ModeleMotoCaracteristique)
                    .WithMany(p => p.CaracteristiqueModeleMoto)
                    .HasForeignKey(d => d.IdMoto)
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

                entity.HasAlternateKey(e => e.NomCatAcc);
            });

            modelBuilder.Entity<CategorieCaracteristique>(entity =>
            {
                entity.HasKey(e => e.IdCatCaracteristique)
                    .HasName("pk_ctc");

                entity.HasAlternateKey(e => e.NomCatCaracteristique);
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

                entity.HasOne(d => d.AdresseClient)
                    .WithMany(p => p.ClientAdresse)
                    .HasForeignKey(d => d.NumAdresse)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_clt_adr");

                entity.HasCheckConstraint("ck_clt_age", "age((clt_datenaissance)::timestamp with time zone) >= '18 years'::interval");
                entity.HasCheckConstraint("ck_clt_email", "clt_email ~~ '%_@__%.__%'::text");
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

                entity.HasAlternateKey(e => e.NomColoris);
            });

            modelBuilder.Entity<Commande>(entity =>
            {
                entity.HasKey(e => e.IdCommande)
                    .HasName("pk_cmd");

                entity.HasOne(d => d.ClientCommande)
                    .WithMany(p => p.CommandeClient)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_cmd_clt");
            });

            modelBuilder.Entity<Concessionnaire>(entity =>
            {
                entity.HasKey(e => e.IdConcessionnaire)
                    .HasName("pk_con");

                entity.HasCheckConstraint("ck_con_email", "(con_email)::text ~~ '%_@__%.__%'::text");
                entity.HasCheckConstraint("ck_con_telephone","(con_telephone)::text ~'^(01|02|03|04|05|09)\\d{8}$'::text");

                entity.HasAlternateKey(e => e.NomConcessionnaire);
            });

            modelBuilder.Entity<ContactInfo>(entity =>
            {
                entity.HasKey(e => e.IdContact)
                    .HasName("pk_ctf");

                entity.HasCheckConstraint("ck_ctf_datenaissance", "age((ctf_datenaissance)::timestamp with time zone) >= '18 years'::interval");
                entity.HasCheckConstraint("ck_ctf_email", "(ctf_email)::text ~~'%_@__%.__%'::text");
            });

            modelBuilder.Entity<ContenuCommande>(entity =>
            {
                entity.HasKey(e => new { e.IdEquipement, e.IdTaille, e.IdColoris, e.IdCommande })
                    .HasName("pk_ccm");

                entity.HasOne(d => d.EquipementContenuCommande)
                    .WithMany(p => p.ContenuCommandeEquipement)
                    .HasForeignKey(d => d.IdEquipement)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_ccm_equ");

                entity.HasOne(d => d.TailleContenuCommande)
                    .WithMany(p => p.ContenuCommandeTaille)
                    .HasForeignKey(d => d.IdTaille)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_ccm_tle");

                entity.HasOne(d => d.ColorisContenuCommande)
                    .WithMany(p => p.ContenuCommandeColoris)
                    .HasForeignKey(d => d.IdColoris)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_ccm_cls");

                entity.HasOne(d => d.CommandeContenuCommande)
                    .WithMany(p => p.ContenuCommandeCommande)
                    .HasForeignKey(d => d.IdCommande)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_ccm_cmd");
            });

            modelBuilder.Entity<Couleur>(entity =>
            {
                entity.HasKey(e => e.IdCouleur)
                    .HasName("pk_clr");

                entity.HasOne(d => d.ModeleMotoCouleur)
                    .WithMany(p => p.CouleurModeleMoto)
                    .HasForeignKey(d => d.IdMoto)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_clr_mod");

                entity.HasAlternateKey(e => new { e.NomCouleur, e.DescriptionCouleur});
            });

            modelBuilder.Entity<DemandeEssai>(entity =>
            {
                entity.HasKey(e => e.IdDemandeEssai)
                    .HasName("pk_dmd");

                entity.HasOne(d => d.ConcessionnaireDemandeEssai)
                    .WithMany(p => p.DemandeEssaiConcessionnaire)
                    .HasForeignKey(d => d.IdConcessionnaire)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_dmd_con");
                entity.HasOne(d => d.ModeleMotoDemandeEssai)
                    .WithMany(p => p.DemandeEssaiModeleMoto)
                    .HasForeignKey(d => d.IdMoto)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_dmd_mod");
                entity.HasOne(d => d.ContactInfoDemandeEssai)
                    .WithMany(p => p.DemandeEssaiContactInfo)
                    .HasForeignKey(d => d.IdContact)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_dmd_ctf");
            });

            modelBuilder.Entity<Equipement>(entity =>
            {
                entity.HasKey(e => e.IdEquipement)
                    .HasName("pk_equ");

                entity.HasOne(d => d.CollectionEquipement)
                    .WithMany(p => p.EquipementCollection)
                    .HasForeignKey(d => d.IdCollection)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_equ_cln");
                entity.HasOne(d => d.CategorieEquipementEquipement)
                    .WithMany(p => p.EquipementCategorieEquipement)
                    .HasForeignKey(d => d.IdCatEquipement)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_equ_cte");

                entity.HasCheckConstraint("ck_eq_sexe", "(((equ_sexe)::text = 'f'::text) OR ((equ_sexe)::text = 'h'::text) OR ((equ_sexe)::text = 'uni'::text))");
            });

            modelBuilder.Entity<EstInclus>(entity =>
            {
                entity.HasKey(e => new { e.IdOption, e.IdStyle })
                    .HasName("pk_ecl");
                entity.HasOne(d => d.OptionEstInclus)
                    .WithMany(p => p.EstInclusOption)
                    .HasForeignKey(d => d.IdOption)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_ecl_opt");
                entity.HasOne(d => d.StyleEstInclus)
                    .WithMany(p => p.EstInclusStyle)
                    .HasForeignKey(d => d.IdStyle)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_ecl_sty");
            });

            modelBuilder.Entity<EstLie>(entity =>
            {
                entity.HasKey(e => new { e.IdEquipement, e.EquIdEquipement })
                    .HasName("pk_eli");

                entity.HasOne(d => d.EquipementEstLie1)
                    .WithMany(p => p.EstLieEquipement1)
                    .HasForeignKey(d => d.IdEquipement)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_eli_equ");
                /*entity.HasOne(d => d.EquipementEstLie2)
                    .WithMany(p => p.EstLieEquipement2)
                    .HasForeignKey(d => d.IdEquipement)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_eli_equ");*/
            });

            modelBuilder.Entity<GammeMoto>(entity =>
            {
                entity.HasKey(e => e.IdGamme)
                    .HasName("pk_gam");

                entity.HasAlternateKey(e => e.LibelleGamme);
            });

            modelBuilder.Entity<Garage>(entity =>
            {
                entity.HasKey(e => new { e.IdMotoConfigurable, e.IdClient })
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

            modelBuilder.Entity<InfoCB>(entity =>
            {
                entity.HasKey(e => e.IdCarte)
                    .HasName("pk_icb");

                entity.HasOne(d => d.ClientInfoCB)
                    .WithMany(p => p.InfoCBClient)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_icb_clt");
            });

            modelBuilder.Entity<Media>(entity =>
            {
                entity.HasKey(e => e.IdMedia)
                    .HasName("pk_med");

                entity.HasOne(d => d.EquipementMedia)
                    .WithMany(p => p.MediaEquipement)
                    .HasForeignKey(d => d.IdEquipement)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_med_equ");
                entity.HasOne(d => d.ModeleMotoMedia)
                    .WithMany(p => p.MediaModeleMoto)
                    .HasForeignKey(d => d.IdMoto)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_med_mod");
                entity.HasOne(d => d.PresentationEquipementMedia)
                    .WithMany(p => p.MediaPresentationEquipement)
                    .HasForeignKey(d => d.IdPresentation)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_med_pre");

                entity.HasCheckConstraint("chk_exclusive_id", "((mod_idmoto IS NOT NULL AND equ_idequipement IS NULL) OR (mod_idmoto IS NULL AND equ_idequipement IS NOT NULL))");

                entity.HasAlternateKey(e => e.LienMedia);
            });

            modelBuilder.Entity<ModeleMoto>(entity =>
            {
                entity.HasKey(e => e.IdMoto)
                    .HasName("pk_mod");

                entity.HasOne(d => d.GammeMotoModeleMoto)
                    .WithMany(p => p.ModeleMotoGammeMoto)
                    .HasForeignKey(d => d.IdGamme)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_mod_gam");

                entity.HasAlternateKey(e => new { e.IdGamme, e.NomMoto, e.DescriptifMoto, e.PrixMoto });
            });

            modelBuilder.Entity<MotoConfigurable>(entity =>
            {
                entity.HasKey(e => e.IdMotoConfigurable)
                    .HasName("pk_mcf");
                entity.HasOne(d => d.ModeleMotoMotoConfigurable)
                    .WithMany(p => p.MotoConfigurableModeleMoto)
                    .HasForeignKey(d => d.IdMoto)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_mcf_mod");
            });

            modelBuilder.Entity<MotoDisponible>(entity =>
            {
                entity.HasKey(e => e.IdMotoDisponible)
                    .HasName("pk_mdp");

                entity.HasOne(d => d.ModeleMotoMotoDisponible)
                    .WithMany(p => p.MotoDisponibleModeleMoto)
                    .HasForeignKey(d => d.IdMoto)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_mdp_mod");
            });


            modelBuilder.Entity<Option>(entity =>
            {
                entity.HasKey(e => e.IdOption)
                    .HasName("pk_opt");

                entity.HasAlternateKey(e => new { e.NomOption, e.DetailOption });
            });

            modelBuilder.Entity<Pack>(entity =>
            {
                entity.HasKey(e => e.IdPack)
                    .HasName("pk_pck");

                entity.HasOne(d => d.ModeleMotoPack)
                  .WithMany(p => p.PackModeleMoto)
                  .HasForeignKey(d => d.IdMoto)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("fk_pck_mod");

                entity.HasAlternateKey(e => new { e.IdMoto, e.NomPack });
            });

            modelBuilder.Entity<Parametre>(entity =>
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

            modelBuilder.Entity<PresentationEquipement>(entity =>
            {
                entity.HasKey(e => e.IdPresentation)
                    .HasName("pk_pre");

                entity.HasOne(d => d.EquipementPresentationEquipement)
                    .WithMany(p => p.PresentationEquipementEquipement)
                    .HasForeignKey(d => d.IdEquipement)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_pre_equ");
                entity.HasOne(d => d.ColorisPresentationEquipement)
                    .WithMany(p => p.PresentationEquipementColoris)
                    .HasForeignKey(d => d.IdColoris)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_pre_cls");
            });

            modelBuilder.Entity<Prive>(entity =>
            {
                entity.HasKey(e => e.IdPrive)
                    .HasName("pk_prv");

                entity.HasOne(d => d.ClientPrive)
                    .WithMany(p => p.PriveClient)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_prv_clt");

                entity.HasAlternateKey(e => e.IdClient);
            });

            modelBuilder.Entity<Professionnel>(entity =>
            {
                entity.HasKey(e => e.IdPro)
                    .HasName("pk_pro");

                entity.HasOne(d => d.ClientProfessionnel)
                    .WithMany(p => p.ProfessionnelClient)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_pro_clt");

                entity.HasAlternateKey(e => e.IdClient);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.IdReservation)
                    .HasName("pk_res");

                entity.HasOne(d => d.MotoDisponibleReservation)
                    .WithMany(p => p.ReservationMotoDisponible)
                    .HasForeignKey(d => d.IdReservation)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_res_mdp");
                entity.HasOne(d => d.ClientReservation)
                    .WithMany(p => p.ReservationClient)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_res_clt");
                entity.HasOne(d => d.ConcessionnaireReservation)
                    .WithMany(p => p.ReservationConcessionnaire)
                    .HasForeignKey(d => d.IdConcessionnaire)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_res_con");

                entity.HasCheckConstraint("ck_res_financement", "((((res_financement)::text = 'Comptant'::text) OR ((res_financement)::text = 'LLD'::text) OR ((res_financement)::text = 'Crédit'::text)))");
            });

            modelBuilder.Entity<SeCompose>(entity =>
            {
                entity.HasKey(e => new { e.IdPack, e.IdOption })
                    .HasName("pk_scp");

                entity.HasOne(d => d.PackSeCompose)
                    .WithMany(p => p.SeComposePack)
                    .HasForeignKey(d => d.IdPack)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_scp_pck");
                entity.HasOne(d => d.OptionSeCompose)
                    .WithMany(p => p.SeComposeOption)
                    .HasForeignKey(d => d.IdOption)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_scp_opt");
            });

            modelBuilder.Entity<Specifie>(entity =>
            {
                entity.HasKey(e => new { e.IdMoto, e.IdOption })
                    .HasName("pk_spe");

                entity.HasOne(d => d.ModeleMotoSpecifie)
                    .WithMany(p => p.SpecifieModeleMoto)
                    .HasForeignKey(d => d.IdMoto)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_spe_mcf");
                entity.HasOne(d => d.OptionSpecifie)
                    .WithMany(p => p.SpecifieOption)
                    .HasForeignKey(d => d.IdOption)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_spe_opt");
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

            modelBuilder.Entity<Style>(entity =>
            {
                entity.HasKey(e => e.IdStyle)
                    .HasName("pk_sty");

                entity.HasOne(d => d.ModeleMotoStyle)
                    .WithMany(p => p.StyleModeleMoto)
                    .HasForeignKey(d => d.IdMoto)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_sty_mod");

                entity.HasAlternateKey(e => new { e.NomStyle, e.DescriptionStyle });
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

                entity.HasCheckConstraint("ck_tel_fonction", "((((tel_fonction)::text = 'Privé'::text) OR ((tel_fonction)::text = 'Professionnel'::text)))");
                entity.HasCheckConstraint("ck_tel_num", "((((tel_fonction)::text = 'Privé'::text) OR ((tel_fonction)::text = 'Professionnel'::text)))");
                entity.HasCheckConstraint("ck_tel_type", "((((tel_type)::text = 'Fixe'::text) OR ((tel_type)::text = 'Mobile'::text)))");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.IdTransaction)
                    .HasName("pk_tct");

                entity.HasOne(d => d.CommandeTransaction)
                    .WithMany(p => p.TransactionCommande)
                    .HasForeignKey(d => d.IdCommande)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_tct_cmd");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("pk_usr");

                entity.HasOne(d => d.ClientUsers)
                    .WithMany(p => p.UsersClient)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_usr_clt");

                entity.HasAlternateKey(e => e.Email);
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


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
