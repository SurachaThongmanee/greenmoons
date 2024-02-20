using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SearchFunction.Migrations
{
    /// <inheritdoc />
    public partial class ChangeKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId1",
                table: "FamilyRelations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId2",
                table: "FamilyRelations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyRelations_PersonId1",
                table: "FamilyRelations",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyRelations_PersonId2",
                table: "FamilyRelations",
                column: "PersonId2");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyRelations_Person_PersonId1",
                table: "FamilyRelations",
                column: "PersonId1",
                principalTable: "Person",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyRelations_Person_PersonId2",
                table: "FamilyRelations",
                column: "PersonId2",
                principalTable: "Person",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyRelations_Person_PersonId1",
                table: "FamilyRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyRelations_Person_PersonId2",
                table: "FamilyRelations");

            migrationBuilder.DropIndex(
                name: "IX_FamilyRelations_PersonId1",
                table: "FamilyRelations");

            migrationBuilder.DropIndex(
                name: "IX_FamilyRelations_PersonId2",
                table: "FamilyRelations");

            migrationBuilder.DropColumn(
                name: "PersonId1",
                table: "FamilyRelations");

            migrationBuilder.DropColumn(
                name: "PersonId2",
                table: "FamilyRelations");
        }
    }
}
