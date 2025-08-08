import { Grid2, Typography } from '@mui/material';
import { useFetchBasketQuery } from './basketApi';
import BasketItem from './BasketItem';

export default function BasketPage() {
  const { data, isLoading } = useFetchBasketQuery();

  if (isLoading) return <Typography>Loading...</Typography>;

  if (!data) return <Typography variant="h3">No items found</Typography>;

  return (
    <Grid2 container spacing={4}>
      <Grid2 size={8}>
        {data.items.map((item) => (
          <BasketItem item={item} key={item.productId} />
        ))}
      </Grid2>
    </Grid2>
  );
}
