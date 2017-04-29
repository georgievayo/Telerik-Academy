let handlebars = handlebars || Handlebars;
let dataService = require('../scripts/data-service.js');

let eventsController = {
    listEvents: function(){
        let events = [];
        requester.getJSON('/api/events')
        .then((data) => {
            events = data.result;
            return templater.get('events');
        })
        .then((template) => {
            let templateFunc = handlebars.compile(template);
            let html = templateFunc(events);
            $("#main").html(html);
        })
    },
    create:function(){
        templater.get('createEvent')
        .then((template) => {
            let templateFunc = handlebars.compile(template);
            let html = templateFunc();
            $('#main').html(html);

            $('#btn-add').on('click', (ev) => {
                let title = $('#tb-title').html();
                let description = $('#tb-description').html();
                let date = $('#tb-date').html();
                let category = $('#tb-category').html();
                let users = $('#tb-users')
                .html()
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