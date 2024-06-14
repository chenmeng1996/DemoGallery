import React from "react";

class NameForm extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            value1: '',
            value2: 'coconut'
        };

        this.handleChange1 = this.handleChange1.bind(this);
        this.handleChange2 = this.handleChange2.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange1(event) {
        this.setState({value1: event.target.value});
    }

    handleChange2(event) {
        this.setState({value2: event.target.value});
    }


    handleSubmit(event) {
        alert('submited name: ' + this.state.value1 + '\nsubmited taste: ' + this.state.value2);
        event.preventDefault();
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <label>
                    name: 
                    <input type="text" value={this.state.value1} onChange={this.handleChange1}/>
                </label>
                <div/>
                <label>
                    select your favorite taste:
                    <select value={this.state.value2} onChange={this.handleChange2}>
                        <option value="grapefruit">grapefruit</option>
                        <option value="lime">lime</option>
                        <option value="coconut">coconut</option>
                    </select>
                    <div/>
                    <select multiple={true} value={['A', 'B']}>
                        <option value="A">A</option>
                        <option value="B">B</option>
                        <option value="C">C</option>
                    </select>
                    <div/>
                        <input type="file"/>
                    <div/>
                </label>
                <input type="submit" value="submit"/>
            </form>
        )
    }
}

export {NameForm};