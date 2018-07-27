import React from 'react'
import './home.css'
import { Alert } from 'reactstrap';
import NavBar from '../../components/generic/NavBar/NavBar'
export default class Home extends React.Component {

    render() {
        return <div className="home">
           <NavBar/>
            <Alert color='primary'>
                <h1>Bem Vindo American Airlines</h1>
                <h2>Faça sua reserva.</h2>
            </Alert>
        </div>
    }

}