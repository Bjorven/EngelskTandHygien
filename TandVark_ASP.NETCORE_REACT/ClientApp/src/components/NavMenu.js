import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export class NavMenu extends Component {
    
    displayName = NavMenu.name

    NavBarLink(props) {
        return (
        // Write a loop to cycle through all the nav links and titles.
        <LinkContainer to={props.link} exact>
            <NavItem>
                {props.title}
            </NavItem>    
    </LinkContainer>
    );
}
    render() {
        
        
    return (
      <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <Link to={'/'}>TandVark_ASP.NETCORE_REACT</Link>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
            <Navbar.Collapse>
              
          <Nav>
            <LinkContainer to={'/'} exact>
              <NavItem>
                <Glyphicon glyph='home' /> Home
              </NavItem>
            </LinkContainer>
                    {this.NavBarLink(this.props.navLinksAndTitle)} 
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}
