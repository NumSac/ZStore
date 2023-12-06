import { Route, Routes } from "react-router-dom";
import FooterComponent from "./components/FooterComponent/FooterComponent";
import HeaderComponent from "./components/HeaderComponent/HeaderComponent";
import AccountPage from "./pages/AccountPage";
import HomePage from "./pages/HomePage";
import ProductsPage from "./pages/ProductsPage";
import ProfilePage from "./pages/ProfilePage";

function App() {
	return (
		<div className="flex flex-col min-h-screen">
			<HeaderComponent />
			<div className="bg-zinc-600">
				<Routes>
					<Route index element={<HomePage />} />
					<Route path="products">
						<Route index element={<ProductsPage />} />
					</Route>
					<Route path="/profile" element={<ProfilePage />} />
					<Route path="/account" element={<AccountPage />} />
				</Routes>
			</div>
			<FooterComponent />
		</div>
	);
}

export default App;
