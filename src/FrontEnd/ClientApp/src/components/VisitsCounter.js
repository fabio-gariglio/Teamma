import React, { Component } from 'react';

export default class VisitsCounter extends Component {
    
    constructor(props) {
        super(props);
        this.state = { visits: 0 };
        
        fetch('')
            .then(response => response.json())
            .then(data => this.setState({ visits: data.counter }));
    }
    
    render() {
        return this.state.visits > 0
            ? (<p>We've got {this.state.visits} visitors!</p>)
            : (<p />);
    }

}