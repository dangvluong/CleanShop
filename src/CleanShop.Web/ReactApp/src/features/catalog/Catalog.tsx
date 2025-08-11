import { Grid2 } from '@mui/material';
import { useFetchProductsQuery } from './catalogApi';
import Filters from './Filters';
import ProductList from './ProductList';

export default function Catalog() {
  const { data, isLoading } = useFetchProductsQuery();
  if (isLoading || !data) return <div>Loading...</div>;
  return (
    <Grid2 container spacing={4}>
      <Grid2 size={3}>
        <Filters />
      </Grid2>
      <Grid2 size={9}>
        <ProductList products={data}></ProductList>
      </Grid2>
    </Grid2>
  );
}
