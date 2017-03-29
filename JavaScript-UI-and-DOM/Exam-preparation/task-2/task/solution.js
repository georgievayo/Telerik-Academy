function solve() {
    return function (filesMap) {
        var $files = $(".item-name");
        var $fileText = $(".file-content");

        $files.on("click", function (ev) {
            var file = ev.target;
            $fileText.html(filesMap[file.innerHTML]);
        });

        var $dirs = $(".dir-item");
        $dirs.on("click", function (ev) {
            var dir = ev.target;
            var classes = dir.parentNode.classList;
            var isCollapsed = false;
            for (var i = 0; i < classes.length; i += 1) {
                if (classes[i] === "collapsed") {
                    isCollapsed = true;
                    $(dir.parentNode).removeClass("collapsed");
                    break;
                }
            }

            if (!isCollapsed) {
                $(dir.parentNode).addClass("collapsed");
            }
        });

        var $add = $('.add-btn');
        $add.on("click", function () {
            $(this).removeClass("visible");
            $('input').addClass('visible');

        });

        var $inputField = $('input');
        $inputField.on('keydown', function (ev) {
            if (ev.which === 13) {
                var path = this.value;
                
                var separatedPath = path.split('/');
                var $newItem = $('<li />').addClass('file-item');
                if (!separatedPath[0] && !separatedPath[1]) {
                    return;
                }

                if (separatedPath.length === 1) {
                    filesMap[separatedPath[0]] = '';
                    var $newLink = $('<a />')
                        .addClass("item-name")
                        .html(separatedPath[0])
                        .appendTo($newItem);
                    var $newTrash = $('<a />')
                        .addClass('del-btn')
                        .appendTo($newItem);

                    $newItem.appendTo($('ul'));

                } else {
                    for (var i = 0; i < $dirs.length; i += 1) {
                        if ($dirs[i].childNodes[0].innerHTML === separatedPath[0]) {
                            var $newLink = $('<a />')
                                .addClass("item-name")
                                .html(separatedPath[1])
                                .appendTo($newItem);
                            var $newTrash = $('<a />')
                                .addClass('del-btn')
                                .appendTo($newItem);
                            filesMap[separatedPath[1]] = '';
                            $newItem.appendTo($($dirs[i].childNodes[2]));
                            break;
                        }
                    }
                }
               
                $(this).val = '';
                $(this).removeClass('visible');
                $('.add-btn').addClass('visible');
            }
        });
        var $trashes = $(".del-btn");
        $trashes.on("click", function (ev) {
            var trash = ev.target;
            (trash.parentNode.parentNode).removeChild(trash.parentNode);
        });
    }
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}