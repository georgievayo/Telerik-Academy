let userControllers = {
    listUsers: function () {
        let users = [];
        requester.getJSON('/api/users')
            .then((data) => {
                users = data.result;
                return templater.get('users');
            })
            .then((template) => {
                console.log(template);
                let templateFunc = handlebars.compile(template);
                let html = templateFunc(users);
                $("#content").html(html);
            });
    },
    register: function () {
        templater.get('register')
            .then((template) => {
                let templateFunc = handlebars.compile(template);
                let html = templateFunc();
                $('#content').html(html);
                $('#btn-register').on('click', (ev) => {
                    let reqUser = {
                        username: $('#tb-reg-username').val(),
                        password: $('#tb-reg-pass').val()
                    };
                    dataService.register(reqUser);
                });
            });
    },
    signIn: function(reqUser){
    
            dataService.signIn(reqUser);
    },
    signOut: function() {
    }
};