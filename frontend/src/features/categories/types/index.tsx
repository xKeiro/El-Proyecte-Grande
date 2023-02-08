import * as z from 'zod'; 

export const categorySchema = z.object({
    id: z.number().int().positive(),
    name: z.string().min(2).max(60),
    unitOfMeasure: z.string().min(2).max(25),
    })

export type Category = z.infer<typeof categorySchema>