import React from "react";
import {ThemeContext} from './theme-context';

class ContextDemo extends React.Component {
    render() {
        return (
            <ThemeContext.Provider value={this.props.theme}>
                <Toolbar />
            </ThemeContext.Provider>
        )
    }
}

function Toolbar() {
    return (
        <div>
            <ThemedButton />
        </div>
    );
}

class ThemedButton extends React.Component {
    static contextType = ThemeContext;

    render() {
        let props = this.props;
        let theme = this.context;
        return (
            <button
                {...props}
                style={{ backgroundColor: theme.background, color: theme.foreground }}>
                button
            </button>
        );
    }
}

export { ContextDemo }