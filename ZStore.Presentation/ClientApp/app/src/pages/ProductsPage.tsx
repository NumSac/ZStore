import ProductCard from "../components/ProductCard/ProductCard";

const products = [
	{ id: 1, name: "Product 1" /* other product details */ },
	{ id: 2, name: "Product 2" /* other product details */ },
	{ id: 3, name: "Product 3" /* other product details */ },
	{ id: 4, name: "Product 4" /* other product details */ },
	{ id: 5, name: "Product 5" /* other product details */ },
	{ id: 6, name: "Product 6" /* other product details */ },
	{ id: 7, name: "Product 7" /* other product details */ },
	{ id: 8, name: "Product 8" /* other product details */ },
	{ id: 9, name: "Product 9" /* other product details */ },
	{ id: 10, name: "Product 10" /* other product details */ },
];

// You can continue to add more products following the same pattern if needed.

const ProductsPage = () => {
	return (
		<div className="bg-white py-10">
			<div className="container mx-auto px-4">
				<div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-4">
					{products.map((product) => (
						<ProductCard key={product.id} {...product} />
					))}
				</div>
			</div>
		</div>
	);
};

export default ProductsPage;
