import { ingredientSchema } from '@/features/ingredients';
import { categorySchema } from '@/features/categories';
import * as z from 'zod';

export enum PreparationDifficulty {
    Easy = "Easy",
    Medium = "Medium",
    Hard = "Hard"
}

export const recipeIngredientSchema = z.object({
    id: z.number().int().positive(),
    ingredient: ingredientSchema,
    amount: z.number().positive()
});

export const preparationSchema = z.object({
    step: z.number().int().positive(),
    description: z.string().min(2).max(750),
})

export const recipeIngredientToPost = z.object({
    ingredientId: z.number().int().positive(),
    amount: z.number().positive()
});


export type TPreparation = z.infer<typeof preparationSchema>

export const recipeSchema = z.object({
    id: z.number().int().positive(),
    name: z.string().min(2).max(120),
    description: z.string(),
    difficulty: z.nativeEnum(PreparationDifficulty),
    recipeIngredients: z.array(recipeIngredientSchema),
    cuisine: categorySchema,
    mealTimes: z.array(categorySchema),
    diets: z.array(categorySchema),
    dishType: categorySchema,
    preparationSteps: z.array(preparationSchema)
});

export type TRecipe = z.infer<typeof recipeSchema>;

export const recipesSchema = z.array(recipeSchema);

export type TRecipeIngredient = z.infer<typeof recipeIngredientSchema>;

export type RecipeIngredientToPost = z.infer<typeof recipeIngredientToPost>;

export type PreparationStep = z.infer<typeof preparationSchema>;



