"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var axios_1 = require("axios");
var helpers = {
    login: function (authInfo) {
        var headers = {
            'Content-Type': 'application/json'
        };
        axios_1.default.post("https://localhost:44304/authorization/authorize/", {
            GameUrl: authInfo.url,
            Login: authInfo.login,
            Password: authInfo.password
        }, { headers: headers })
            .then(function (res) { console.log(res); });
    }
};
exports.default = helpers;
//# sourceMappingURL=axios-wrap.js.map