var handlebars = handlebars || Handlebars;

let todosController = {
    listTodos: function () {
        let todos = [];
        requester.getJSON('/api/todos')
            .then((data) => {
                todos = data.result;
                return templater.get('todos');
            })
            .then((template) => {
                let templateFunc = handlebars.compile(template);
                let html = templateFunc(todos);
                $('#main').html(html);
            })
    },
    create: function () {
        templater.get('createTodo')
            .then((template) => {
                let templateFunc = handlebars.compile(template);
                let html = templateFunc();
                $('#main').html(html);

                $('#btn-add').on('click', (ev) => {
                    let text = $('#tb-text').html();
                    let state = $('#tb-state').html();
                    let category = $('#tb-category').html();
                    let todo = {
                        text: text,
                        state: state,
                        category: category
                    };

                    dataService.createTodo(todo);
                });
            });
    },
    update: function(id){
        
    }
}