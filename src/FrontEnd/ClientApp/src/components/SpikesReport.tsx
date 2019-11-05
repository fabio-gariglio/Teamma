import React, {Component} from "react";

export interface Spike { title: string }
export interface SpikesReportProps { }
export interface SpikesReportState { resolved: boolean, spikes: Spike[] }

export default class SpikesReport extends Component<SpikesReportProps, SpikesReportState> {
    
    constructor(props: SpikesReportProps) {
        super(props);
        this.state = { resolved: false, spikes: [] };
        
        fetch('/reports/spikes')
            .then(response => {
                if (!response.ok) throw Error(response.statusText);
                return response;
            })
            .then(response => response.json())
            .then(data => this.setState({ resolved: true, spikes: data}))
            .catch(error => console.warn('Unable to retrieve the visits counter.', error));
    }
    
    render() {
        const result = !!this.state.resolved
            ? this.state.spikes.map(s => <p>{s.title}</p>)
            : (<p>Loading...</p>);

        return (<div>{result}</div>);
    }
}