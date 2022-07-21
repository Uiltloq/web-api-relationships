using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreRelationships.Migrations
{
    public partial class CharacterWeaponRelationship1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSkill_Characters_MyPropertyId",
                table: "CharacterSkill");

            migrationBuilder.RenameColumn(
                name: "MyPropertyId",
                table: "CharacterSkill",
                newName: "CharactersId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSkill_Characters_CharactersId",
                table: "CharacterSkill",
                column: "CharactersId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSkill_Characters_CharactersId",
                table: "CharacterSkill");

            migrationBuilder.RenameColumn(
                name: "CharactersId",
                table: "CharacterSkill",
                newName: "MyPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSkill_Characters_MyPropertyId",
                table: "CharacterSkill",
                column: "MyPropertyId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
