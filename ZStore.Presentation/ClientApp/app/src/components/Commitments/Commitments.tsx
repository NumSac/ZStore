import React from "react";

// Define a type for the props of the CommitmentCard component
type CommitmentCardProps = {
	icon: string;
	label: string;
};

const CommitmentCard: React.FC<CommitmentCardProps> = ({ icon, label }) => (
	<div className="flex flex-col items-center p-4 bg-white rounded-lg shadow">
		<div className="text-3xl">{icon}</div>
		<div className="mt-2 text-sm font-semibold">{label}</div>
	</div>
);

// Define a type for the icon data
type IconItem = {
	icon: string;
	label: string;
};

const Commitments: React.FC = () => {
	// Define your icon components or use placeholders
	const icons: IconItem[] = [
		{ icon: "👥", label: "Quiénes somos" },
		{ icon: "❤️", label: "Nuestros compromisos" },
		{ icon: "✅", label: "Opina sobre nosotros" },
		{ icon: "💼", label: "Nuestros servicios" },
		{ icon: "📢", label: "Sala de prensa" },
	];

	return (
		<div className="my-8 bg-zinc-600 p-10">
			<h2 className="text-xl font-bold text-zinc-900 text-center mb-6">
				Compromisos con el cliente
			</h2>
			<div className="flex justify-around">
				{icons.map((item, index) => (
					<CommitmentCard key={index} icon={item.icon} label={item.label} />
				))}
			</div>
		</div>
	);
};

export default Commitments;
