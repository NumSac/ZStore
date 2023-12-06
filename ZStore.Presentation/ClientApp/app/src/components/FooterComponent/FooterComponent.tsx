const FooterComponent = () => {
	return (
		<footer className="bg-gray-800 text-white bottom-0 right-0 w-full">
			<div className="max-w-7xl mx-auto py-12 px-4 sm:px-6 lg:px-8">
				<div className="grid grid-cols-2 gap-8">
					{/* Column 1 */}
					<div className="space-y-4">
						<h3 className="font-bold text-lg">Por qué comprar</h3>
						<nav className="list-none">
							<li>Cómo comprar</li>
							<li>Formas de pago</li>
							{/* More list items can be added here */}
						</nav>
					</div>

					{/* Column 2 */}
					<div className="space-y-4">
						<h3 className="font-bold text-lg">Quiénes somos</h3>
						<nav className="list-none">
							<li>Quiénes somos</li>
							<li>Compromisos</li>
							{/* More list items can be added here */}
						</nav>
					</div>

					{/* Add additional columns as needed */}
				</div>

				{/* Social Media and Awards */}
				<div className="mt-8 flex justify-between items-center">
					<div className="flex space-x-6">
						{/* Social Media Icons - use actual icons in place of text */}
						<a href="#" aria-label="Blog" className="text-white">
							Blog
						</a>
						<a href="#" aria-label="Instagram" className="text-white">
							Instagram
						</a>
						{/* More social icons */}
					</div>

					<div className="flex space-x-6">
						{/* Awards - use actual images in place of placeholders */}
						<img src="https://placehold.co/50x50?text=Award1" alt="Award 1" />
						<img src="https://placehold.co/50x50?text=Award2" alt="Award 2" />
						{/* More award images */}
					</div>
				</div>

				{/* Legal Text */}
				<div className="mt-8 border-t border-gray-700 pt-8">
					<p className="text-sm text-gray-400 text-center">
						PC Componentes y Multimedia SLU B73347494. AVDA Europa, Parcela 2-5
						y 2-6. Polígono industrial Las Salinas, 30840, Alhama de Murcia,
						Murcia. ESPAÑA.
					</p>
				</div>
			</div>
		</footer>
	);
};

export default FooterComponent;
