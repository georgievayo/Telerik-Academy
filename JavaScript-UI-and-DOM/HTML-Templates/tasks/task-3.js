function solve() {
  return function () {
    $.fn.listview = function (data) {
      var $ul = $(this);
      var template = $('#' + $ul.attr('data-template')).html();
      var listTemplate = handlebars.compile(template);
      for (var element in data) {
        $ul.append(listTemplate(element));
      }
    };
    return this;
  };
} 

module.exports = solve;