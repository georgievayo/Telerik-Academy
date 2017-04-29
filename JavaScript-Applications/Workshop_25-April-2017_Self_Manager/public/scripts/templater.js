let templater = {
    get: function (templateName) {
        let url = `./templates/${templateName}.handlebars`;
        return requester.get(url);
    }
};