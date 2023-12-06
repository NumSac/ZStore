const ProductDetails = () => {
	return (
		<div className="bg-white py-8 px-4">
			<div className="max-w-2xl mx-auto flex">
				{/* Image Section */}
				<div className="flex-1">
					<img
						src="https://placehold.co/600x400"
						alt="Product"
						className="w-full h-auto"
					/>
					<div className="flex -mx-2 mt-4">
						<img
							src="https://placehold.co/100x100"
							alt="Product Thumbnail"
							className="mx-2"
						/>
						<img
							src="https://placehold.co/100x100"
							alt="Product Thumbnail"
							className="mx-2"
						/>
						{/* More thumbnails */}
					</div>
				</div>

				{/* Product Info Section */}
				<div className="flex-1 px-4">
					<h1 className="text-2xl font-bold mb-2">
						Ewent Spray de Aire Comprimido 400MI
					</h1>
					<p className="text-gray-500 mb-4">(5514 opiniones)</p>
					<div className="flex items-center mb-4">
						<button className="text-gray-600 hover:text-gray-800">
							<i className="far fa-heart"></i>
						</button>
						<div className="flex ml-2">
							<button className="text-gray-600 hover:text-gray-800">
								<i className="fab fa-facebook-f"></i>
							</button>
							<button className="text-gray-600 hover:text-gray-800 ml-2">
								<i className="fab fa-twitter"></i>
							</button>
							{/* More social buttons */}
						</div>
					</div>
					<div className="border-t border-b py-4 mb-4">
						<div className="flex justify-between items-center">
							<span className="text-gray-900 font-bold">3,48€</span>
							<span className="text-sm text-gray-500">
								Disponibilidad del producto
							</span>
						</div>
						{/* More product details */}
					</div>
					<button className="bg-orange-500 text-white py-2 px-4 rounded hover:bg-orange-600">
						Añadir al carrito
					</button>
					{/* More actions */}
				</div>
			</div>
		</div>
	);
};

export default ProductDetails;
