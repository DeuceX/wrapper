import * as React from 'react';
import { connect } from 'react-redux';
import helpers from './../axios/axios-wrap';
import './home.css';

class Home extends React.Component {
    constructor(props: any) {
        super(props);
        this.state = {
            url: "",
            login: "",
            password: ""
        }
    }

    getUserInfo = () => {
        helpers.login(this.state);
    }

    getUserInfoByEnter = (e: any) => {
        if (e.key === 'Enter') {
            this.getUserInfo();
        }
    }

    render() {

        return <div>
            <div className="game-info">
                <p>Game URL:</p>
                <input className="game-url" type="text" onChange={e => this.setState({ url: e.target.value })}
                    placeholder="Example: http://quest.ua/GameDetails.aspx?gid=65890" />
            </div>
            <div className="user-info">
                <span className="user-label">Login:</span>
                <input className="user-login" type="text" onChange={e => this.setState({ login: e.target.value })} /><br />
                <span className="user-label">Password:</span>
                <input className="user-password" type="password" onChange={e => this.setState({ password: e.target.value })}
                    onKeyDown={this.getUserInfoByEnter} /><br />
                <button onClick={this.getUserInfo}>Login</button>
            </div>
        </div>;
    }
}

export default connect()(Home);
