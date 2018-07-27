import React from "react";
import ReservaService from "../../services/ReservaService";
import { Input,Table } from "reactstrap";
export default class Opcionais extends React.Component {
  constructor() {
    super();
    this.state = {
      opcionais: []
    };

    
  }

  componentDidMount() {
    this.loadOpcionais();
  }

 

  loadOpcionais() {
    ReservaService.getOpcionais()
      .then(opcionaisList => {
        this.setState({
          opcionais: opcionaisList.data
        });
      })
      .catch(err => {
        console.error(err);
      });
  }

  renderOpcionais() {
    return this.state.opcionais.map((opcional, key) => {
      return (
        <tr key={opcional.id}>
          <td>{opcional.id}</td>
          <td>{opcional.nome}</td>
          <td>{opcional.descricao}</td>
          <td>{opcional.porcentagem}</td>
          <td>
            <Input
              name="checkbox"
              type="checkbox"
              onClick={() =>
                this.props.opcionalSelecionado(opcional.id)
              }
              onChange={this.props.handleChange}
            />
          </td>
        </tr>
      );
    });
  }
  renderTable() {
    return (
      <Table dark>
        <thead>
          <tr>
            <th>ID</th>
            <th>Nome</th>
            <th>Descrição</th>
            <th>Porcentagem</th>
          </tr>
        </thead>
        <tbody>{this.renderOpcionais()}</tbody>
      </Table>
    );
  }

  render() {
    return (
      <div>
        <h1>Opcionais</h1>
        {this.renderTable()}
      </div>
    );
  }
}
