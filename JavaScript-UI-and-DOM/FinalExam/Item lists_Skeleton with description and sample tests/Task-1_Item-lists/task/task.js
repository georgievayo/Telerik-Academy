function solve() {

	return function (selector, defaultLeft, defaultRight) {
		var selectedElement = document.querySelectorAll(selector);

		var columnContainer = document.createElement('div');
		columnContainer.className += 'column-container';
		selectedElement[0].appendChild(columnContainer);

		var columnOne = document.createElement('div');
		columnOne.className += 'column';
		columnContainer.appendChild(columnOne);
		var columnTwo = document.createElement('div');
		columnTwo.className += 'column';
		columnContainer.appendChild(columnTwo);

		var inputField = document.createElement('input');
		inputField.setAttribute("size", "40");
		inputField.setAttribute("autofocus",'');
		selectedElement[0].appendChild(inputField);

		var btnAdd = document.createElement('button');
		btnAdd.innerHTML = 'Add';
		selectedElement[0].appendChild(btnAdd);

		var selectObj1 = document.createElement('div');
		selectObj1.className += 'select';
		var radioBtn1 = document.createElement('input');
		radioBtn1.type = 'radio';
		radioBtn1.name = 'column-select';
		radioBtn1.id = 'select-left-column';
		radioBtn1.setAttribute('checked', 'checked');
		var label1 = document.createElement('label');
		label1.setAttribute('for', 'select-left-column');
		label1.innerHTML = 'Add here';
		selectObj1.appendChild(radioBtn1);
		selectObj1.appendChild(label1);
		columnOne.appendChild(selectObj1);

		var selectObj2 = document.createElement('div');
		selectObj2.className += 'select';
		var radioBtn2 = document.createElement('input');
		radioBtn2.type = 'radio';
		radioBtn2.name = 'column-select';
		radioBtn2.id = 'select-right-column';
		var label2 = document.createElement('label');
		label2.setAttribute('for', 'select-right-column');
		label2.innerHTML = 'Add here';
		selectObj2.appendChild(radioBtn2);
		selectObj2.appendChild(label2);
		columnTwo.appendChild(selectObj2);

		var ol1 = document.createElement('ol');
		columnOne.appendChild(ol1);
		if (defaultLeft) {
			for (var str of defaultLeft) {
				ol1.appendChild(createItem(str));
			}
		}

		var ol2 = document.createElement('ol');
		columnTwo.appendChild(ol2);
		if (defaultRight) {
			for (var str of defaultRight) {
				ol2.appendChild(createItem(str));
			}
		}


		radioBtn1.addEventListener('click', function () {
			radioBtn2.setAttribute('checked', '');
			this.setAttribute('checked', 'checked');
		}, false);
		radioBtn2.addEventListener('click', function () {
			radioBtn1.setAttribute('checked', '');

			this.setAttribute('checked', 'checked');
		}, false);

		btnAdd.addEventListener('click', function () {
			var newInput = inputField.value;
			if (newInput.length > 0) {
				if (radioBtn1.checked) {
					var item = createItem(newInput.trim());
					item.className += newInput;
					ol1.appendChild(item);
				}
				else {
					var item = createItem(newInput.trim());
					item.className += newInput;
					ol2.appendChild(createItem(newInput.trim()));
				}
			}
			inputField.value = '';
		}, false);

		document.addEventListener('click', function (ev) {
			if (ev.target.className === 'delete') {
				var text = ev.target.parentNode.className;
				ev.target.parentNode.remove();
				inputField.value = text;
			}

		}, false);

		function createItem(str) {
			var item = document.createElement('li');
			item.className += 'entry';
			item.innerHTML = str;
			var image = document.createElement('img');
			image.className += 'delete';
			image.src = './imgs/Remove-icon.png';
			item.appendChild(image);
			return item;
		}
	};
}

// SUBMIT THE CODE ABOVE THIS LINE

if (typeof module !== 'undefined') {
	module.exports = solve;
}
