using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElProyecteGrande.Migrations;

/// <inheritdoc />
public partial class DishTypeToDishTypes : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropForeignKey(
            name: "FK_Recipes_DishType_DishTypeId",
            table: "Recipes");

        _ = migrationBuilder.DropPrimaryKey(
            name: "PK_DishType",
            table: "DishType");

        _ = migrationBuilder.RenameTable(
            name: "DishType",
            newName: "DishTypes");

        _ = migrationBuilder.RenameIndex(
            name: "IX_DishType_Name",
            table: "DishTypes",
            newName: "IX_DishTypes_Name");

        _ = migrationBuilder.AddPrimaryKey(
            name: "PK_DishTypes",
            table: "DishTypes",
            column: "Id");

        _ = migrationBuilder.AddForeignKey(
            name: "FK_Recipes_DishTypes_DishTypeId",
            table: "Recipes",
            column: "DishTypeId",
            principalTable: "DishTypes",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropForeignKey(
            name: "FK_Recipes_DishTypes_DishTypeId",
            table: "Recipes");

        _ = migrationBuilder.DropPrimaryKey(
            name: "PK_DishTypes",
            table: "DishTypes");

        _ = migrationBuilder.RenameTable(
            name: "DishTypes",
            newName: "DishType");

        _ = migrationBuilder.RenameIndex(
            name: "IX_DishTypes_Name",
            table: "DishType",
            newName: "IX_DishType_Name");

        _ = migrationBuilder.AddPrimaryKey(
            name: "PK_DishType",
            table: "DishType",
            column: "Id");

        _ = migrationBuilder.AddForeignKey(
            name: "FK_Recipes_DishType_DishTypeId",
            table: "Recipes",
            column: "DishTypeId",
            principalTable: "DishType",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}