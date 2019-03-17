import React, { Component } from 'react';
import VisitsCounter from './components/VisitsCounter';

export default class App extends Component {
    
    render() {
        return (
            <div>
                <h1>Welcome!</h1>
                <VisitsCounter/>
            </div>
        );
    }

}