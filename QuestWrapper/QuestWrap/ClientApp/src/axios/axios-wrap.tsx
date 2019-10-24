import axios from 'axios';

const helpers = {
    async login(authInfo: any) {
        let headers = {
            'Content-Type': 'application/json'
        }

        let result = await axios.post(`https://localhost:44304/authorization/authorize/`,
                {
                    GameUrl: authInfo.url,
                    Login: authInfo.login,
                    Password: authInfo.password
            }, { headers: headers });

        return result;
    },

    async getLevelInfo() {
        let headers = {
            'Content-Type': 'application/json'
        }

        let result = await axios.get(`https://localhost:44304/game/currentlevel/`, { headers: headers });

        return result;
    }
}

export default helpers;