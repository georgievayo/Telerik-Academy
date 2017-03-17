function solve(args) {
    var n = +args[0];
    var numbers = args[1].split(' ');
    var hasLarger = false;
    for (var i = 1; i < n - 1; i++) {
        if (GreaterThanNeighbours(+numbers[i - 1], +numbers[i], +numbers[i + 1])) {
            console.log(i);
            hasLarger = true;
            break;
        }
    }
    if (!hasLarger) {
        console.log('-1');
    }
    function GreaterThanNeighbours(number1, number2, number3) {
        return number2 > number1 && number2 > number3;
    }
}