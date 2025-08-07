import { Typography } from '@mui/material';
import { useFetchBasketQuery } from './basketApi';

export default function BasketPage() {
  const { data, isLoading } = useFetchBasketQuery();

  if (isLoading) return <Typography>Loading...</Typography>;

  if (!data) return <Typography variant="h3">No items found</Typography>;

  return <div>BasketPage</div>;
}
