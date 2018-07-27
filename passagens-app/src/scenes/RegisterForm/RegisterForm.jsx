import React from "react";

import RegisterService from '../../services/RegisterService'
import Input from "../../components/Input/Input";
import Button from "../../components/Button/Button";
import Alert from "../../components/Alert/Alert";
import { Redirect} from 'react-router-dom'
export default class RegisterForm extends React.Component {
  constructor() {
    super();
    this.state = this.getInitialState();
    this.handleChange = this.handleChange.bind(this);
    this.onRegisterButtonClick = this.onRegisterButtonClick.bind(this);
  }

  getInitialState() {
    return {
      login: "",
      senha: "",
      nome: "",
      ultimoNome: "",
      email: "",
      cpf: "",
      dataDeNascimento: "",
      shouldRedirectLogin: false,
    };
  }

  handleChange(event) {
    const target = event.target;
    const value = target.value;
    const name = target.name;
    this.setState({
      [name]: value
    });
  }

  goLogin() {
    this.setState({
        shouldRedirectLogin: true
    })
}

  onRegisterButtonClick() {
    RegisterService.register(
      this.state.login,
      this.state.senha,
      this.state.nome,
      this.state.ultimoNome,
      this.state.dataDeNascimento,
      this.state.email,
      this.state.cpf
    )
      .then(result => {
        this.props.onRegisterSuccess()
       
      })
      .catch(resp => {
        this.setState({
          error: resp.response.data.error
        });
      });
  }

  renderError() {
    return this.state.error ? (
      <Alert classAlert="danger" text={this.state.error} />
    ) : (
      undefined
    );
  }

  render() {
    if (this.state.shouldRedirectLogin) {
      return <Redirect to='/' />
  }
    return (
      <div className= "Container">
        {this.renderError()}
        <Input
          placeholder="Login"
          name="login"
          type="text"
          handleChange={this.handleChange}
          label="Login"
        />
        <Input
          placeholder="Senha"
          name="senha"
          type="password"
          handleChange={this.handleChange}
          label="Senha"
        />
        <Input
          placeholder="Nome"
          name="nome"
          type="text"
          handleChange={this.handleChange}
          label="Nome"
        />
        <Input
          placeholder="Ultimo Nome"
          name="ultimoNome"
          type="text"
          handleChange={this.handleChange}
          label="Ultimo Nome"
        />
        <Input
          placeholder="Email"
          name="email"
          type="text"
          handleChange={this.handleChange}
          label="Email"
        />
        <Input
          placeholder="CPF"
          name="cpf"
          type="text"
          handleChange={this.handleChange}
          label="CPF"
        />
        <Input
          placeholder="Data de Nascimento"
          name="dataDeNascimento"
          type="date"
          handleChange={this.handleChange}
          label="dataDeNascimento"
        />
        <div className="pull-right">
          <Button
            isOutline={true}
            classButton="primary"
            type="button"
            onClick={this.onRegisterButtonClick}
            text="Registrar"
          />
        </div>
      </div>
    );
  }
}
