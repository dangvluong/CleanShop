import { Product } from "../../app/models/product";

interface Props {
  product: Product[];
  addProduct: () => void;
}

export default function Catalog({ product, addProduct }: Props) {
  return (
    <>
      <ul>
        {product.map((item) => (
          <li key={item.name}>
            {item.name} - {item.price}
          </li>
        ))}
      </ul>
      <button onClick={addProduct}>Add Product</button>
    </>
  );
}
