import React from "react";
import ReservaService from "../../services/ReservaService";
import { Input,Table } from "reactstrap";
export default class Trechos extends React.Component {
  constructor() {
    super();
    this.state = {
      trechos: []
    };   
  }

  componentDidMount() {
    this.loadTrechos();
  }

  loadTrechos() {
    ReservaService.getTrechos()
      .then(trechosList => {
        this.setState({
          trechos: trechosList.data
        });
      })
      .catch(err => {
        console.error(err);
      });
  }

  renderTrechos() {
    return this.state.trechos.map((trecho, key) => {
      return <tr key={trecho.id}>
          <td>{trecho.id}</td>
          <td>{trecho.origem.nome}</td>
          <td>{trecho.destino.nome}</td>
          <td>{trecho.distanciaTotal}</td>
          <td>
          <Input
          name="trecho"
          type="radio"
          onClick={(trecho) => this.props.trechoSelecionado(trecho.id)}
          onChange={this.props.handleChange}
        />
          </td>
        </tr>
      
    });
  }
  renderTable() {
    return (
      <Table dark>
        <thead>
          <tr>
            <th>ID</th>
            <th>Origem</th>
            <th>Destino</th>
            <th>Distancia</th>
          </tr>
        </thead>
        <tbody>{this.renderTrechos()}</tbody>
      </Table>
    );
  }

  render() {
    return (
      <div>
        <h1>Trechos</h1>
        {this.renderTable()}
      </div>
    );
  }
}
