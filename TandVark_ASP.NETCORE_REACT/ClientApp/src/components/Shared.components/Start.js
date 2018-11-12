import React, { Component } from 'react';
import { Login } from './Login';


export class Start extends Component {
    constructor(props) {
        super(props)
        this.state = {
          
        }
        this.HandleLogInSetCurrentUser = this.HandleLogInSetCurrentUser.bind(this);
       
    }
    HandleLogInSetCurrentUser(User) {
        this.props.logInHandler(User);   
    }

    render() {
        let contents = this.props.active
            ? this.props.currentUser.userType === "Dentist" ?
              <p><em>Dentis...</em></p> : <p><em>Receptionist...</em></p>
            : <Login onLogIn={this.HandleLogInSetCurrentUser} />;

        return (
            <div>
                {contents}
            </div>
            );
    }
}