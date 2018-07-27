import React from 'react'
import Alert from '../../components/Alert/Alert'
import LoginService from '../../services/LoginService'
import Button from '../../components/Button/Button'
import Input from '../../components/Input/Input'
import { Redirect } from 'react-router-dom';

export default class LoginForm extends React.Component {

    constructor() {
        super()
        this.state = this.getInitialState()
        this.handleChange = this.handleChange.bind(this)
        this.onLoginButtonClick = this.onLoginButtonClick.bind(this)
    }

    goHome() {
        this.setState({
            shouldRedirectHome: true
        })
    }

    getInitialState() {
        return {
            username: '',
            password: '',
            shouldRedirectHome: false,
        }
    }

    handleChange(event) {
        const target = event.target
        const value = target.value
        const name = target.name
        this.setState({
            [name]: value
        })
    }

    onLoginButtonClick() {
        LoginService.login(this.state.username, this.state.password).then((result) => {
            this.goHome()
        }).catch(resp => {
            this.setState({
                error: resp.response.data.error
            })
        })
    }

    renderError() {
        return this.state.error ? <Alert classAlert="danger" text={this.state.error} /> : undefined
    }

    render() {
        if (this.state.shouldRedirectHome) {
            return <Redirect to='/home' />
        }
        return (
            <div>
                {this.renderError()}
                <Input placeholder="Usuário" name="username" type="text" handleChange={this.handleChange} />
                <Input placeholder="Senha" name="password" type="password" handleChange={this.handleChange} />
                <div className="pull-right">
                    <Button isOutline={true} classButton="primary" type="button" onClick={this.onLoginButtonClick} text="Login" />
                </div>
            </div>
        )
    }

}