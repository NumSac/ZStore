import React, { useState } from "react";

type SignupProps = {
	// Define any props here. For example, a callback for when the form is submitted:
	onLogin: (email: string, password: string) => void;
};

const Signup: React.FC<SignupProps> = ({ onLogin }) => {
	const [email, setEmail] = useState("");
	const [password, setPassword] = useState("");

	const handleSubmit = (event: React.FormEvent) => {
		event.preventDefault();
		onLogin(email, password);
	};

	return (
		<div className="flex justify-center items-center h-screen">
			<div className="border-r border-gray-300 pr-10 mr-10">
				<h2 className="text-lg font-semibold mb-4">Gestiona tus pedidos</h2>
				<p>
					Ten el control de todos tus pedidos y recibe <br /> notificaciones con
					el seguimiento
				</p>
				<h2 className="text-lg font-semibold mb-4 mt-6">
					Lista de deseos personalizada
				</h2>
				<p>
					Guarda tus productos favoritos en las <br /> listas de deseos
					personalizadas
				</p>
			</div>
			<div>
				<h2 className="text-lg font-semibold mb-4">Iniciar sesión</h2>
				<button className="mb-4">Über Google anmelden</button>
				<p className="mb-4">O bien</p>
				<form className="flex flex-col" onSubmit={handleSubmit}>
					<input
						type="email"
						placeholder="E-mail"
						value={email}
						onChange={(e) => setEmail(e.target.value)}
						required
						className="mb-4 p-2 border border-gray-300 rounded"
					/>
					<input
						type="password"
						placeholder="Contraseña"
						value={password}
						onChange={(e) => setPassword(e.target.value)}
						required
						className="mb-4 p-2 border border-gray-300 rounded"
					/>
					<a href="#" className="text-sm mb-4">
						He olvidado mi contraseña
					</a>
					<button
						type="submit"
						className="bg-orange-500 text-white p-2 rounded w-full"
					>
						Iniciar sesión
					</button>
				</form>
				<div className="mt-4">
					<p>¿Eres nuevo cliente?</p>
					<button className="p-2">Crear cuenta</button>
				</div>
			</div>
		</div>
	);
};

export default Signup;
