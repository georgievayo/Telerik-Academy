/* globals document, window, console */

function solve() {
    return function (selector, initialSuggestions) {
        var element = document.querySelectorAll(selector)[0];
        initialSuggestions = initialSuggestions || [];

        var suggestions = [];
        var selectionList = document.getElementsByClassName("suggestions-list")[0];
        var fragment = document.createDocumentFragment();

        for (var suggestion of initialSuggestions) {
            var toLower = suggestion.toLowerCase();
            if (suggestions.indexOf(toLower) === -1) {
                suggestions.push(toLower);
                var li = document.createElement('li');
                li.className = "suggestion";
                var anchor = document.createElement('a');
                anchor.href = '#';
                anchor.className = "suggestion-link";
                anchor.innerHTML = suggestion;
                li.appendChild(anchor);
                li.style.display = "none";
                fragment.appendChild(li);
            }
        }

        selectionList.appendChild(fragment);

        var inputField = document.getElementsByClassName("tb-pattern")[0];
        inputField.addEventListener("input", function () {
            var pattern = this.value.toLowerCase();
            var children = selectionList.children;

            if (pattern != '') {
                for (var i = 0; i < children.length; i += 1) {
                    var a = children[i].childNodes[0];
                    var text = a.innerHTML.toLowerCase();
                    if (text.indexOf(pattern) > -1) {
                        children[i].style.display = "";
                    }
                }
            } else {
                for (var i = 0; i < children.length; i += 1) {
                        children[i].style.display = "none";
                    }
                }
            }, false);
        
        var addButton = document.getElementsByClassName("btn-add")[0];
        addButton.addEventListener("click", function(){
            var newSuggestion = inputField.value.toLowerCase();
            if(suggestions.indexOf(newSuggestion) === -1){
                suggestions.push(newSuggestion);

                var li = document.createElement('li');
                li.className = "suggestion";                
                var anchor = document.createElement('a');
                anchor.href = '#';
                anchor.className = "suggestion-link";
                anchor.innerHTML = newSuggestion;
                li.appendChild(anchor);
                li.style.display = "none";
                selectionList.appendChild(li);
            }
        }, false);

        selectionList.addEventListener("click", function(ev){
            var link = ev.target;
            inputField.value = link.innerHTML;
        }, false);
    };
}

module.exports = solve;