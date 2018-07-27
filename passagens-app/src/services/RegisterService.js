import CONFIG from '../config'
import axios from 'axios'

export default class RegisterService {

    static register(login, senha, nome, ultimoNome, dataDeNascimento, email, cpf) {
        return axios.post(`${CONFIG.API_URL_BASE}/api/usuario`, {
            login,
            senha,
            nome,
            ultimoNome,
            cpf,
            email,
            dataDeNascimento
        })
    }
}