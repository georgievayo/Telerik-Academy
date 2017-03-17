function solve(args){
var number = +args[0];
var digit = number % 10;
console.log(FindDigit(digit));

function FindDigit(num){
    switch(num){
        case 0: return 'zero';
        case 1: return 'one';
        case 2: return 'two';
        case 3: return 'three';
        case 4: return 'four';
        case 5: return 'five';
        case 6: return 'six';
        case 7: return 'seven';
        case 8: return 'eight';
        case 9: return 'nine';
    }
}
}