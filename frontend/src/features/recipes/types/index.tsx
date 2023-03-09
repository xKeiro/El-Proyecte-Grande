import { ingredientSchema } from '@/features/ingredients';
import { categorySchema } from '@/features/categories';
import * as z from 'zod';

export const recipeIngredientSchema = z.object({
    id: z.number().int().positive(),
    ingredient: ingredientSchema,
    amount: z.number().positive()
});

export const preparationSchema = z.object({
    step: z.number().int().positive(),
    description: z.string().min(2).max(750),
})

export type TPreparation = z.infer<typeof preparationSchema>

export const recipesSchema = z.array(z.object({
    id: z.number().int().positive(),
    name: z.string().min(2).max(120),
    description: z.string(),
    recipeIngredients: z.array(recipeIngredientSchema),
    cuisine: categorySchema,
    mealTimes: z.array(categorySchema),
    diets: z.array(categorySchema),
    dishType: categorySchema,
    preparationSteps: z.array(preparationSchema)
}))

export type TRecipeIngredient = z.infer<typeof recipeIngredientSchema>;

export const recipeSchema = z.object({
    id: z.number().int().positive(),
    name: z.string().min(2).max(120),
    description: z.string(),
    recipeIngredients: z.array(recipeIngredientSchema),
    cuisine: categorySchema,
    mealTimes: z.array(categorySchema),
    diets: z.array(categorySchema),
    dishType: categorySchema,
    preparationSteps: z.array(preparationSchema)
});

export const recipesSchemaWithPagination = z.object({
    recipes: z.array(recipeSchema),
    nextPage: z.number().int().positive().nullable()
})

export type TRecipesWithPagination = z.infer<typeof recipesSchemaWithPagination>;

export type TRecipe = z.infer<typeof recipeSchema>;

export enum PreparationDifficulty {
    Easy = "Easy",
    Medium = "Medium",
    Hard = "Hard"
}