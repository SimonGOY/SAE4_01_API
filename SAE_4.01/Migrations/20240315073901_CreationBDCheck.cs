using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SAE_4._01.Migrations
{
    public partial class CreationBDCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_e_categorieaccessoire_cta",
                columns: table => new
                {
                    cta_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cta_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cta", x => x.cta_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_categoriecaracteristique_ctc",
                columns: table => new
                {
                    ctc_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ctc_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ctc", x => x.ctc_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_categorieequipement_cte",
                columns: table => new
                {
                    cte_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cte_catidcatequipement = table.Column<int>(type: "integer", nullable: false),
                    cte_libelle = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cte", x => x.cte_id);
                    table.ForeignKey(
                        name: "fk_cte_cte",
                        column: x => x.cte_catidcatequipement,
                        principalTable: "t_e_categorieequipement_cte",
                        principalColumn: "cte_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_collection_cln",
                columns: table => new
                {
                    cln_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cln_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cln", x => x.cln_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_coloris_cls",
                columns: table => new
                {
                    cls_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cls_nom = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cls", x => x.cls_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_concessionnaire_con",
                columns: table => new
                {
                    con_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    con_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    con_email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    con_site = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    con_telephone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    con_adresse = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_con", x => x.con_id);
                    table.CheckConstraint("ck_con_email", "(con_email)::text ~~ '%_@__%.__%'::text");
                    table.CheckConstraint("ck_con_telephone", "(con_telephone)::text ~'^(01|02|03|04|05|09)\\d{8}$'::text");
                });

            migrationBuilder.CreateTable(
                name: "t_e_gammemoto_gam",
                columns: table => new
                {
                    gam_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    gam_libelle = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_gam", x => x.gam_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_option_opt",
                columns: table => new
                {
                    opt_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    opt_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    opt_prix = table.Column<decimal>(type: "numeric", nullable: false),
                    opt_detail = table.Column<string>(type: "text", nullable: false),
                    opt_photo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_opt", x => x.opt_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_parametre_par",
                columns: table => new
                {
                    par_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    par_description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_par", x => x.par_nom);
                });

            migrationBuilder.CreateTable(
                name: "t_e_pays_pay",
                columns: table => new
                {
                    pay_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pay", x => x.pay_nom);
                });

            migrationBuilder.CreateTable(
                name: "t_r_taille_tle",
                columns: table => new
                {
                    tle_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tle_libelle = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    tle_description = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tle", x => x.tle_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_equipement_equ",
                columns: table => new
                {
                    equ_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cln_idcollection = table.Column<int>(type: "integer", nullable: false),
                    cte_idcatequipement = table.Column<int>(type: "integer", nullable: false),
                    equ_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    equ_desc = table.Column<string>(type: "text", nullable: false),
                    equ_sexe = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    equ_prix = table.Column<float>(type: "real", nullable: false),
                    equ_dureegarantie = table.Column<int>(type: "integer", nullable: false),
                    equ_tendance = table.Column<bool>(type: "boolean", nullable: false),
                    equ_segment = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_equ", x => x.equ_id);
                    table.CheckConstraint("ck_eq_sexe", "(((equ_sexe)::text = 'f'::text) OR ((equ_sexe)::text = 'h'::text) OR ((equ_sexe)::text = 'uni'::text))");
                    table.ForeignKey(
                        name: "fk_equ_cln",
                        column: x => x.cln_idcollection,
                        principalTable: "t_e_collection_cln",
                        principalColumn: "cln_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_equ_cte",
                        column: x => x.cte_idcatequipement,
                        principalTable: "t_e_categorieequipement_cte",
                        principalColumn: "cte_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_modelemoto_mod",
                columns: table => new
                {
                    mod_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    gam_idgamme = table.Column<int>(type: "integer", nullable: false),
                    mod_nommoto = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    mod_desc = table.Column<string>(type: "text", nullable: false),
                    mod_prix = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mod", x => x.mod_id);
                    table.ForeignKey(
                        name: "fk_mod_gam",
                        column: x => x.gam_idgamme,
                        principalTable: "t_e_gammemoto_gam",
                        principalColumn: "gam_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_adresse_adr",
                columns: table => new
                {
                    adr_num = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pay_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    adr_adresse = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_adr", x => x.adr_num);
                    table.ForeignKey(
                        name: "fk_adr_pay",
                        column: x => x.pay_nom,
                        principalTable: "t_e_pays_pay",
                        principalColumn: "pay_nom",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_stock_stk",
                columns: table => new
                {
                    tle_id = table.Column<int>(type: "integer", nullable: false),
                    cls_id = table.Column<int>(type: "integer", nullable: false),
                    equ_id = table.Column<int>(type: "integer", nullable: false),
                    stk_quantite = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stk", x => new { x.tle_id, x.cls_id, x.equ_id });
                    table.ForeignKey(
                        name: "fk_stk_cls",
                        column: x => x.cls_id,
                        principalTable: "t_e_coloris_cls",
                        principalColumn: "cls_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_stk_equ",
                        column: x => x.equ_id,
                        principalTable: "t_e_equipement_equ",
                        principalColumn: "equ_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_stk_tle",
                        column: x => x.tle_id,
                        principalTable: "t_r_taille_tle",
                        principalColumn: "tle_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_estlie_eli",
                columns: table => new
                {
                    equ_idequipement = table.Column<int>(type: "integer", nullable: false),
                    equ_equidequipement = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_eli", x => new { x.equ_idequipement, x.equ_equidequipement });
                    table.ForeignKey(
                        name: "fk_eli_equ",
                        column: x => x.equ_idequipement,
                        principalTable: "t_e_equipement_equ",
                        principalColumn: "equ_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_r_presentationequipement_pre",
                columns: table => new
                {
                    pre_id = table.Column<int>(type: "integer", nullable: false),
                    equ_idequipement = table.Column<int>(type: "integer", nullable: false),
                    col_idcoloris = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pre", x => x.pre_id);
                    table.ForeignKey(
                        name: "fk_pre_cls",
                        column: x => x.col_idcoloris,
                        principalTable: "t_e_coloris_cls",
                        principalColumn: "cls_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_pre_equ",
                        column: x => x.pre_id,
                        principalTable: "t_e_equipement_equ",
                        principalColumn: "equ_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_accessoire_acc",
                columns: table => new
                {
                    acc_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mod_id = table.Column<int>(type: "integer", nullable: false),
                    cta_id = table.Column<int>(type: "integer", nullable: false),
                    acc_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    acc_prix = table.Column<decimal>(type: "numeric", nullable: false),
                    acc_detail = table.Column<string>(type: "text", nullable: false),
                    acc_photo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_acc", x => x.acc_id);
                    table.ForeignKey(
                        name: "fk_acc_cta",
                        column: x => x.cta_id,
                        principalTable: "t_e_categorieaccessoire_cta",
                        principalColumn: "cta_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_acc_mod",
                        column: x => x.mod_id,
                        principalTable: "t_e_modelemoto_mod",
                        principalColumn: "mod_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_caracteristique_car",
                columns: table => new
                {
                    car_id = table.Column<int>(type: "integer", nullable: false),
                    mod_idmoto = table.Column<int>(type: "integer", nullable: false),
                    ctc_idcat = table.Column<int>(type: "integer", nullable: false),
                    car_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    car_valeur = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_car", x => x.car_id);
                    table.ForeignKey(
                        name: "fk_car_ctc",
                        column: x => x.ctc_idcat,
                        principalTable: "t_e_categoriecaracteristique_ctc",
                        principalColumn: "ctc_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_car_mod",
                        column: x => x.car_id,
                        principalTable: "t_e_modelemoto_mod",
                        principalColumn: "mod_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_couleur_clr",
                columns: table => new
                {
                    clr_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mod_id = table.Column<int>(type: "integer", nullable: false),
                    clr_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    clr_prix = table.Column<double>(type: "double precision", nullable: false),
                    clr_description = table.Column<string>(type: "text", nullable: false),
                    clr_photo = table.Column<string>(type: "text", nullable: false),
                    clr_moto = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clr", x => x.clr_id);
                    table.ForeignKey(
                        name: "fk_clr_mod",
                        column: x => x.mod_id,
                        principalTable: "t_e_modelemoto_mod",
                        principalColumn: "mod_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_motodisponible_mdp",
                columns: table => new
                {
                    mdp_id = table.Column<int>(type: "integer", nullable: false),
                    mdp_prix = table.Column<float>(type: "real", nullable: false),
                    mod_idmoto = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mdp", x => x.mdp_id);
                    table.ForeignKey(
                        name: "fk_mdp_mod",
                        column: x => x.mdp_id,
                        principalTable: "t_e_modelemoto_mod",
                        principalColumn: "mod_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_pack_pck",
                columns: table => new
                {
                    pck_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mod_id = table.Column<int>(type: "integer", nullable: false),
                    pck_nom = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    pck_description = table.Column<string>(type: "text", nullable: false),
                    pck_photo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    pck_prix = table.Column<decimal>(type: "numeric(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pck", x => x.pck_id);
                    table.ForeignKey(
                        name: "fk_pck_mod",
                        column: x => x.mod_id,
                        principalTable: "t_e_modelemoto_mod",
                        principalColumn: "mod_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_style_sty",
                columns: table => new
                {
                    sty_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mod_id = table.Column<int>(type: "integer", nullable: false),
                    sty_nom = table.Column<string>(type: "text", nullable: false),
                    sty_prix = table.Column<double>(type: "double precision", nullable: false),
                    sty_description = table.Column<string>(type: "text", nullable: false),
                    sty_photo = table.Column<string>(type: "text", nullable: false),
                    sty_photomoto = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sty", x => x.sty_id);
                    table.ForeignKey(
                        name: "fk_sty_mod",
                        column: x => x.mod_id,
                        principalTable: "t_e_modelemoto_mod",
                        principalColumn: "mod_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_r_motoconfigurable_mcf",
                columns: table => new
                {
                    mcf_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mod_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mcf", x => x.mcf_id);
                    table.ForeignKey(
                        name: "fk_mcf_mod",
                        column: x => x.mod_id,
                        principalTable: "t_e_modelemoto_mod",
                        principalColumn: "mod_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_client_clt",
                columns: table => new
                {
                    clt_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    adr_numeroadresse = table.Column<int>(type: "integer", nullable: false),
                    clt_civilite = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    clt_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    clt_prenom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    clt_datenaissance = table.Column<DateTime>(type: "DATE", nullable: false),
                    clt_email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clt", x => x.clt_id);
                    table.CheckConstraint("ck_clt_age", "age((clt_datenaissance)::timestamp with time zone) >= '18 years'::interval");
                    table.CheckConstraint("ck_clt_email", "clt_email ~~ '%_@__%.__%'::text");
                    table.ForeignKey(
                        name: "fk_clt_adr",
                        column: x => x.adr_numeroadresse,
                        principalTable: "t_e_adresse_adr",
                        principalColumn: "adr_num",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_media_med",
                columns: table => new
                {
                    med_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    equ_idequipement = table.Column<int>(type: "integer", nullable: false),
                    mod_idmoto = table.Column<int>(type: "integer", nullable: false),
                    pre_idpresentation = table.Column<int>(type: "integer", nullable: false),
                    med_lienmedia = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_med", x => x.med_id);
                    table.ForeignKey(
                        name: "fk_med_equ",
                        column: x => x.equ_idequipement,
                        principalTable: "t_e_equipement_equ",
                        principalColumn: "equ_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_med_mod",
                        column: x => x.mod_idmoto,
                        principalTable: "t_e_modelemoto_mod",
                        principalColumn: "mod_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_med_pre",
                        column: x => x.pre_idpresentation,
                        principalTable: "t_r_presentationequipement_pre",
                        principalColumn: "pre_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_se_compose_scp",
                columns: table => new
                {
                    pck_id = table.Column<int>(type: "integer", nullable: false),
                    opt_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_scp", x => new { x.pck_id, x.opt_id });
                    table.ForeignKey(
                        name: "fk_scp_opt",
                        column: x => x.opt_id,
                        principalTable: "t_e_option_opt",
                        principalColumn: "opt_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_scp_pck",
                        column: x => x.pck_id,
                        principalTable: "t_e_pack_pck",
                        principalColumn: "pck_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_estinclus_ecl",
                columns: table => new
                {
                    opt_id = table.Column<int>(type: "integer", nullable: false),
                    sty_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ecl", x => new { x.opt_id, x.sty_id });
                    table.ForeignKey(
                        name: "fk_ecl_opt",
                        column: x => x.opt_id,
                        principalTable: "t_e_option_opt",
                        principalColumn: "opt_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ecl_sty",
                        column: x => x.sty_id,
                        principalTable: "t_e_style_sty",
                        principalColumn: "sty_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_offre_ofr",
                columns: table => new
                {
                    ofr_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mcf_id = table.Column<int>(type: "integer", nullable: false),
                    con_id = table.Column<int>(type: "integer", nullable: false),
                    ofr_assurance = table.Column<bool>(type: "boolean", nullable: false),
                    ofr_financement = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ofr", x => x.ofr_id);
                    table.CheckConstraint("ck_ofr_financement", "((((ofr_financement)::text = 'Sans Financement'::text) OR ((ofr_financement)::text = 'Financement Particulier'::text) OR ((ofr_financement)::text = 'Financement Professionnel'::text)))");
                    table.ForeignKey(
                        name: "fk_ofr_con",
                        column: x => x.con_id,
                        principalTable: "t_e_concessionnaire_con",
                        principalColumn: "con_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ofr_mcf",
                        column: x => x.mcf_id,
                        principalTable: "t_r_motoconfigurable_mcf",
                        principalColumn: "mcf_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_j_specifie_spe",
                columns: table => new
                {
                    spe_idmoto = table.Column<int>(type: "integer", nullable: false),
                    opt_id = table.Column<int>(type: "integer", nullable: false),
                    mcf_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_spe", x => new { x.spe_idmoto, x.opt_id });
                    table.ForeignKey(
                        name: "fk_spe_mcf",
                        column: x => x.mcf_id,
                        principalTable: "t_r_motoconfigurable_mcf",
                        principalColumn: "mcf_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_spe_opt",
                        column: x => x.opt_id,
                        principalTable: "t_e_option_opt",
                        principalColumn: "opt_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_commande_cmd",
                columns: table => new
                {
                    cmd_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clt_id = table.Column<int>(type: "integer", nullable: false),
                    cmd_date = table.Column<DateTime>(type: "DATE", nullable: false),
                    cmd_etat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cmd", x => x.cmd_id);
                    table.ForeignKey(
                        name: "fk_cmd_clt",
                        column: x => x.clt_id,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_infocb_icb",
                columns: table => new
                {
                    icb_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clt_id = table.Column<int>(type: "integer", nullable: false),
                    icb_numcarte = table.Column<string>(type: "text", nullable: false),
                    icb_dateexpiration = table.Column<string>(type: "text", nullable: false),
                    icb_titulairecompte = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_icb", x => x.icb_id);
                    table.ForeignKey(
                        name: "fk_icb_clt",
                        column: x => x.clt_id,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_prive_prv",
                columns: table => new
                {
                    prv_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clt_id = table.Column<int>(type: "integer", nullable: false),
                    prv_id2 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_prv", x => x.prv_id);
                    table.ForeignKey(
                        name: "fk_prv_clt",
                        column: x => x.clt_id,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_professionnel_pro",
                columns: table => new
                {
                    pro_id = table.Column<int>(type: "integer", nullable: false),
                    clt_id = table.Column<int>(type: "integer", nullable: false),
                    pro_id2 = table.Column<int>(type: "integer", nullable: false),
                    pro_nomcompagnie = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pro", x => x.pro_id);
                    table.ForeignKey(
                        name: "fk_pro_clt",
                        column: x => x.pro_id,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_reservation_res",
                columns: table => new
                {
                    res_id = table.Column<int>(type: "integer", nullable: false),
                    mdp_idmoto = table.Column<int>(type: "integer", nullable: false),
                    clt_idclient = table.Column<int>(type: "integer", nullable: false),
                    con_idconcessionnaire = table.Column<int>(type: "integer", nullable: false),
                    res_dateres = table.Column<DateTime>(type: "date", nullable: false),
                    res_financement = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_res", x => x.res_id);
                    table.CheckConstraint("ck_res_financement", "((((res_financement)::text = 'Comptant'::text) OR ((res_financement)::text = 'LLD'::text) OR ((res_financement)::text = 'Crédit'::text)))");
                    table.ForeignKey(
                        name: "fk_res_clt",
                        column: x => x.clt_idclient,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_res_con",
                        column: x => x.con_idconcessionnaire,
                        principalTable: "t_e_concessionnaire_con",
                        principalColumn: "con_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_res_mdp",
                        column: x => x.res_id,
                        principalTable: "t_e_motodisponible_mdp",
                        principalColumn: "mdp_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_telephone_tel",
                columns: table => new
                {
                    tel_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clt_id = table.Column<int>(type: "integer", nullable: false),
                    tel_num = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    tel_type = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    tel_fonction = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tel", x => x.tel_id);
                    table.CheckConstraint("ck_tel_fonction", "((((tel_fonction)::text = 'Privé'::text) OR ((tel_fonction)::text = 'Professionnel'::text)))");
                    table.CheckConstraint("ck_tel_num", "((((tel_fonction)::text = 'Privé'::text) OR ((tel_fonction)::text = 'Professionnel'::text)))");
                    table.CheckConstraint("ck_tel_type", "((((tel_type)::text = 'Fixe'::text) OR ((tel_type)::text = 'Mobile'::text)))");
                    table.ForeignKey(
                        name: "FK_t_e_telephone_tel_t_e_client_clt_clt_id",
                        column: x => x.clt_id,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_users_usr",
                columns: table => new
                {
                    usr_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clt_id = table.Column<int>(type: "integer", nullable: false),
                    usr_email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    usr_password = table.Column<string>(type: "text", nullable: false),
                    usr_remembertoken = table.Column<string>(type: "text", nullable: true),
                    usr_createdat = table.Column<DateTime>(type: "DATE", nullable: false),
                    usr_updatedat = table.Column<DateTime>(type: "DATE", nullable: false),
                    usr_iscomplete = table.Column<bool>(type: "boolean", nullable: false),
                    usr_doubleauth = table.Column<bool>(type: "boolean", nullable: false),
                    usr_lastconnected = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usr", x => x.usr_id);
                    table.ForeignKey(
                        name: "fk_usr_clt",
                        column: x => x.clt_id,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_r_garage_grg",
                columns: table => new
                {
                    mcf_id = table.Column<int>(type: "integer", nullable: false),
                    clt_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_grg", x => new { x.mcf_id, x.clt_id });
                    table.ForeignKey(
                        name: "fk_grg_clt",
                        column: x => x.clt_id,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_grg_mcf",
                        column: x => x.mcf_id,
                        principalTable: "t_r_motoconfigurable_mcf",
                        principalColumn: "mcf_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_r_prefere_prf",
                columns: table => new
                {
                    clt_id = table.Column<int>(type: "integer", nullable: false),
                    con_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_prf", x => new { x.clt_id, x.con_id });
                    table.ForeignKey(
                        name: "fk_prf_clt",
                        column: x => x.clt_id,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_prf_con",
                        column: x => x.con_id,
                        principalTable: "t_e_concessionnaire_con",
                        principalColumn: "con_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_contactinfo_ctf",
                columns: table => new
                {
                    ctf_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ofr_id = table.Column<int>(type: "integer", nullable: false),
                    ctf_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ctf_prenom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ctf_datenaissance = table.Column<DateTime>(type: "DATE", nullable: false),
                    ctf_email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ctf_tel = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ctf", x => x.ctf_id);
                    table.CheckConstraint("ck_ctf_datenaissance", "age((ctf_datenaissance)::timestamp with time zone) >= '18 years'::interval");
                    table.CheckConstraint("ck_ctf_email", "(ctf_email)::text ~~'%_@__%.__%'::text");
                    table.ForeignKey(
                        name: "fk_ctf_ofr",
                        column: x => x.ofr_id,
                        principalTable: "t_e_offre_ofr",
                        principalColumn: "ofr_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_contenu_commande_ccm",
                columns: table => new
                {
                    equ_id = table.Column<int>(type: "integer", nullable: false),
                    tle_id = table.Column<int>(type: "integer", nullable: false),
                    cls_id = table.Column<int>(type: "integer", nullable: false),
                    cmd_id = table.Column<int>(type: "integer", nullable: false),
                    equ_quantite = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ccm", x => new { x.equ_id, x.tle_id, x.cls_id, x.cmd_id });
                    table.ForeignKey(
                        name: "fk_ccm_cls",
                        column: x => x.cls_id,
                        principalTable: "t_e_coloris_cls",
                        principalColumn: "cls_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ccm_cmd",
                        column: x => x.cmd_id,
                        principalTable: "t_e_commande_cmd",
                        principalColumn: "cmd_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ccm_equ",
                        column: x => x.equ_id,
                        principalTable: "t_e_equipement_equ",
                        principalColumn: "equ_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ccm_tle",
                        column: x => x.tle_id,
                        principalTable: "t_r_taille_tle",
                        principalColumn: "tle_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_h_transaction_tct",
                columns: table => new
                {
                    tct_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cmd_id = table.Column<int>(type: "integer", nullable: false),
                    tct_type = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    tct_montant = table.Column<decimal>(type: "numeric(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tct", x => x.tct_id);
                    table.ForeignKey(
                        name: "fk_tct_cmd",
                        column: x => x.cmd_id,
                        principalTable: "t_e_commande_cmd",
                        principalColumn: "cmd_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_e_demandeessai_dmd",
                columns: table => new
                {
                    dmd_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    con_id = table.Column<int>(type: "integer", nullable: false),
                    mod_id = table.Column<int>(type: "integer", nullable: false),
                    ctf_id = table.Column<int>(type: "integer", nullable: false),
                    dmd_descriptif = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dmd", x => x.dmd_id);
                    table.ForeignKey(
                        name: "fk_dmd_con",
                        column: x => x.con_id,
                        principalTable: "t_e_concessionnaire_con",
                        principalColumn: "con_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_dmd_ctf",
                        column: x => x.con_id,
                        principalTable: "t_e_contactinfo_ctf",
                        principalColumn: "ctf_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_dmd_mod",
                        column: x => x.con_id,
                        principalTable: "t_e_modelemoto_mod",
                        principalColumn: "mod_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_e_accessoire_acc_cta_id",
                table: "t_e_accessoire_acc",
                column: "cta_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_accessoire_acc_mod_id",
                table: "t_e_accessoire_acc",
                column: "mod_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_adresse_adr_pay_nom",
                table: "t_e_adresse_adr",
                column: "pay_nom");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_caracteristique_car_ctc_idcat",
                table: "t_e_caracteristique_car",
                column: "ctc_idcat");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_categorieequipement_cte_cte_catidcatequipement",
                table: "t_e_categorieequipement_cte",
                column: "cte_catidcatequipement");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_client_clt_adr_numeroadresse",
                table: "t_e_client_clt",
                column: "adr_numeroadresse");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commande_cmd_clt_id",
                table: "t_e_commande_cmd",
                column: "clt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_contactinfo_ctf_ofr_id",
                table: "t_e_contactinfo_ctf",
                column: "ofr_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_contenu_commande_ccm_cls_id",
                table: "t_e_contenu_commande_ccm",
                column: "cls_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_contenu_commande_ccm_cmd_id",
                table: "t_e_contenu_commande_ccm",
                column: "cmd_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_contenu_commande_ccm_tle_id",
                table: "t_e_contenu_commande_ccm",
                column: "tle_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_couleur_clr_mod_id",
                table: "t_e_couleur_clr",
                column: "mod_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_demandeessai_dmd_con_id",
                table: "t_e_demandeessai_dmd",
                column: "con_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_equipement_equ_cln_idcollection",
                table: "t_e_equipement_equ",
                column: "cln_idcollection");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_equipement_equ_cte_idcatequipement",
                table: "t_e_equipement_equ",
                column: "cte_idcatequipement");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_infocb_icb_clt_id",
                table: "t_e_infocb_icb",
                column: "clt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_media_med_equ_idequipement",
                table: "t_e_media_med",
                column: "equ_idequipement");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_media_med_mod_idmoto",
                table: "t_e_media_med",
                column: "mod_idmoto");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_media_med_pre_idpresentation",
                table: "t_e_media_med",
                column: "pre_idpresentation");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_modelemoto_mod_gam_idgamme",
                table: "t_e_modelemoto_mod",
                column: "gam_idgamme");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_offre_ofr_con_id",
                table: "t_e_offre_ofr",
                column: "con_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_offre_ofr_mcf_id",
                table: "t_e_offre_ofr",
                column: "mcf_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_pack_pck_mod_id",
                table: "t_e_pack_pck",
                column: "mod_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_prive_prv_clt_id",
                table: "t_e_prive_prv",
                column: "clt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_reservation_res_clt_idclient",
                table: "t_e_reservation_res",
                column: "clt_idclient");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_reservation_res_con_idconcessionnaire",
                table: "t_e_reservation_res",
                column: "con_idconcessionnaire");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_stock_stk_cls_id",
                table: "t_e_stock_stk",
                column: "cls_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_stock_stk_equ_id",
                table: "t_e_stock_stk",
                column: "equ_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_style_sty_mod_id",
                table: "t_e_style_sty",
                column: "mod_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_telephone_tel_clt_id",
                table: "t_e_telephone_tel",
                column: "clt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_users_usr_clt_id",
                table: "t_e_users_usr",
                column: "clt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_h_transaction_tct_cmd_id",
                table: "t_h_transaction_tct",
                column: "cmd_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_estinclus_ecl_sty_id",
                table: "t_j_estinclus_ecl",
                column: "sty_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_se_compose_scp_opt_id",
                table: "t_j_se_compose_scp",
                column: "opt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_specifie_spe_mcf_id",
                table: "t_j_specifie_spe",
                column: "mcf_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_specifie_spe_opt_id",
                table: "t_j_specifie_spe",
                column: "opt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_r_garage_grg_clt_id",
                table: "t_r_garage_grg",
                column: "clt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_r_motoconfigurable_mcf_mod_id",
                table: "t_r_motoconfigurable_mcf",
                column: "mod_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_r_prefere_prf_con_id",
                table: "t_r_prefere_prf",
                column: "con_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_r_presentationequipement_pre_col_idcoloris",
                table: "t_r_presentationequipement_pre",
                column: "col_idcoloris");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_e_accessoire_acc");

            migrationBuilder.DropTable(
                name: "t_e_caracteristique_car");

            migrationBuilder.DropTable(
                name: "t_e_contenu_commande_ccm");

            migrationBuilder.DropTable(
                name: "t_e_couleur_clr");

            migrationBuilder.DropTable(
                name: "t_e_demandeessai_dmd");

            migrationBuilder.DropTable(
                name: "t_e_infocb_icb");

            migrationBuilder.DropTable(
                name: "t_e_media_med");

            migrationBuilder.DropTable(
                name: "t_e_parametre_par");

            migrationBuilder.DropTable(
                name: "t_e_prive_prv");

            migrationBuilder.DropTable(
                name: "t_e_professionnel_pro");

            migrationBuilder.DropTable(
                name: "t_e_reservation_res");

            migrationBuilder.DropTable(
                name: "t_e_stock_stk");

            migrationBuilder.DropTable(
                name: "t_e_telephone_tel");

            migrationBuilder.DropTable(
                name: "t_e_users_usr");

            migrationBuilder.DropTable(
                name: "t_h_transaction_tct");

            migrationBuilder.DropTable(
                name: "t_j_estinclus_ecl");

            migrationBuilder.DropTable(
                name: "t_j_estlie_eli");

            migrationBuilder.DropTable(
                name: "t_j_se_compose_scp");

            migrationBuilder.DropTable(
                name: "t_j_specifie_spe");

            migrationBuilder.DropTable(
                name: "t_r_garage_grg");

            migrationBuilder.DropTable(
                name: "t_r_prefere_prf");

            migrationBuilder.DropTable(
                name: "t_e_categorieaccessoire_cta");

            migrationBuilder.DropTable(
                name: "t_e_categoriecaracteristique_ctc");

            migrationBuilder.DropTable(
                name: "t_e_contactinfo_ctf");

            migrationBuilder.DropTable(
                name: "t_r_presentationequipement_pre");

            migrationBuilder.DropTable(
                name: "t_e_motodisponible_mdp");

            migrationBuilder.DropTable(
                name: "t_r_taille_tle");

            migrationBuilder.DropTable(
                name: "t_e_commande_cmd");

            migrationBuilder.DropTable(
                name: "t_e_style_sty");

            migrationBuilder.DropTable(
                name: "t_e_pack_pck");

            migrationBuilder.DropTable(
                name: "t_e_option_opt");

            migrationBuilder.DropTable(
                name: "t_e_offre_ofr");

            migrationBuilder.DropTable(
                name: "t_e_coloris_cls");

            migrationBuilder.DropTable(
                name: "t_e_equipement_equ");

            migrationBuilder.DropTable(
                name: "t_e_client_clt");

            migrationBuilder.DropTable(
                name: "t_e_concessionnaire_con");

            migrationBuilder.DropTable(
                name: "t_r_motoconfigurable_mcf");

            migrationBuilder.DropTable(
                name: "t_e_collection_cln");

            migrationBuilder.DropTable(
                name: "t_e_categorieequipement_cte");

            migrationBuilder.DropTable(
                name: "t_e_adresse_adr");

            migrationBuilder.DropTable(
                name: "t_e_modelemoto_mod");

            migrationBuilder.DropTable(
                name: "t_e_pays_pay");

            migrationBuilder.DropTable(
                name: "t_e_gammemoto_gam");
        }
    }
}
