let router = new Navigo(null, true);

router.on('/home', () => { })
    .on('/todos', todosController.listTodos)
    .on('/events', eventsController.listEvents)
    .on('/events/create', eventsController.create)
    .on('/todos/create', todosController.create)
    .on('/todos/:id', todosController.update)
    .on('/users', userControllers.listUsers)
    .on('/users/register', userControllers.register)
    .resolve();

$('#btn-sign-in').on('click', (ev) => {
    let reqUser = {
        username: $('#tb-username').val(),
        password: $('#tb-password').val()
    };
    console.log("event")
    $('#tb-username').val('');
    $('#tb-password').val('');
    dataService.signIn(reqUser);
    $("#container-sign-in").hide();
});

$('#btn-sign-out').on('click', (ev) => {
    dataService.signOut();
    $('#btn-sign-out').hide();
    $("#container-sign-in").show();
   
});