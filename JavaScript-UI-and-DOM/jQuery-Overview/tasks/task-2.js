/* globals $ */

/*
Create a function that takes a selector and:
* Finds all elements with class `button` or `content` within the provided element
  * Change the content of all `.button` elements with "hide"
* When a `.button` is clicked:
  * Find the topmost `.content` element, that is before another `.button` and:
    * If the `.content` is visible:
      * Hide the `.content`
      * Change the content of the `.button` to "show"       
    * If the `.content` is hidden:
      * Show the `.content`
      * Change the content of the `.button` to "hide"
    * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
* Throws if:
  * The provided ID is not a **jQuery object** or a `string` 

*/
function solve() {
  return function (selector) {
    if(typeof selector !== 'string' && !(selector instanceof jQuery)){
      throw Error();
    }

    var element = $(selector);
    if(element.length <= 0){
      throw Error();
    }

    var buttons = $('.button').html('hide').on('click', onClickButton);
    

    function onClickButton(event){
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