import React from 'react'
import './NavBar.css'
import {
    Navbar,
    NavbarToggler,
    NavbarBrand,
    Nav,
    NavItem,
    
  } from 'reactstrap';
  import { Link } from 'react-router-dom'

export default class NavBar extends React.Component {

    render(){
        return(
          <div className="header">
            <Navbar color="light" light expand="md">
            <NavbarBrand href="/home">American Airlines</NavbarBrand>
            <NavbarToggler />
            <Nav className="ml-auto" navbar>
              <NavItem>
                <Link className="nav--link home" to='/home'>Home</Link>
              </NavItem>
              <NavItem>
                <Link className="nav--link" to='/dashboradUsuario' >Realizar Reserva</Link>
              </NavItem>
              <li onClick={this.onClickLogoutButton}>
                <Link className="nav--link" to='/' >Logout</Link>
              </li>
            </Nav>
          </Navbar>
          </div>
          
        );
    }
}