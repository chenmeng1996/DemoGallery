import React from 'react';

function LoginButton(props) {
    return (
        <button onClick={props.onClick}>
            Logout
        </button>
    )
}

function LogoutButton(props) {
    return (
        <button onClick={props.onClick}>
            Login
        </button>
    )
}

function UserGreeting(props) {
    return <h1>Welcome</h1>
}

function GuestGreeting(props) {
    return <h1>Please sign in</h1>
}

function Greeting(props) {
    if (props.isLoggedIn) {
        return <UserGreeting/>
    } else {
        return <GuestGreeting/>
    }
}

class LoginControl extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            isLoggedIn: false
        };
        this.handleLoginClick = this.handleLoginClick.bind(this);
        this.handleLogoutClick = this.handleLogoutClick.bind(this);
    }

    handleLoginClick() {
        this.setState({isLoggedIn: true});
    }

    handleLogoutClick() {
        this.setState({isLoggedIn: false});
    }

    render() {
        const isLoggedIn = this.state.isLoggedIn;
        let button;
        if (isLoggedIn) {
            button = <LoginButton onClick={this.handleLogoutClick}/>
        } else {
            button = <LogoutButton onClick={this.handleLoginClick}/>
        }

        return (
            <div>
                <Greeting isLoggedIn={this.state.isLoggedIn}/>
                {button}
            </div>
        )
    }
}

export { LoginControl };