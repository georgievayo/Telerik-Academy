function solve(args) {
    var firstWord = args[0];
    var secondWord = args[1];
    var equal = true;
    for (var i = 0, len = firstWord.length > secondWord.length ? +firstWord.length : +secondWord.length; i < len; i++) {
        if (firstWord[i] < secondWord[i]) {
            console.log("<");
            equal = false;
            break;
        }
        else if (firstWord[i] > secondWord[i]) {
            console.log(">");
            equal = false;
            break;
        }
    }
    if (equal) {
            if (firstWord.length > secondWord.length) {
                console.log(">");
            }
            else if (firstWord.length < secondWord.length) {
                console.log("<");
            }
            else {
                console.log("=");
            }
    }
}

solve(['hello', 'halo']);