import Signup from "../components/Signup/Signup";

const AccountPage = () => {
	const onLogin = () => {
		console.log("Logged in");
	};

	return (
		<div className="bg-white">
			<Signup onLogin={onLogin} />
		</div>
	);
};

export default AccountPage;
