import { createApi } from '@reduxjs/toolkit/query/react';
import { baseQueryWithErrorHandling } from '../../app/api/baseApi';
import { User } from '../../app/models/user';
import { LoginSchema } from '../../lib/schemas/loginSchema';
import { router } from '../../app/router/Routes';

export const accountApi = createApi({
  reducerPath: 'accountApi',
  baseQuery: baseQueryWithErrorHandling,
  tagTypes: ['UserInfo'],
  endpoints: (builder) => ({
    login: builder.mutation<void, LoginSchema>({
      query: (credential) => {
        return {
          url: 'login?useCookies=true',
          method: 'POST',
          body: credential,
        };
      },
      async onQueryStarted(_, { dispatch, queryFulfilled }) {
        try {
          await queryFulfilled;
          dispatch(accountApi.util.invalidateTags(['UserInfo']));
        } catch (error) {
          console.log(error);
        }
      },
    }),
    register: builder.mutation<void, object>({
      query: (credential) => {
        return {
          url: 'account/register',
          method: 'POST',
          body: credential,
        };
      },
    }),
    userInfo: builder.query<User, void>({
      query: () => 'account/user-info',
      providesTags: ['UserInfo'],
    }),
    logout: builder.mutation({
      query: () => ({
        url: 'account/logout',
        method: 'POST',
      }),
      async onQueryStarted(_, { dispatch, queryFulfilled }) {
        await queryFulfilled;
        dispatch(accountApi.util.invalidateTags(['UserInfo']));
        router.navigate('/');
      },
    }),
  }),
});

export const { useLoginMutation, useRegisterMutation, useLogoutMutation, useUserInfoQuery } = accountApi;
