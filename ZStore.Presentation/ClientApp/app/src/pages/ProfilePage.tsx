import { Navigate } from "react-router-dom";

const ProfilePage = () => {
	const isSignedIn: boolean = false;

	return isSignedIn ? "Hello Profile Page" : <Navigate to={"/account"} />;
};

export default ProfilePage;
