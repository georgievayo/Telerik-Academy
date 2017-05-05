const LOCAL_STORAGE_USERNAME_KEY = 'signed-in-user-username',
    LOCAL_STORAGE_AUTHKEY_KEY = 'signed-in-user-auth-key';

let dataService = {
    register: function (user) {
        let newUser = {
            username: user.username,
            passHash: CryptoJS.SHA1(user.username + user.password).toString()
        };
        return requester.postJSON('/api/users', { data: newUser })
        .then((user) => {
            console.log(user);
            localStorage.setItem(LOCAL_STORAGE_USERNAME_KEY, user.result.username);
            localStorage.setItem(LOCAL_STORAGE_AUTHKEY_KEY, user.result.authKey);
        });
    },
    signIn: function (user) {
        let userToLog = {
            username: user.username,
            passHash: CryptoJS.SHA1(user.username + user.password).toString()
        };

        requester.putJSON('/api/users/auth', { data: userToLog })
            .then((data) => {
                console.log(data);
                let foundUser = data.result;
                localStorage.setItem(LOCAL_STORAGE_USERNAME_KEY, foundUser.username);
                localStorage.setItem(LOCAL_STORAGE_AUTHKEY_KEY, foundUser.authKey);
            });
    },
    signOut: function () {
        return Promise.resolve()
            .then(() => {
                localStorage.removeItem(LOCAL_STORAGE_USERNAME_KEY);
                localStorage.removeItem(LOCAL_STORAGE_AUTHKEY_KEY);
            });
    },
    hasUser: function () {
        return !!localStorage.getItem(LOCAL_STORAGE_USERNAME_KEY) &&
            !!localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY);
    },
    getCurrentUser: function () {
        return {
            headers: {
                'x-auth-key': localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
            }
        };
    },
    createTodo: function (todo) {
        let options = this.getCurrentUser();
        return requester.postJSON('/api/todos', todo, options);
    },
    createEvent: function (event) {
        let options = getCurrentUser();
        return requester.postJSON('/api/events', event, options);
    },
    allTodos: function(){
        var options = {
            headers: {
                'x-auth-key': localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
                }
        };
        return requester.getJSON('/api/todos', options)
        .then((data) => console.log(data));
    }

};