const ProductCard = () => {
	return (
		<div className="bg-white p-4 rounded-lg shadow-md w-full">
			<div className="flex flex-col items-center">
				<img
					src="https://placehold.co/150x100"
					alt="Corsair Vengeance RGB Pro"
					className="w-32 h-20 object-cover mb-4"
				/>

				{/* Product Tags */}
				<div className="flex space-x-2 mb-2">
					<span className="bg-green-200 text-green-800 text-xs font-semibold mr-2 px-2.5 py-0.5 rounded">
						Envio gratis
					</span>
					<span className="bg-yellow-200 text-yellow-800 text-xs font-semibold px-2.5 py-0.5 rounded">
						Trending
					</span>
				</div>

				{/* Product Name */}
				<h3 className="text-md font-bold text-gray-900 mb-2">
					Corsair Vengeance RGB Pro DDR4 3200 PC4-25600 32GB 2x16GB CL16
				</h3>

				{/* Product Price */}
				<p className="text-lg font-bold text-orange-600 mb-1">76,99€</p>
				<p className="text-xs text-gray-500 mb-2">¡Precio mínimo histórico!</p>

				{/* Rating and Reviews */}
				<div className="flex items-center mb-4">
					<div className="flex text-yellow-400 text-sm">
						<i className="fas fa-star"></i>
						<i className="fas fa-star"></i>
						<i className="fas fa-star"></i>
						<i className="fas fa-star"></i>
						<i className="fas fa-star-half-alt"></i>
					</div>
					<p className="text-xs text-gray-600 ml-2">(646)</p>
				</div>

				{/* Additional Information */}
				<p className="text-xs text-gray-600 mb-1">
					Recíbelo el lunes 11 de diciembre
				</p>
				<p className="text-xs text-gray-600 mb-1">Vendido por PcComponentes</p>
				<p className="text-xs text-gray-600">Quedan 366 unidades</p>
			</div>
		</div>
	);
};

export default ProductCard;
