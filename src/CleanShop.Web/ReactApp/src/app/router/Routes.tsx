import { createBrowserRouter } from 'react-router';
import HomePage from '../../features/home/HomePage';
import App from '../layout/App';
import Catalog from '../../features/catalog/Catalog';
import ProductDetails from '../../features/catalog/ProductDetails';
import AboutPage from '../../features/about/AboutPage';
import ContactPage from '../../features/contact/ContactPage';
import BasketPage from '../../features/basket/BasketPage';

export const router = createBrowserRouter([
  {
    path: '/',
    element: <App />,
    children: [
      { path: '', element: <HomePage /> },
      { path: 'catalog', element: <Catalog /> },
      { path: 'catalog/:id', element: <ProductDetails /> },
      { path: 'about', element: <AboutPage /> },
      { path: 'basket', element: <BasketPage /> },
      { path: 'contact', element: <ContactPage /> },
    ],
  },
]);
