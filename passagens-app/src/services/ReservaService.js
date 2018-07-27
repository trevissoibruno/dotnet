import CONFIG from '../config'
import axios from 'axios'


import LoginService from './LoginService'
export default class ReservaServive{
    


    static getTrechos() {
        return axios.get(`${CONFIG.API_URL_BASE}/api/trecho`,
         {
            headers: {
                Authorization: `Bearer ${LoginService.getLoggedUser()}`,
                'Content-Type': 'application/json',
            }
        })
    }

    static getOpcionais() {
        return axios.get(`${CONFIG.API_URL_BASE}/api/opcional`,
         {
            headers: {
                Authorization: `Bearer ${LoginService.getLoggedUser()}`,
                'Content-Type': 'application/json',
            }
        })
    }

    static getLocal() {
        return axios.get(`${CONFIG.API_URL_BASE}/api/local`,
         {
            headers: {
                Authorization: `Bearer ${LoginService.getLoggedUser()}`,
                'Content-Type': 'application/json',
            }
        })
    }


    static getClassesDeVoo() {
        return axios.get(`${CONFIG.API_URL_BASE}/api/classeDeVoo`,
         {
            headers: {
                Authorization: `Bearer ${LoginService.getLoggedUser()}`,
                'Content-Type': 'application/json',
            }
        })
    }

    static registerReserva(trecho,classeDeVoo,opcionais,usuario) {
        return axios.post(`${CONFIG.API_URL_BASE}/api/reserva`, {
           trecho,
           classeDeVoo,
           opcionais,
           usuario,
        })
    }
    
    static getReservas() {
        return axios.get(`${CONFIG.API_URL_BASE}/api/reserva`,
         {
            headers: {
                Authorization: `Bearer ${LoginService.getLoggedUser()}`,
                'Content-Type': 'application/json',
            }
        })
    }
    





}