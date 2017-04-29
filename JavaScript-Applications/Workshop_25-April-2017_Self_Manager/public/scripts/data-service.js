const LOCAL_STORAGE_USERNAME_KEY = 'signed-in-user-username',
    LOCAL_STORAGE_AUTHKEY_KEY = 'signed-in-user-auth-key';

let dataService = {
    register: function (user) {
        let newUser = {
            username: user.username,
            passHash: CryptoJS.SHA1(user.username + user.password).toString()
        };
        return requester.postJSON('/api/users', { data: newUser })
            .then((data) => {
                let user = data.result;
                localStorage.setItem(LOCAL_STORAGE_USERNAME_KEY, user.username);
                localStorage.setItem(LOCAL_STORAGE_AUTHKEY_KEY, user.authKey);
                return {
                    username: resp.result.username
                };
            });
    },
    signIn: function (user) {
        let userToLog = {
            username: user.username,
            passHash: CryptoJS.SHA1(user.username + user.password).toString()
        };

        return requester.getJSON('/api/users', { data: userToLog })
            .then((data) => {
                let foundUser = dat.result;
                localStorage.setItem(LOCAL_STORAGE_USERNAME_KEY, user.username);
                localStorage.setItem(LOCAL_STORAGE_AUTHKEY_KEY, user.authKey);
                return foundUser;
            })
    },
    createTodo: function (todo) {
        return requester.postJSON('/api/todos/create', todo);
    },
    createEvent: function(event){
        return requester.postJSON('/api/events/create', event);
    }

};

module.exports = dataService;