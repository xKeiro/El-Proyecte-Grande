import * as z from 'zod';

export enum UserRecipeStatus {
    Liked = "Liked",
    Disliked = "Disliked",
    Saved = "Saved"
}

export const userRecipeStatusSchema = z.object({
    id: z.number().int().positive(),
    name: z.nativeEnum(UserRecipeStatus)
})

export type TUserRecipeStatus = z.infer<typeof userRecipeStatusSchema>

export const userRecipeAddNew = z.object({
    recipeStatus: z.nativeEnum(UserRecipeStatus)
})
export type TUserRecipeAddNew = z.infer<typeof userRecipeAddNew>

export const userSchema = z.object({
    id: z.number().int().positive(),
    username: z.string().min(2).max(50),
    emailAddress: z.string().email(),
    firstName: z.string().min(2).max(100).nullable(),
    lastName: z.string().min(2).max(100).nullable(),
    isAdmin: z.boolean()
})

export type TUser = z.infer<typeof userSchema>