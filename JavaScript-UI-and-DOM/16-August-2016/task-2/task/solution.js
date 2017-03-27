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

        var $trashes = $(".del-btn");
        $trashes.on("click", function (ev) {
            var trash = ev.target;
            (trash.parentNode.parentNode).removeChild(trash.parentNode);
        });

        var $add = $('.add-btn');
        $add.on("click", function () {
            var classes = this.classList;
            var isVisible = false;
            for (var i = 0; i < classes.length; i += 1) {
                if (classes[i] === "visible") {
                    isVisible = true;
                    $(this).removeClass("visible");
                    $('input').addClass('visible');
                    break;
                }
            }

            if (!isVisible) {
                $(this).addClass("visible");
            }
        });

        var $inputField = $('input');
        $inputField.on('keypress', function (ev) {
            if (ev.which === 13) {
                var path = this.value;
                var separatedPath = path.split('/');
                var $newItem = $('<li></li>').addClass("file-item")
                    .addClass("item");

                if (separatedPath.length === 1) {
                    var $newLink = $('<a></a>')
                        .addClass("item-name")
                        .html(separatedPath[0])
                        .appendTo($newItem);
                    var $newTrash = $('<a></a>')
                        .addClass('del-btn')
                        .appendTo($newItem);
                    $newItem.appendTo($('.items'));
                } else {
                    for (var i = 0; i < $dirs.length; i += 1) {
                        if ($dirs[i].childNodes[0].innerHTML === separatedPath[0]) {
                            var $newLink = $('<a></a>')
                                .addClass("item-name")
                                .html(separatedPath[1])
                                .appendTo($newItem);
                            var $newTrash = $('<a></a>')
                                .addClass('del-btn')
                                .appendTo($newItem);
                            $newItem.appendTo($($dirs[i].childNodes[2]));
                            break;
                        }
                    }
                }
            }
        });
    }
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}