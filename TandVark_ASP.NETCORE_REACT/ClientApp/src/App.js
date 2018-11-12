import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Start } from './components/Shared.components/Start';
import { PatientView } from './components/Dentist.components/PatientView';
import { Booking } from './components/Shared.components/Booking';



export default class App extends Component {
    constructor(props) {
        super(props)
        this.state = {
            currUser: { userName: " ", userType: " " },
            active: false
        }
        this.HandleSetCurrUserandActiveState = this.HandleSetCurrUserandActiveState.bind(this);
    }
    displayName = App.name

    HandleSetCurrUserandActiveState(User) {

        this.setState({
            currUser: User,
            active: true
        }
        );

        console.log(this.state.currUser);
    }

    

    render() {
        let contents =
            this.state.active
                ?
                this.state.currUser.userType === "Dentist"
                    ?
                    <Route path='/patient' component={PatientView} />
                    :
                    <Route path='/booking' component={Booking} />
                : <h1>Please log in</h1>

        let nav =
            this.state.active
                ?
                this.state.currUser.userType === "Dentist"
                    ?
                    { link: '/patient', title: 'Patient Details' }
                    :
                    { link: '/booking', title: 'Book Appointment' }

                : {link: '', title: ''};
                


    return (
        <Layout linksAndTitle={nav}>
            {contents}
            <Start logInHandler={this.HandleSetCurrUserandActiveState} currentUser={this.state.currUser} active={this.state.active} />
      </Layout>
    );
  }
}
