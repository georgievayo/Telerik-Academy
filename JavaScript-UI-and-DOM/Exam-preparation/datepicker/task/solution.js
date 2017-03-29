function solve() {
    $.fn.datepicker = function () {
        $($('input').parent()).addClass('datepicker-wrapper');
        $('input').addClass('datepicker');
        var $pickerDiv = $('<div />')
            .addClass('picker')
            .appendTo($('.datepicker-wrapper'));
        var $controlsDiv = $('<div />')
            .addClass('controls')
            .appendTo($pickerDiv);

        var $btnPrev = $('<button />')
            .addClass('btn btn-previous')
            .attr('data-operation', '-1')
            .appendTo($controlsDiv);

        var $btnNext = $('<button />')
            .addClass('btn btn-next')
            .attr('data-operation', '1')
            .appendTo($controlsDiv);

        var $currentMonth = $('<div />')
            .addClass('current-month')
            .text('February 2016')
            .appendTo($controlsDiv);

        var $table = $('<table />')
            .addClass('calendar')
            .appendTo($pickerDiv);

        var $row = $('<tr />')
            .append($('<th />').text('Su'))
            .append($('<th />').text('Mo'))
            .append($('<th />').text('Tu'))
            .append($('<th />').text('We'))
            .append($('<th />').text('Th'))
            .append($('<th />').text('Fr'))
            .append($('<th />').text('Sa'))
            .appendTo($table);

        for (let i = 0; i < 6; i += 1) {
            $nextRow = $('<tr />')
                .appendTo($table);
            for (let j = 0; j < 7; j += 1) {
                $nextCol = $('<td />')
                    .appendTo($nextRow);
            }
        }

        var $currentDate = $('<div />')
            .addClass('current-date')
            .appendTo($pickerDiv);
        var $dateLink = $('<a />')
            .addClass('current-date-link')
            .attr('href', '#')
            .text('27 March 2017')
            .appendTo($currentDate);

        $('input').click(function () {
            $('.picker').addClass('picker-visible');      
        });

        $('input').focus(function () {
            $('.picker').addClass('picker-visible');      
        });
return this;
    };
    
};

if (typeof module !== 'undefined') {
    module.exports = solve;
}