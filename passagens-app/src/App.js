import React, { Component } from 'react';
import { Switch, Route, Redirect} from 'react-router-dom'
import './App.css';
import NotFound from './scenes/NotFound/NotFound'
import Home from './scenes/Home/Home'
import LoginService from './services/LoginService'
import DashboradUsuario from './scenes/DashboardUsuario/DashboardUsuario'
import RegisterForm from './scenes/RegisterForm/RegisterForm'
import Login from './scenes/Login/Login'
class App extends Component {
  constructor() {
    super()
    this.onClickLogoutButton = this.onClickLogoutButton.bind(this)
    this.state = {}
  }
  onClickLogoutButton() {
    LoginService.logout().then(() => {
      return <Redirect to={"/"} />
    })
  }
  render() {
    return (
      <div className="App">
        <Switch>
          <Route path="/404" component={NotFound} />
          <Route path="/" exact component={Login} />
          <Route path="/home" exact component={Home} />
          <Route path="/dashboradUsuario" component={DashboradUsuario}/>
          <Route path="/register" component={RegisterForm} />
          <Redirect to="/404" />
        </Switch>
      </div>
    );
  }
}

export default App;
