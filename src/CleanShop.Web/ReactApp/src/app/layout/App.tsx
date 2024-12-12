import { useEffect, useState } from "react"
import { Product } from "../models/product";

function App() {
  const [products,setProducts] = useState<Product[]>([]); 
  
  useEffect(() =>{
    fetch('http://localhost:5000/api/products')
    .then(response => response.json())
    .then(data => setProducts(data))
  },[])

  function addProduct(){
    setProducts(prevState => [...products,
      {
        id: prevState.length + 101,
        name: 'product' + (prevState.length + 1),
        description: "some description",
        price: (prevState.length *100) + 100,
        imageUrl:"http://flicker.com/abc",
        brand:"some brand"    
      }]);
  }

  return (
    <>      
      <h1>Clean-Shop</h1>     
      <ul>
        {products.map(item => (
          <li key={item.name}>{item.name} - {item.price}</li>
        ))}
      </ul>
      <button onClick={addProduct}>Add Product</button>
    </>
  )
}

export default App
