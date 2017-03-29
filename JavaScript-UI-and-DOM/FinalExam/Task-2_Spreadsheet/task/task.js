function solve() {

	return function (selector, rows, columns) {
		var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		var element = $(selector);
		var table = $('<table />')
			.addClass('spreadsheet-table')
			.appendTo(element);
		var ROWS = rows + 1;
		var COLS = columns + 1;
		var headerRow = $('<tr />').appendTo(table);
		for (var i = 0; i < COLS; i++) {
			if (i === 0) {
				$('<th />').addClass('spreadsheet-item')
					.addClass('spreadsheet-header')
					.addClass('firstRow')
					.addClass('firstColumn')
					.attr('index', 0)
					.appendTo(headerRow);
			} else {
				$('<th />').addClass('spreadsheet-item')
					.addClass('spreadsheet-header')
					.addClass('firstRow')
					.text(alphabet[i - 1])
					.attr('index', i)
					.appendTo(headerRow);
			}

		}
		var currentNumber = 1;
		for (var i = 0; i < ROWS - 1; i += 1) {
			var $row = $('<tr />');
			table.append($row);
			for (var j = 0; j < COLS; j++) {
				if (j === 0) {
					$row.append($('<th />').addClass('spreadsheet-item')
						.addClass('spreadsheet-header').text(currentNumber).attr('index', j).addClass('firstColumn'));
					currentNumber++;
				} else {
					var cell = $('<td />')
						.addClass('spreadsheet-item')
						.addClass('spreadsheet-cell')
						.attr('index', j);
					var span = $('<span />').appendTo(cell);
					var input = $('<input />').appendTo(cell);
					$row.append(cell);
				}
			}
		}

		// SELECT CELL
		$('.spreadsheet-item').on('mousedown', function (event) {
			var cell = event.target;
			if ($(cell).hasClass('spreadsheet-cell')) {
				var index = $(cell).attr('index');
				$(cell).addClass('selected');
				$(cell.parentNode.children[0]).addClass('selected');
				$(table.children()[0].children[index]).addClass('selected');
			}
			else {
				
				if ($(cell).hasClass('firstColumn') && $(cell).hasClass('firstRow')) {					
					$('.firstColumn').addClass('selected');
					$('.firstRow').addClass('selected');
					$('.spreadsheet-cell').addClass('selected');
				}
				else if ($(cell).hasClass('firstColumn')) {
					$('.firstColumn').addClass('selected');
				}
				else if ($(cell).hasClass('firstRow')){
					$('.firstRow').addClass('selected');
				}
			}
		});

		$('.spreadsheet-cell').dblclick(function(event){
			var cell = event.target;
			$(cell).addClass('editing');
			cell.children[0].innerText = cell.children[1].value;
			
			$(cell).blur(function(){
				$(cell).removeClass('editing');
				cell.children[1].value = cell.children[0].innerText;
			});

		});


	};
}

// SUBMIT THE CODE ABOVE THIS LINE

if (typeof module !== 'undefined') {
	module.exports = solve;
}
