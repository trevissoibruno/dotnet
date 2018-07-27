import React from 'react'
import { Jumbotron } from 'reactstrap';
import NavBar from '../../components/generic/NavBar/NavBar'
export default class NotFound extends React.Component {

    render() {
        return <div>
            <NavBar/>
            <Jumbotron>
                <h1 className="display-3">Not Found</h1>
            </Jumbotron>
        </div>
    }

}