function solve(args) {
    var numbers = args[0].split(' ');
    var first = +numbers[0],
        second = +args[1],
        third = +args[2];
    var max = GetMax(first, second) > third ? GetMax(first, second) : third;
    console.log(max);

    function GetMax(firstNumber, secondNumber) {
        if (firstNumber > secondNumber) {
            return firstNumber;
        }
        else {
            return secondNumber;
        }
    }
}
