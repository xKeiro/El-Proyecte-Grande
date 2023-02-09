import * as z from 'zod'; 

export const ingredientSchema = z.object({
    id: z.number().int().positive(),
    name: z.string().min(2).max(60),
    unitOfMeasure: z.string().min(1).max(25),
    })

export const ingredientsSchema = z.array(ingredientSchema)

export type Ingredient = z.infer<typeof ingredientSchema>