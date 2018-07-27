import CONFIG from '../config'
import axios from 'axios'
const LOGGED_USER = 'LOGGED_USER'

export default class LoginService {

    static setLoggedUser(token) {
		localStorage.setItem(LOGGED_USER, token.accessToken)
    }
    
	static login(login, senha) {
        return axios.post(`${CONFIG.API_URL_BASE}/api/usuario/login`, {
            login,
			senha
        }).then((result) => {
            this.setLoggedUser(result.data)
			return result
		})
    }
    
    static getLoggedUser() {
		return localStorage.getItem(LOGGED_USER)
	}

	static logout(login, senha) {
		localStorage.removeItem(LOGGED_USER);
	}
}