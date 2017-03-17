function solve(args) {
    var number = parseInt(args[0]);
    console.log(number);
    if (number < 10) {
        switch (number) {
            case 0: console.log('Zero'); break;
            case 1: console.log('One'); break;
            case 2: console.log('Two'); break;
            case 3: console.log('Three'); break;
            case 4: console.log('Four'); break;
            case 5: console.log('Five'); break;
            case 6: console.logn('Six'); break;
            case 7: console.log('Seven'); break;
            case 8: console.log('Eight'); break;
            case 9: console.log('Nine'); break;
            default: console.log('not a digit'); break;
        }
    }
    else if (number > 10 && number < 20) {
        switch (number) {
            //case 10: console.log('Zero'); break;
            case 11: console.log('Eleven'); break;
            case 12: console.log('Twelve'); break;
            case 13: console.log('Thirteen'); break;
            case 14: console.log('Fourteen');break;
            case 15: console.log('Fifteen'); break;
            case 16: console.logn('Sixteen'); break;
            case 17: console.log('Seventeen'); break;
            case 18: console.log('Eighteen'); break;
            case 19: console.log('Nineteen'); break;
            //default: console.log('not a digit'); break;
        }
    }
    else if(number%10==0){
        switch(number)
    {
        case 10: console.log('Ten'); break;
        case 20: console.log('Twenty'); break;
        case 30: console.log('Thirty'); break;
        case 40: console.log('Fourty'); break;
        case 50: console.log('Fifty'); break;
        case 60: console.logn('Sixty'); break;
        case 70: console.log('Seventy'); break;
        case 80: console.log('Eighty'); break;
        case 90: console.log('Ninety'); break;
       // default: console.log('not a digit'); break;
    }
    }
    else if (number > 20 && number < 100) {
        var first = number%10;
        var second = number - first;
        console.log(secondDigit(second) + ' ' + firstDigit(first));
    }
    else if(number > 99 && number <1000)
    {
        var firstD = number%10;
        var hundred = parseInt(number / 100);
        var secondD = number - hundred*100 - firstD;

        console.log(firstDigitUpper(hundred) + ' hundred '+ secondDigitLower(secondD) + ' ' + firstDigit(firstD));
    }
}

function firstDigit(number)
{
    switch (number) {
            case 1: return('one'); break;
            case 2: return('two'); break;
            case 3: return('three'); break;
            case 4: return('four'); break;
            case 5: return('five'); break;
            case 6: return('six'); break;
            case 7: return('seven'); break;
            case 8: return('eight'); break;
            case 9: return('nine'); break;
            default: console.log('not a digit'); break;
        }
}

function firstDigitUpper(number)
{
    switch (number) {
            case 1: return('One'); break;
            case 2: return('Two'); break;
            case 3: return('Three'); break;
            case 4: return('Four'); break;
            case 5: return('Five'); break;
            case 6: return('Six'); break;
            case 7: return('Seven'); break;
            case 8: return('Eight'); break;
            case 9: return('Nine'); break;
        }
}
function secondDigit(number)
{
    switch(number)
    {
        case 10: return('Ten'); break;
        case 20: return('Twenty'); break;
        case 30: return('Thirty'); break;
        case 40: return('Fourty'); break;
        case 50: return('Fifty'); break;
        case 60: return('Sixty'); break;
        case 70: return('Seventy'); break;
        case 80: return('Eighty'); break;
        case 90: return('Ninety'); break;
       // default: console.log('not a digit'); break;
    }
}
function secondDigitLower(number)
{
    switch(number)
    {
        case 10: return('ten'); break;
        case 20: return('twenty'); break;
        case 30: return('thirty'); break;
        case 40: return('fourty'); break;
        case 50: return('fifty'); break;
        case 60: return('sixty'); break;
        case 70: return('seventy'); break;
        case 80: return('eighty'); break;
        case 90: return('ninety'); break;
       // default: console.log('not a digit'); break;
    }
}
solve(['125']);