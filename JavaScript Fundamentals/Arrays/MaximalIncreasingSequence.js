function solve(args) {
    var n = parseInt(args[0]);
    var arrOfNumbers = new Array();
    for (var i = 1; i < n + 1; i++) {
        arrOfNumbers[i - 1] = parseInt(args[i]);
    }
    var numOfSequence = arrOfNumbers[0];
    var counter = 1, maxCounter = 1;
    for (var i = 1; i < n; i++) {
        if (arrOfNumbers[i] > numOfSequence) {
            numOfSequence = arrOfNumbers[i];
            counter++;
            if (maxCounter < counter) {
                maxCounter = counter;
            }
        }
        else if (arrOfNumbers[i] <= numOfSequence) {
            numOfSequence = arrOfNumbers[i];
            counter = 1;
        }
    }
    console.log(maxCounter);
}
solve(['8', '7', '3', '2', '3', '-1', '0', '2', '4']);