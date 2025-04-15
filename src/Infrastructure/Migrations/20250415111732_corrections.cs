using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class corrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantPrograms_Applicants_ApplicantId",
                table: "ApplicantPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantPrograms_AssistancePrograms_AssistanceProgramId",
                table: "ApplicantPrograms");

            migrationBuilder.AddColumn<int>(
                name: "CountyId",
                table: "Applicants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Applicants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubCountyId",
                table: "Applicants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubLocationId",
                table: "Applicants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_CountyId",
                table: "Applicants",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_LocationId",
                table: "Applicants",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_SubCountyId",
                table: "Applicants",
                column: "SubCountyId");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_SubLocationId",
                table: "Applicants",
                column: "SubLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantPrograms_Applicants_ApplicantId",
                table: "ApplicantPrograms",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantPrograms_AssistancePrograms_AssistanceProgramId",
                table: "ApplicantPrograms",
                column: "AssistanceProgramId",
                principalTable: "AssistancePrograms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Counties_CountyId",
                table: "Applicants",
                column: "CountyId",
                principalTable: "Counties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Locations_LocationId",
                table: "Applicants",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_SubCounties_SubCountyId",
                table: "Applicants",
                column: "SubCountyId",
                principalTable: "SubCounties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_SubLocations_SubLocationId",
                table: "Applicants",
                column: "SubLocationId",
                principalTable: "SubLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantPrograms_Applicants_ApplicantId",
                table: "ApplicantPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantPrograms_AssistancePrograms_AssistanceProgramId",
                table: "ApplicantPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Counties_CountyId",
                table: "Applicants");

            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Locations_LocationId",
                table: "Applicants");

            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_SubCounties_SubCountyId",
                table: "Applicants");

            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_SubLocations_SubLocationId",
                table: "Applicants");

            migrationBuilder.DropIndex(
                name: "IX_Applicants_CountyId",
                table: "Applicants");

            migrationBuilder.DropIndex(
                name: "IX_Applicants_LocationId",
                table: "Applicants");

            migrationBuilder.DropIndex(
                name: "IX_Applicants_SubCountyId",
                table: "Applicants");

            migrationBuilder.DropIndex(
                name: "IX_Applicants_SubLocationId",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "CountyId",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "SubCountyId",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "SubLocationId",
                table: "Applicants");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantPrograms_Applicants_ApplicantId",
                table: "ApplicantPrograms",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantPrograms_AssistancePrograms_AssistanceProgramId",
                table: "ApplicantPrograms",
                column: "AssistanceProgramId",
                principalTable: "AssistancePrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
