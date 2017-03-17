/* globals $ */

/* 

Create a function that takes an id or DOM element and:
  

*/

function solve() {
  return function (selector) {
    var element;
    if (typeof selector === 'string') {
      element = document.getElementById(selector);
    }
    else if (document.contains(selector)) {
      element = selector;
    }
    else {
      throw Error();
    }

    if (element === undefined) {
      throw Error();
    }

    var buttons = element.getElementsByClassName("button");
    for (var i = 0; i < buttons.length; i += 1) {
      buttons[i].innerHTML = 'hide';
      buttons[i].addEventListener('click', changeVisibility);
    }

    function changeVisibility(event) {
      targetButton = event.target;
      nextSibling = targetButton.nextElementSibling;
      if (targetButton.className !== 'button') {
        return;
      }

      if (nextSibling.className === 'content') {
        if (targetButton.className === 'button') {
          if (targetButton.innerHTML === 'hide') {
            nextSibling.style.display = 'none';
            targetButton.innerHTML = 'show';

          }
          else {
            nextSibling.style.display = '';
            targetButton.innerHTML = 'hide';
          }

        }
      }
    }
  };
};

module.exports = solve;