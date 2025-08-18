import z from 'zod';

const passwordValidation = new RegExp(/(?=^.{6,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$/);

export const registerSchema = z.object({
  email: z.string().email(),
  password: z.string().regex(passwordValidation, {
    message: 'Password must contain lower case, uppercase, number, special characters and be 6-10 characters.',
  }),
});

export type RegisterSchema = z.infer<typeof registerSchema>;
