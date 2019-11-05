import React, {Component} from "react";
import VisitsCounter from './components/VisitsCounter';
import SpikesReport from './components/SpikesReport';

export default class App extends Component {
    
    render() {
        return (
            <div>
                <h1>Welcome!</h1>
                <SpikesReport/>
                <VisitsCounter/>
            </div>
        );
    }

}