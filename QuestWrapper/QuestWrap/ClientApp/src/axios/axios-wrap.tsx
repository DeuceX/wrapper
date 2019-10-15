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

    async getLevel(authInfo: any) {
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
    }
}

export default helpers;