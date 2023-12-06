import "./Header.css"; // Make sure to create an App.css file for additional styles if needed

const Header = () => {
	return (
		<div className="bg-white">
			{" "}
			{/* Replace with the actual color from the screenshot */}
			<div className="container mx-auto px-4 py-8">
				<div className="bg-orange-600 rounded-lg shadow-lg p-6 text-white">
					{" "}
					{/* Adjust the color to match the deal-banner */}
					<div className="flex justify-between items-center">
						<div className="text-left">
							<p className="text-sm">Financiación en</p>
							<p className="text-xl font-bold">
								24 meses sin intereses TAE 9,54%
							</p>
							<p className="text-xs">
								*Importe mínimo: 288 €. Ejemplo de financiación para un importe
								de 600 € en 24 meses. Comisión de formalización del 9,00%: 54 €
								a pagar en la primera cuota. Primera cuota de 79 € y 23 cuotas
								de 25 €. TIN 0,00% TAE: 9,54%. Coste total del crédito: 54 €.
								Importe total adeudado y precio total a plazos: 654 €. Precio de
								adquisición al contado: 600 €. Intereses subvencionados por PC
								COMPONENTES. Financiación ofrecida por Banco Cetelem S.A.U.
								válida hasta el 17/12/2023
							</p>
						</div>
						<div>
							<button className="border hover:bg-white hover:text-orange-600 text-white font-bold py-2 px-4 rounded">
								Ver ahora
							</button>
						</div>
					</div>
				</div>
				<div className="grid grid-cols-2 md:grid-cols-4 gap-4 mt-8">
					{/* Duplicate the items as needed to match the bottom row of the screenshot */}
					{Array.from({ length: 8 }, (_, i) => (
						<div
							className="category-item text-center p-4 bg-orange-200 rounded-lg shadow-md"
							key={i}
						>
							{" "}
							{/* Adjust the colors to match the categories */}
							<img
								src={`https://placehold.co/200x150?text=Product+${i + 1}`}
								alt={`Placeholder for product category ${i + 1}`}
								className="mx-auto mb-4"
							/>
							<p>Categoría {i + 1}</p>
						</div>
					))}
				</div>
			</div>
		</div>
	);
};

export default Header;
