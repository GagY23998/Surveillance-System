import axios from "axios";

const axiosInstance= axios.create({ baseURL: "https://localhost:44332/api" });
axiosInstance.interceptors.response.use(function (response) { return response;}, (error) => {
    if (error.response.status === "401") {
        window.location.href = "/signin";
    }
    return Promise.reject(error);
});
const AuthService = {
    axios: axiosInstance,
    token: ""
};
export default AuthService;