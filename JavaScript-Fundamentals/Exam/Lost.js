function solve(args) {
    const size = args[0].split(' ').map(Number);
    const ROWS = size[0];
    const COLS = size[1];

    let field = new Array(ROWS);
    for (let i = 1; i < args.length; i++) {
        field[i - 1] = args[i].split(' ').map(Number);
    }
    position = { row: parseInt(ROWS / 2), col: parseInt(COLS / 2) };
    //Go through field
    while (true) {
         //console.log(field);

if (isOnUpBoundery(position.row)) {
                if (canGoUp(field[position.row][position.col])) {
                    console.log("No rakiya, only JavaScript " + position.row + " " + position.col);
                    break;
                }
                else if (!canGoRight(field[position.row][position.col]) && !canGoDown(field[position.row][position.col]) && !canGoLeft(field[position.row][position.col])) {
                    console.log("No JavaScript, only rakiya " + position.row + " " + position.col);
                    break;
                }
            }
            if (isOnDownBoundery(position.row)) {
                if (canGoDown(field[position.row][position.col])) {
                    console.log("No rakiya, only JavaScript " + position.row + " " + position.col);
                    break;
                }
                else if (!canGoRight(field[position.row][position.col]) && !canGoUp(field[position.row][position.col]) && !canGoLeft(field[position.row][position.col])) {
                    console.log("No JavaScript, only rakiya " + position.row + " " + position.col);
                    break;
                }
            }
            if (isOnLeftBoundery(position.col)) {
                if (canGoLeft(field[position.row][position.col])) {
                    console.log("No rakiya, only JavaScript " + position.row + " " + position.col);
                    break;
                }
                else if (!canGoRight(field[position.row][position.col]) && !canGoUp(field[position.row][position.col]) && !canGoDown(field[position.row][position.col])) {
                    console.log("No JavaScript, only rakiya " + position.row + " " + position.col);
                    break;
                }
            }
            if (isOnRightBoundery(position.col)) {
                if (canGoRight(field[position.row][position.col])) {
                    console.log("No rakiya, only JavaScript " + position.row + " " + position.col);
                    break;
                }
                else if (!canGoLeft(field[position.row][position.col]) && !canGoUp(field[position.row][position.col]) && !canGoDown(field[position.row][position.col])) {
                    console.log("No JavaScript, only rakiya " + position.row + " " + position.col);
                    break;
                }
            }

        if (canGoUp(field[position.row][position.col]) && position.row > 0) {
            if (field[position.row - 1][position.col] !== 'x') {
                field[position.row][position.col] = 'x';
                position.row -= 1;
            }
        }
        else if (canGoRight(field[position.row][position.col]) && position.col < COLS - 1) {
            if (field[position.row][position.col + 1] !== 'x') {
                field[position.row][position.col] = 'x';
                position.col += 1;
            }
        }
        else if (canGoDown(field[position.row][position.col]) && position.row < ROWS - 1) {
            if (field[position.row + 1][position.col] !== 'x') {
                field[position.row][position.col] = 'x';
                position.row += 1;
            }
        }
        else if (canGoLeft(field[position.row][position.col]) && position.col > 0) {
            if (field[position.row][position.col - 1] !== 'x') {
                field[position.row][position.col] = 'x';
                position.col -= 1;
            }

        }
        else if (!canGoUp(field[position.row][position.col]) && !canGoRight(field[position.row][position.col]) && !canGoDown(field[position.row][position.col]) && !canGoLeft(field[position.row][position.col])) {
            console.log("No JavaScript, only rakiya " + position.row + " " + position.col);
            break;
        }

            

    }

    function isOnUpBoundery(row) {
        return row === 0;
    }
    function isOnDownBoundery(row) {
        return row === ROWS - 1;
    }
    function isOnLeftBoundery(col) {
        return col === 0;
    }
    function isOnRightBoundery(col) {
        return col === COLS - 1;
    }

    function canGoUp(number) {
        if ((number & 1) === 1) {
            return true;
        }
        else {
            return false;

        }
    }

    function canGoRight(number) {
        if (number & (1 << 1) === 1) {
            return true;
        }
        return false;
    }

    function canGoDown(number) {
        if (number & (1 << 2) === 1) {
            return true;
        }
        return false;
    }

    function canGoLeft(number) {
        if (number & (1 << 3)) {
            return true;
        }
        return false;
    }
}

solve([
    '7 5',
    '9 3 11 9 3',
    '10 12 4 6 10',
    '12 3 13 1 6',
    '9 6 11 12 3',
    '10 9 6 13 6',
    '10 12 5 5 3',
    '12 5 5 5 6'
]);