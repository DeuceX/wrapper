import axios from 'axios';

const helpers = {
    login(authInfo: any) {
        let headers = {
            'Content-Type': 'application/json'
        }

        axios.post(`https://localhost:44304/authorization/authorize/`,
                {
                    GameUrl: authInfo.url,
                    Login: authInfo.login,
                    Password: authInfo.password
                }, { headers: headers })
            .then(res => { console.log(res); });
    }
}

export default helpers;