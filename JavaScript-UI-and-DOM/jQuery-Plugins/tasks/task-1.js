function solve(){
  return function(selector){
    var mainDiv = $("<div></div>").addClass("dropdown-list");
    
    var $selectElement = $(selector);
    $selectElement.hide();
    mainDiv.append($selectElement);

    var currentDiv = $("<div></div>")
            .addClass("current")
            .attr("data-value", "")
            .html("Select a value")
            .click(function() {
                innerDiv.show();
            });

    var innerDiv = $("<div></div>")
                  .addClass("options-container")
                  .css("position", "absolute")
                  .hide()
                  .on('click', '.dropdown-item', buttonClicked);

    $selectElement.find('option').each(function(i){
      $("<div></div>")
              .addClass("dropdown-item")
              .attr("data-value", "value-" + i)
              .attr("data-index", i)
              .html("Option " + (i + 1))
              .appendTo(innerDiv);
    });
  
  function buttonClicked() {
            currentDiv.text($(this).text());
            $selectElement.attr('value', currentDiv.attr('data-value'));
            innerDiv.hide();
        }

    currentDiv.append(innerDiv);
    mainDiv.append(currentDiv);
    mainDiv.appendTo(document.body);    
  };
}

module.exports = solve;