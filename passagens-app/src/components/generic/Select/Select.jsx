import React from 'react'
export default class Select extends React.Component {

    
    
    renderOptions() {
        return this.props.options.map((option, key) => {
            return <option key={key} value={option.descricao}>{option.descricao}</option>
        })
    }

    render() {
        return <div className="form-group">
            <label >{this.props.label}</label>
            <select name={this.props.name} 
            onChange={this.props.handdleChange}
             className="select-control" >
                {this.renderOptions()}
            </select>
        </div>
    }
}