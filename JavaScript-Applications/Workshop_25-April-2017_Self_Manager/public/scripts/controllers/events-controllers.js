var handlebars = handlebars || Handlebars;

let eventsController = {
    listEvents: function () {
        let events = [];
        let options = getCurrentUser();
        requester.getJSON('/api/events', options)
            .then((data) => {
                events = data.result;
                return templater.get('events');
            })
            .then((template) => {
                let templateFunc = handlebars.compile(template);
                let html = templateFunc(events);
                $("#content").html(html);
            })
    },
    create: function () {
        templater.get('event-add')
            .then((template) => {
                let templateFunc = handlebars.compile(template);
                let html = templateFunc();
                $('#content').html(html);

                $('#btn-event-add').on('click', (ev) => {
                    let title = $('#tb-event-title').val();
                    let description = $('#tb-event-description').val();
                    let date = $('#tb-event-date').val();
                    let time = $('#tb-event-time').val();
                    let category = $('#tb-event-category').val();
                    let users = $('#tb-event-users')
                        .val()
                        .split(', ');

                    let event = {
                        title: title,
                        description: description,
                        date: date,
                        category: category,
                        users: users
                    };

                    dataService.createEvent(event);
                });
            });
    }
}