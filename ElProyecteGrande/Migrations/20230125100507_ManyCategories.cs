using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElProyecteGrande.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diets_Categorizations_CategorizationId",
                table: "Diets");

            migrationBuilder.DropForeignKey(
                name: "FK_MealTimes_Categorizations_CategorizationId",
                table: "MealTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients");

            migrationBuilder.DropIndex(
                name: "IX_MealTimes_CategorizationId",
                table: "MealTimes");

            migrationBuilder.DropIndex(
                name: "IX_Diets_CategorizationId",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "CategorizationId",
                table: "MealTimes");

            migrationBuilder.DropColumn(
                name: "CategorizationId",
                table: "Diets");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "RecipeIngredients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "CategorizationDiet",
                columns: table => new
                {
                    CategorizationsId = table.Column<int>(type: "int", nullable: false),
                    DietsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorizationDiet", x => new { x.CategorizationsId, x.DietsId });
                    table.ForeignKey(
                        name: "FK_CategorizationDiet_Categorizations_CategorizationsId",
                        column: x => x.CategorizationsId,
                        principalTable: "Categorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorizationDiet_Diets_DietsId",
                        column: x => x.DietsId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategorizationMealTime",
                columns: table => new
                {
                    CategorizationsId = table.Column<int>(type: "int", nullable: false),
                    MealTimesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorizationMealTime", x => new { x.CategorizationsId, x.MealTimesId });
                    table.ForeignKey(
                        name: "FK_CategorizationMealTime_Categorizations_CategorizationsId",
                        column: x => x.CategorizationsId,
                        principalTable: "Categorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorizationMealTime_MealTimes_MealTimesId",
                        column: x => x.MealTimesId,
                        principalTable: "MealTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealTimes_Name",
                table: "MealTimes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DishTypes_Name",
                table: "DishTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diets_Name",
                table: "Diets",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cuisines_Name",
                table: "Cuisines",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategorizationDiet_DietsId",
                table: "CategorizationDiet",
                column: "DietsId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorizationMealTime_MealTimesId",
                table: "CategorizationMealTime",
                column: "MealTimesId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "CategorizationDiet");

            migrationBuilder.DropTable(
                name: "CategorizationMealTime");

            migrationBuilder.DropIndex(
                name: "IX_MealTimes_Name",
                table: "MealTimes");

            migrationBuilder.DropIndex(
                name: "IX_DishTypes_Name",
                table: "DishTypes");

            migrationBuilder.DropIndex(
                name: "IX_Diets_Name",
                table: "Diets");

            migrationBuilder.DropIndex(
                name: "IX_Cuisines_Name",
                table: "Cuisines");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "RecipeIngredients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategorizationId",
                table: "MealTimes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategorizationId",
                table: "Diets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MealTimes_CategorizationId",
                table: "MealTimes",
                column: "CategorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_CategorizationId",
                table: "Diets",
                column: "CategorizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_Categorizations_CategorizationId",
                table: "Diets",
                column: "CategorizationId",
                principalTable: "Categorizations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MealTimes_Categorizations_CategorizationId",
                table: "MealTimes",
                column: "CategorizationId",
                principalTable: "Categorizations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
