import { useEffect, useState } from "react";
import { Product } from "../models/product";
import Catalog from "../../features/catalog/Catalog";
import { Container, CssBaseline } from "@mui/material";
import Header from "./Header";


function App() {
  const [products, setProducts] = useState<Product[]>([]);

  // Fetch initial products from the API
  useEffect(() => {
    fetch('http://localhost:5000/api/products')
      .then(response => response.json())
      .then(data => setProducts(data))
      .catch(error => console.error("Error fetching products:", error));
  }, []);

  // Function to add a new product to the list
  function addProduct() {
    setProducts(prevState => [
      ...prevState,
      {
        id: prevState.length + 1,
        name: `Product ${prevState.length + 1}`,
        description: "Some description",
        price: 100 * (prevState.length + 1),
        brand: "Some brand",
        pictureUrl: "http://picsum.photos/200"
      } as Product // Cast the object to type `Product`
    ]);
  }

  return (
    <>
      <CssBaseline />
      <Header />
      <Container>
        <Catalog products={products} addProduct={addProduct} />
      </Container>
      
    </>
  );
}

export default App;
