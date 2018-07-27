import React from 'react'
import ReservaService from '../../services/ReservaService'
import { Input, Table  } from "reactstrap";
export default class ClasseDeVoo extends React.Component {
    constructor() {
		super()
		this.state = {
			classesDeVoo: []
		}
	
		
	}
	componentDidMount() {
		this.loadClasseDeVoo()
	}

	

	loadClasseDeVoo() {
		ReservaService.getClassesDeVoo().then((classesDeVooList) => {
			this.setState({
				classesDeVoo: classesDeVooList.data
			})
		}).catch((err) => {
			console.error(err)
		})
		}
	
	 renderClasseDeVoo() {
    return this.state.classesDeVoo.map((classeDeVoo,key) => {
      return  <tr key={classeDeVoo.id} >
          <td>{classeDeVoo.id}</td>
          <td>{classeDeVoo.descricao}</td>
          <td>{classeDeVoo.valorFixo}</td>
          <td>{classeDeVoo.valorPorMilha}</td>
          <td>
            <Input
          name="classe"
          type="radio"
          onClick={() => this.props.classeSelecionada(this.state.classeDeVoo.id)}
          onChange={this.props.handleChange}
        />
          </td>
        </tr >
                
      
    });
  }
  renderTable() {
    return (
      <Table  dark>
        <thead>
          <tr>
            <th>ID</th>
            <th>Descrição</th>
            <th>Valor Fixo</th>
						<th>Valor por Milha </th>
          </tr>
        </thead>
        <tbody>{this.renderClasseDeVoo()}</tbody>
      </Table>
    );
  }

  render() {
    return (
      <div>
        <h1>Classe de Voo</h1>
        {this.renderTable()}
      </div>
    );
  }
    }