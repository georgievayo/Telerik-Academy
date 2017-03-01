function solve(args) {
    const n = +args[0];

    let sum = 0;
    sum += +args[1];
    let i;
    if (sum % 2 === 0) {
        i = 3;
    }
    else {
        i = 2;
    }
    while (i < args.length) {
        let number = +args[i];
        if (number % 2 === 0) {
            sum += number;
            i += 2;
        }
        else {
            sum *= number;
            i++;
        }
        if (sum > 1024) {
            sum %= 1024;
        }
    }
    console.log(sum);
}

solve([
    '10',
    '1',
    '2',
    '3',
    '4',
    '5',
    '6',
    '7',
    '8',
    '9',
    '0'
]);

solve([
    '9',
    '9',
    '9',
    '9',
    '9',
    '9',
    '9',
    '9',
    '9',
    '9'
]);