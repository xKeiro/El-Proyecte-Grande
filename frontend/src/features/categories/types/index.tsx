import * as z from 'zod'; 

export const categorySchema = z.object({
    id: z.number().int().positive(),
    name: z.string().min(2).max(60),
    })

export const categoriesSchema = z.array(categorySchema)

export type Category = z.infer<typeof categorySchema>

export enum CategoriesEnum {
    Cuisines = 'Cuisines',
    MealTimes = 'MealTimes',
    Diets = 'Diets',
    DishTypes = 'DishTypes'
}