import { Fragment, useEffect, useState } from "react";
import { Product } from "../models/product";
import Catalog from "../../features/catalog/Catalog";
import { Typography } from "@mui/material";

function App() {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    fetch("http://localhost:5000/api/products")
      .then((response) => response.json())
      .then((data) => setProducts(data));
  }, []);

  function addProduct() {
    setProducts((prevState) => [
      ...products,
      {
        id: prevState.length + 101,
        name: "product" + (prevState.length + 1),
        description: "some description",
        price: prevState.length * 100 + 100,
        imageUrl: "http://flicker.com/abc",
        brand: "some brand",
      },
    ]);
  }

  return (
    <>      
      <Typography variant="h1">Clean-Shop</Typography>
      <Catalog addProduct={addProduct} products={products} />
    </>
  );
}

export default App;
