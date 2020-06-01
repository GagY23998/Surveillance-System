import axios from "axios";

const AuthService = axios.create({
    baseURL: "https://localhost:44332/api", headers: {
        "authorization":  localStorage["token"]?"Bearer " + localStorage["token"]:null
    }
});
AuthService.interceptors.response.use(function (response) { return response;}, (error) => {
    if (error.response.status === "401") {
        window.location.href = "/signin";
    }
    return Promise.reject(error);
});
export default AuthService;