import { Grid, List } from "@mui/material"
import { Product } from "../../app/models/product"
import ProductCard from "./ProductCard";

interface Props {
    products: Product[];
}

export default function ProductList({products}: Props) {
    return (
        // <List>
        //     {products.map(product => (
        //         <ProductCard key={product.id} product={product}/>
        //     ))}
        // </List>
        <Grid container spacing={4}>
            {products.map(product => (
                // first we are looping do put key here
                <Grid item xs={3} key={product.id}> 
                    <ProductCard product={product}/>
                </Grid>  
            ))}
        </Grid>
    )
}

