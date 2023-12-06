import { Link } from "react-router-dom";

const HeaderComponent = () => {
	return (
		<nav className="bg-zinc-600 text-white p-4">
			<div className="flex items-center justify-between">
				{/* Logo on the left */}
				<Link to={"/"} className="flex items-center">
					<img
						className="h-8 mr-3"
						src="https://placehold.co/150x50?text=LOGO"
						alt="Shop Logo"
					/>
				</Link>

				{/* Search bar */}
				<div className="flex-1 mx-10">
					<div className="relative">
						<span className="absolute inset-y-0 left-0 flex items-center pl-3">
							<i className="fas fa-search text-gray-500"></i>
						</span>
						<input
							type="search"
							className="w-full py-2 pl-10 pr-4 bg-white rounded-md shadow-sm border border-gray-300 text-gray-700 focus:ring-blue-500 focus:border-blue-500"
							placeholder="Buscar"
						/>
					</div>
				</div>

				{/* Account and Cart on the right */}
				<div className="flex items-center space-x-6">
					<a
						href="#"
						className="text-sm font-medium text-white hover:text-gray-300"
					>
						Compromisos
					</a>
					<Link
						to={"/profile"}
						className="text-sm font-medium text-white hover:text-gray-300"
					>
						Mi cuenta
					</Link>

					<div className="relative">
						<a
							href="#"
							className="text-sm font-medium text-white hover:text-gray-300"
						>
							<i className="fas fa-shopping-cart"></i>
							Mi cesta
						</a>
						<span className="absolute top-0 right-0 inline-block w-5 h-5 text-xs text-center text-white bg-red-600 rounded-full">
							0
						</span>
					</div>
				</div>
			</div>
		</nav>
	);
};

export default HeaderComponent;
