import { ingredientSchema } from '@/features/ingredients';
import { categorySchema } from '@/features/categories';
import * as z from 'zod'; 

export const recipeIngredientSchema = z.object({
    id: z.number().int().positive(),
    ingredient: ingredientSchema,
    amount: z.number().int().positive()
});

export const recipesSchema =z.array(z.object({
    id: z.number().int().positive(),
    name: z.string().min(2).max(120),
    description: z.string(),
    recipeIngredients: z.array(recipeIngredientSchema),
    cuisine: categorySchema,
    mealTimes: z.array(categorySchema),
    diets: z.array(categorySchema),
    dishType: categorySchema
}))

export type RecipeIngredient = z.infer<typeof recipeIngredientSchema>;


export const recipeSchema = z.object({
    id: z.number().int().positive(),
    name: z.string().min(2).max(120),
    description: z.string(),
    recipeIngredients: z.array(recipeIngredientSchema),
    cuisine: categorySchema,
    mealTimes: z.array(categorySchema),
    diets: z.array(categorySchema),
    dishType: categorySchema
});

export type Recipe = z.infer<typeof recipeSchema>;