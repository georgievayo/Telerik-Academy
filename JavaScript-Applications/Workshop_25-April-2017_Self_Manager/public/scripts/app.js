let router = new Navigo(null, true);

router.on('/home', () => { })
    .on('/todos', todosController.listTodos)
    .on('/events', eventsController.listEvents)
    .on('/events/create', eventsController.create)
    .on('/todos/create', todosController.create)
    .on('/todos/:id/update', todosController.update) //TODO
    .resolve();