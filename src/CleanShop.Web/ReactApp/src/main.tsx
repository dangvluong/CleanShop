import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import './app/layout/style.css';
import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';
import { RouterProvider } from 'react-router';
import { router } from './app/router/Routes.tsx';
import { Provider } from 'react-redux';
import { store } from './app/store/store.ts';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <Provider store={store}>
      <ToastContainer position="top-right" hideProgressBar theme="colored" autoClose={3000} />
      <RouterProvider router={router} />
    </Provider>
  </StrictMode>
);
