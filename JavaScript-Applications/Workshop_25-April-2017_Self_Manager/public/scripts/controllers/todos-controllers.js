let todosController = {
    listTodos: function () {
        let todos = [];
        dataService.allTodos()
            // .then((data) => {
            //     todos = data.result;
            //     return templater.get('todos');
            // })
            // .then((template) => {
            //     let templateFunc = handlebars.compile(template);
            //     let html = templateFunc(todos);
            //     $('#content').html(html);
            // });
    },
    create: function () {
        templater.get('todo-add')
            .then((template) => {
                let templateFunc = handlebars.compile(template);
                let html = templateFunc();
                $('#content').html(html);

                $('#btn-todo-add').on('click', (ev) => {
                    let text = $('#tb-todo-text').val();
                    let state = $('#tb-todo-state').val();
                    let category = $('#tb-todo-category').val();
                    let todo = {
                        text: text,
                        state: state,
                        category: category
                    };

                    dataService.createTodo(todo);
                });
            });
    },
    update: function (id) {

    }
}
