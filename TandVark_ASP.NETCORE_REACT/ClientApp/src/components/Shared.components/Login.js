import React, { Component } from 'react';
import '../Dentist.css';



export class Login extends Component {
    constructor(props) {
        super(props);
        
        this.handleLoginClick = this.handleLoginClick.bind(this);
    }
    handleLoginClick(credentials) {

        

        fetch("api/Authentication/AuthenticateUserAsync", {
            method: "Post",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },

            //make sure to serialize your JSON body
            body: JSON.stringify({
                UserName: credentials[0].userName,
                PassWord: credentials[0].passWord
            }),
        })
            .then(response => response.json())
            .then(data => {
                
                this.props.onLogIn(data);
            }
            );
    }
  

    render() {

        return ( 
            <div className="DMain">
                <LoginSub
                    onLoginClick={this.handleLoginClick}
                />
            </div>
            );
    }
}



export class LoginSub extends Component {
    constructor(props) {
        super(props);
        this.state = {
            userName: "",
            passWord: ""
        }
        this.handleLoginClick = this.handleLoginClick.bind(this);
        this.handleUserNameOnChange = this.handleUserNameOnChange.bind(this);
        this.handlePassWordOnChange = this.handlePassWordOnChange.bind(this);
        this.handleCancelClick = this.handleCancelClick.bind(this);

    }


    handleLoginClick() {
        var credentials = [{ userName: this.state.userName, passWord: this.state.passWord }];
        this.props.onLoginClick(credentials);
    }
    handleUserNameOnChange(e) {
        this.setState({ userName: e.target.value });
    }
    handlePassWordOnChange(e) {
        this.setState({ passWord: e.target.value });
    }
    handleCancelClick() {
        this.setState({
            userName: "",
            passWord: ""
        });
    }

    render() {

        return (
            <div className="LoginSub">

                <input type="text" value={this.state.userName} id="UserName" onChange={this.handleUserNameOnChange}/>
                <input type="text" value={this.state.passWord} id="PassWord" onChange={this.handlePassWordOnChange}/>

                <button onClick={this.handleLoginClick}>login</button>
                <button onClick={this.handleCancelClick}>cancel</button>
            </div>
        );
    }
}