import {
  Button,
  Divider,
  Grid,
  Grid2,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableRow,
  TextField,
  Typography,
} from '@mui/material';
import axios from 'axios';
import { useEffect, useState } from 'react';
import { useParams } from 'react-router';
import { Product } from '../../app/models/product';

export default function ProductDetails() {
  const { id } = useParams<{ id: string }>();
  const [product, setProduct] = useState<Product | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    axios
      .get(`http://localhost:5000/api/products/${id}`)
      .then((response) => setProduct(response.data))
      .catch((error) => console.log(error))
      .finally(() => setLoading(false));
  }, [id]);

  if (loading) return <h3>Loading...</h3>;

  if (!product) return <h3>Product not found</h3>;

  return (
    <Grid2 container spacing={6}>
      <Grid2 size={6}>
        <img
          src={product.imageUrl}
          alt={product.name}
          style={{ width: '100%' }}
        />
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
                <TableCell sx={{ fontWeight: 'bold' }}>
                  Quantity in stock
                </TableCell>
                <TableCell>{product.quantityInStock}</TableCell>
              </TableRow>
            </TableBody>
          </Table>
        </TableContainer>
        <Grid2 container spacing={2} marginTop={3}>
          <Grid2 size={6}>
            <TextField
              variant="outlined"
              type="number"
              label="Quantity in basket"
              fullWidth
              defaultValue={1}
            />
          </Grid2>
          <Grid2 size={6}>
            <Button
              sx={{ height: '55px' }}
              color="primary"
              size="large"
              variant="contained"
              fullWidth
            >
              Add to Basket
            </Button>
          </Grid2>
        </Grid2>
      </Grid2>
    </Grid2>
  );
}
