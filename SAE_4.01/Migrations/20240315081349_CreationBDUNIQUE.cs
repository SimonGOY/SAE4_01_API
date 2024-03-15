using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAE_4._01.Migrations
{
    public partial class CreationBDUNIQUE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_t_e_prive_prv_clt_id",
                table: "t_e_prive_prv");

            migrationBuilder.DropIndex(
                name: "IX_t_e_pack_pck_mod_id",
                table: "t_e_pack_pck");

            migrationBuilder.DropIndex(
                name: "IX_t_e_modelemoto_mod_gam_idgamme",
                table: "t_e_modelemoto_mod");

            migrationBuilder.DropColumn(
                name: "pro_id2",
                table: "t_e_professionnel_pro");

            migrationBuilder.DropColumn(
                name: "prv_id2",
                table: "t_e_prive_prv");

            migrationBuilder.CreateIndex(
                name: "uq_sty_nom_description",
                table: "t_e_style_sty",
                columns: new[] { "sty_nom", "sty_description" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_pro_clt_id",
                table: "t_e_professionnel_pro",
                column: "clt_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_prv_clt_id",
                table: "t_e_prive_prv",
                column: "clt_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_pck_mod_id",
                table: "t_e_pack_pck",
                column: "mod_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_pck_nom",
                table: "t_e_pack_pck",
                column: "pck_nom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_opt_nom_detail",
                table: "t_e_option_opt",
                columns: new[] { "opt_nom", "opt_detail" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_acc_nom1",
                table: "t_e_modelemoto_mod",
                columns: new[] { "gam_idgamme", "mod_nommoto", "mod_desc", "mod_prix" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_med_lien",
                table: "t_e_media_med",
                column: "med_lienmedia",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_gam_libelle",
                table: "t_e_gammemoto_gam",
                column: "gam_libelle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_clr_nom",
                table: "t_e_couleur_clr",
                columns: new[] { "clr_nom", "clr_description" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_con_nom",
                table: "t_e_concessionnaire_con",
                column: "con_nom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_cls_nom",
                table: "t_e_coloris_cls",
                column: "cls_nom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_ctc_nom",
                table: "t_e_categoriecaracteristique_ctc",
                column: "ctc_nom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_cta_nom",
                table: "t_e_categorieaccessoire_cta",
                column: "cta_nom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_acc_nom",
                table: "t_e_accessoire_acc",
                column: "acc_nom",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "uq_sty_nom_description",
                table: "t_e_style_sty");

            migrationBuilder.DropIndex(
                name: "uq_pro_clt_id",
                table: "t_e_professionnel_pro");

            migrationBuilder.DropIndex(
                name: "uq_prv_clt_id",
                table: "t_e_prive_prv");

            migrationBuilder.DropIndex(
                name: "uq_pck_mod_id",
                table: "t_e_pack_pck");

            migrationBuilder.DropIndex(
                name: "uq_pck_nom",
                table: "t_e_pack_pck");

            migrationBuilder.DropIndex(
                name: "uq_opt_nom_detail",
                table: "t_e_option_opt");

            migrationBuilder.DropIndex(
                name: "uq_acc_nom1",
                table: "t_e_modelemoto_mod");

            migrationBuilder.DropIndex(
                name: "uq_med_lien",
                table: "t_e_media_med");

            migrationBuilder.DropIndex(
                name: "uq_gam_libelle",
                table: "t_e_gammemoto_gam");

            migrationBuilder.DropIndex(
                name: "uq_clr_nom",
                table: "t_e_couleur_clr");

            migrationBuilder.DropIndex(
                name: "uq_con_nom",
                table: "t_e_concessionnaire_con");

            migrationBuilder.DropIndex(
                name: "uq_cls_nom",
                table: "t_e_coloris_cls");

            migrationBuilder.DropIndex(
                name: "uq_ctc_nom",
                table: "t_e_categoriecaracteristique_ctc");

            migrationBuilder.DropIndex(
                name: "uq_cta_nom",
                table: "t_e_categorieaccessoire_cta");

            migrationBuilder.DropIndex(
                name: "uq_acc_nom",
                table: "t_e_accessoire_acc");

            migrationBuilder.AddColumn<int>(
                name: "pro_id2",
                table: "t_e_professionnel_pro",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "prv_id2",
                table: "t_e_prive_prv",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_prive_prv_clt_id",
                table: "t_e_prive_prv",
                column: "clt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_pack_pck_mod_id",
                table: "t_e_pack_pck",
                column: "mod_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_modelemoto_mod_gam_idgamme",
                table: "t_e_modelemoto_mod",
                column: "gam_idgamme");
        }
    }
}
