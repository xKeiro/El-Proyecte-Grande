using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElProyecteGrande.Migrations;

/// <inheritdoc />
public partial class Init : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.CreateTable(
            name: "Cuisines",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Cuisines", x => x.Id));

        _ = migrationBuilder.CreateTable(
            name: "Diets",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Diets", x => x.Id));

        _ = migrationBuilder.CreateTable(
            name: "DishType",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_DishType", x => x.Id));

        _ = migrationBuilder.CreateTable(
            name: "Ingredients",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                UnitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Ingredients", x => x.Id));

        _ = migrationBuilder.CreateTable(
            name: "MealTimes",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_MealTimes", x => x.Id));

        _ = migrationBuilder.CreateTable(
            name: "UserRecipeStatuses",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_UserRecipeStatuses", x => x.Id));

        _ = migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                EmailAddress = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                IsAdmin = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Users", x => x.Id));

        _ = migrationBuilder.CreateTable(
            name: "Recipes",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CuisineId = table.Column<int>(type: "int", nullable: false),
                DishTypeId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_Recipes", x => x.Id);
                _ = table.ForeignKey(
                    name: "FK_Recipes_Cuisines_CuisineId",
                    column: x => x.CuisineId,
                    principalTable: "Cuisines",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "FK_Recipes_DishType_DishTypeId",
                    column: x => x.DishTypeId,
                    principalTable: "DishType",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateTable(
            name: "DietRecipe",
            columns: table => new
            {
                DietsId = table.Column<int>(type: "int", nullable: false),
                RecipesId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_DietRecipe", x => new { x.DietsId, x.RecipesId });
                _ = table.ForeignKey(
                    name: "FK_DietRecipe_Diets_DietsId",
                    column: x => x.DietsId,
                    principalTable: "Diets",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "FK_DietRecipe_Recipes_RecipesId",
                    column: x => x.RecipesId,
                    principalTable: "Recipes",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateTable(
            name: "MealTimeRecipe",
            columns: table => new
            {
                MealTimesId = table.Column<int>(type: "int", nullable: false),
                RecipesId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_MealTimeRecipe", x => new { x.MealTimesId, x.RecipesId });
                _ = table.ForeignKey(
                    name: "FK_MealTimeRecipe_MealTimes_MealTimesId",
                    column: x => x.MealTimesId,
                    principalTable: "MealTimes",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "FK_MealTimeRecipe_Recipes_RecipesId",
                    column: x => x.RecipesId,
                    principalTable: "Recipes",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateTable(
            name: "RecipeIngredients",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                IngredientId = table.Column<int>(type: "int", nullable: false),
                Amount = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                RecipeId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_RecipeIngredients", x => x.Id);
                _ = table.ForeignKey(
                    name: "FK_RecipeIngredients_Ingredients_IngredientId",
                    column: x => x.IngredientId,
                    principalTable: "Ingredients",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "FK_RecipeIngredients_Recipes_RecipeId",
                    column: x => x.RecipeId,
                    principalTable: "Recipes",
                    principalColumn: "Id");
            });

        _ = migrationBuilder.CreateTable(
            name: "RecipeReviews",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                UserId = table.Column<int>(type: "int", nullable: false),
                RecipeId = table.Column<int>(type: "int", nullable: false),
                Rate = table.Column<int>(type: "int", nullable: false),
                Review = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_RecipeReviews", x => x.Id);
                _ = table.ForeignKey(
                    name: "FK_RecipeReviews_Recipes_RecipeId",
                    column: x => x.RecipeId,
                    principalTable: "Recipes",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "FK_RecipeReviews_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateTable(
            name: "UserRecipes",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                UserId = table.Column<int>(type: "int", nullable: false),
                RecipeId = table.Column<int>(type: "int", nullable: false),
                StatusId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("PK_UserRecipes", x => x.Id);
                _ = table.ForeignKey(
                    name: "FK_UserRecipes_Recipes_RecipeId",
                    column: x => x.RecipeId,
                    principalTable: "Recipes",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "FK_UserRecipes_UserRecipeStatuses_StatusId",
                    column: x => x.StatusId,
                    principalTable: "UserRecipeStatuses",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "FK_UserRecipes_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateIndex(
            name: "IX_Cuisines_Name",
            table: "Cuisines",
            column: "Name",
            unique: true);

        _ = migrationBuilder.CreateIndex(
            name: "IX_DietRecipe_RecipesId",
            table: "DietRecipe",
            column: "RecipesId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Diets_Name",
            table: "Diets",
            column: "Name",
            unique: true);

        _ = migrationBuilder.CreateIndex(
            name: "IX_DishType_Name",
            table: "DishType",
            column: "Name",
            unique: true);

        _ = migrationBuilder.CreateIndex(
            name: "IX_Ingredients_Name",
            table: "Ingredients",
            column: "Name",
            unique: true);

        _ = migrationBuilder.CreateIndex(
            name: "IX_MealTimeRecipe_RecipesId",
            table: "MealTimeRecipe",
            column: "RecipesId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_MealTimes_Name",
            table: "MealTimes",
            column: "Name",
            unique: true);

        _ = migrationBuilder.CreateIndex(
            name: "IX_RecipeIngredients_IngredientId",
            table: "RecipeIngredients",
            column: "IngredientId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_RecipeIngredients_RecipeId",
            table: "RecipeIngredients",
            column: "RecipeId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_RecipeReviews_RecipeId",
            table: "RecipeReviews",
            column: "RecipeId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_RecipeReviews_UserId",
            table: "RecipeReviews",
            column: "UserId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Recipes_CuisineId",
            table: "Recipes",
            column: "CuisineId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Recipes_DishTypeId",
            table: "Recipes",
            column: "DishTypeId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_UserRecipes_RecipeId",
            table: "UserRecipes",
            column: "RecipeId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_UserRecipes_StatusId",
            table: "UserRecipes",
            column: "StatusId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_UserRecipes_UserId",
            table: "UserRecipes",
            column: "UserId");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Users_EmailAddress",
            table: "Users",
            column: "EmailAddress",
            unique: true);

        _ = migrationBuilder.CreateIndex(
            name: "IX_Users_Username",
            table: "Users",
            column: "Username",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "DietRecipe");

        _ = migrationBuilder.DropTable(
            name: "MealTimeRecipe");

        _ = migrationBuilder.DropTable(
            name: "RecipeIngredients");

        _ = migrationBuilder.DropTable(
            name: "RecipeReviews");

        _ = migrationBuilder.DropTable(
            name: "UserRecipes");

        _ = migrationBuilder.DropTable(
            name: "Diets");

        _ = migrationBuilder.DropTable(
            name: "MealTimes");

        _ = migrationBuilder.DropTable(
            name: "Ingredients");

        _ = migrationBuilder.DropTable(
            name: "Recipes");

        _ = migrationBuilder.DropTable(
            name: "UserRecipeStatuses");

        _ = migrationBuilder.DropTable(
            name: "Users");

        _ = migrationBuilder.DropTable(
            name: "Cuisines");

        _ = migrationBuilder.DropTable(
            name: "DishType");
    }
}