import { Button, Divider, Grid2, Table, TableBody, TableCell, TableContainer, TableRow, TextField, Typography } from '@mui/material';
import { useParams } from 'react-router';
import { useFetchProductDetailsQuery } from './catalogApi';
import { useAddBasketItemMutation, useFetchBasketQuery, useRemoveBasketItemMutation } from '../basket/basketApi';
import { ChangeEvent, useEffect, useState } from 'react';

export default function ProductDetails() {
  const { id } = useParams<{ id: string }>();
  const [removeBasketItem] = useRemoveBasketItemMutation();
  const [addBasketItem] = useAddBasketItemMutation();
  const { data: basket } = useFetchBasketQuery();
  const item = basket?.items.find((x) => x.productId === +id!);
  const [quantity, setQuantity] = useState(0);

  useEffect(() => {
    if (item) setQuantity(item.quantity);
  }, [item]);

  const { data: product, isLoading } = useFetchProductDetailsQuery(id ? parseInt(id) : 0);

  if (isLoading || !product) return <h3>Loading...</h3>;

  if (!product) return <h3>Product not found</h3>;

  const handleUpdateBasket = () => {
    const updatedQuantity = item ? Math.abs(quantity - item.quantity) : quantity;
    if (!item || quantity > item.quantity) {
      addBasketItem({ product, quantity: updatedQuantity });
    } else {
      removeBasketItem({ productId: product.id, quantity: updatedQuantity });
    }
  };

  const handleInputChange = (event: ChangeEvent<HTMLInputElement>) => {
    const value = +event.currentTarget.value;
    if (value >= 0) setQuantity(value);
  };

  return (
    <Grid2 container spacing={6}>
      <Grid2 size={6}>
        <img src={product.imageUrl} alt={product.name} style={{ width: '100%' }} />
      </Grid2>
      <Grid2 size={6}>
        <Typography variant="h3">{product.name}</Typography>
        <Divider sx={{ mb: 2 }} />
        <Typography variant="h4" color="secondary">
          ${(product.price / 100).toFixed(2)}
        </Typography>
        <TableContainer>
          <Table sx={{ fontSize: '1rem' }}>
            <TableBody>
              <TableRow>
                <TableCell sx={{ fontWeight: 'bold' }}>Name</TableCell>
                <TableCell>{product.name}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell sx={{ fontWeight: 'bold' }}>Description</TableCell>
                <TableCell>{product.description}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell sx={{ fontWeight: 'bold' }}>Type</TableCell>
                <TableCell>{product.type}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell sx={{ fontWeight: 'bold' }}>Brand</TableCell>
                <TableCell>{product.brand}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell sx={{ fontWeight: 'bold' }}>Quantity in stock</TableCell>
                <TableCell>{product.quantityInStock}</TableCell>
              </TableRow>
            </TableBody>
          </Table>
        </TableContainer>
        <Grid2 container spacing={2} marginTop={3}>
          <Grid2 size={6}>
            <TextField onChange={handleInputChange} variant="outlined" type="number" label="Quantity in basket" fullWidth value={quantity} />
          </Grid2>
          <Grid2 size={6}>
            <Button
              onClick={handleUpdateBasket}
              disabled={quantity === item?.quantity || (!item && quantity === 0)}
              sx={{ height: '55px' }}
              color="primary"
              size="large"
              variant="contained"
              fullWidth
            >
              {item ? 'Update quantity' : 'Add to Basket'}
            </Button>
          </Grid2>
        </Grid2>
      </Grid2>
    </Grid2>
  );
}
