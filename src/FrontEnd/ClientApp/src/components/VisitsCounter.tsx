import React, {Component} from "react";

export interface VisitsCounterProps { }
export interface VisitsCounterState { visits: number; }

export default class VisitsCounter extends Component<VisitsCounterProps, VisitsCounterState> {
    
    constructor(props: VisitsCounterProps) {
        super(props);
        this.state = { visits: 0 };
        
        fetch('')
            .then(response => {
                if (!response.ok) throw Error(response.statusText);
                return response;
            })
            .then(response => response.json())
            .then(data => this.setState({ visits: data.counter }))
            .catch(error => console.warn('Unable to retrieve the visits counter.', error));
    }
    
    render() {
        return this.state.visits > 0
            ? (<p>We've got {this.state.visits} visitors!</p>)
            : (<p />);
    }

}