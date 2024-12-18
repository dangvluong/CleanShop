import { useEffect, useState } from "react";
import { Product } from "../models/product";
import Catalog from "../../features/catalog/Catalog";
import Header from "./Header";
import { Container, CssBaseline } from "@mui/material";

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
      <CssBaseline />
      <Header />
      <Container>
        <Catalog addProduct={addProduct} products={products} />
      </Container>
    </>
  );
}

export default App;
