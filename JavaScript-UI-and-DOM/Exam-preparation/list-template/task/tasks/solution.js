function solve() {
    return function (selector) {
        var template = [
            '{{#each authors}}' +
            '<div class="box">' +
            '<div class="inner">' +
            '<p>' +
            '<img alt={{this.name}} src={{this.image}} width="100" height="133">' +
            '</p>' +
            '<div>' +
            '<h3>{{this.name}}</h3>' +
            '<p>' +
            '{{{titles.[0]}}}' +
            '</p>' +
            '<ul>' +
            '<li>' +
            '<a href=' +
            '{{urls.[0]}}'+
            ' target="_blank">'+
            '{{urls.[0]}}'+
            '</a>' +
            '</li>' +
            '{{#unless right}}' +
            '{{#if urls.[1]}}'+
            '<li>' +
            '<a href='+
            '{{urls.[1]}}' +
            ' target="_blank">'+
            '{{urls.[1]}}' +
            '</a>' +
            '</li>' +
            '{{/if}}'+
            '{{/unless}}' +
            '</ul>' +
            "</div>" +
            "</div>" +
            "</div>"
            +'{{/each}}'
        ].join('');
        return template;
       // document.getElementById(selector).innerHTML = template;
    }
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}