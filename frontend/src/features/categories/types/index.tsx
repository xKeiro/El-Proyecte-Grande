import * as z from 'zod'; 

export const categorySchema = z.object({
    id: z.number().int().positive(),
    name: z.string().min(2).max(60),
    })

export type Category = z.infer<typeof categorySchema>