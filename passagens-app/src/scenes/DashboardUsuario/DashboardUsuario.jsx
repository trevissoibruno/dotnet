import React from "react";
import NavBar from "../../components/generic/NavBar/NavBar";
import Opcionais from "../Opcionais/Opcionais";
import Trechos from "../Trechos/Trechos";
import ClasseDeVoo from "../ClasseDeVoo/ClasseDeVoo";
import { Container, Row, Col } from "reactstrap";
import Button from "../../components/Button/Button";
import ReservaServive from "../../services/ReservaService";
import './dashboradUsuario.css'
export default class DashboradUsuario extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      opcionalSelect: [],
      trechoID: {},
      classeID: {}
    };
    this.trechoSelecionado = this.trechoSelecionado.bind(this);
    this.classeSelecionada = this.classeSelecionada.bind(this);
    this.opcionalSelecionado = this.opcionalSelecionado.bind(this);
    this.onReservaButtonClick = this.onReservaButtonClick.bind(this);
    this.handleChange = this.handleChange.bind(this);
  }

  handleChange(event) {
    const target = event.target;
    const value = target.value;
    const name = target.name;
    this.setState({
      [name]: value
    });
  }

  onReservaButtonClick() {
    ReservaServive.registerReserva(
      this.state.trechoID,
      this.state.opcionalSelect,
      this.classeID,
      1
    )
      .then(result => {
        console.log("foiiiiiiiiiiiiii");
      })
      .catch(resp => {
        this.setState({
          error: resp.response.data.error
        });
      });
  }

  trechoSelecionado(trechoID) {
    this.setState({
      trechoID
    });
  }

  opcionalSelecionado(opcionaID) {
    this.setState({
      opcionalSelect: opcionaID
    });
  }

  classeSelecionada(classeID) {
    this.setState({
      classeID
    });
  }

  render() {
    return (
      <div>
       
        <NavBar />
        
        <div className="dashBoard">
        <Container>
          <Row>
            <Col sm={{ size: 6, order: 2, offset: 3 }}>
            
              <Trechos
                onClick={trecho => this.trechoSelecionado(trecho.id)}
                handleChange={this.handleChange}
              />
              <ClasseDeVoo
                onClick={classeDeVoo => this.classeSelecionada(classeDeVoo.id)}
                handleChange={this.handleChange}
              />
                <Opcionais
                onClick={opcional => this.opcionalSelecionado(opcional.id)}
                handleChange={this.handleChange}
              />
              <Button
                classButton="primary"
                type="button"
                onClick={this.onReservaButtonClick}
                text="Reservar"
              />
            </Col>
          </Row>
        </Container>
        </div>
      </div>
    );
  }
}
