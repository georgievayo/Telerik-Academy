function solve(args){
    var number = String(args[0]);
    var output = 0;
    for(var i = 0, len = number.length; i < len; i++)
    {
        output += parseInt(findNum(number[i]) * Math.pow(16, len - i - 1));
    }
    console.log(output);
}

function findNum(symbol)
{
    switch(symbol)
    {
        case '0': return 0;
        case '1': return 1;
        case '2': return 2;
        case '3': return 3;
        case '4': return 4;
        case '5': return 5;
        case '6': return 6;
        case '7': return 7;
        case '8': return 8;
        case '9': return 9;
        case 'A': return 10;
        case 'B': return 11;
        case 'C': return 12;
        case 'D': return 13;
        case 'E': return 14;
        case 'F': return 15;
        
    }
}

solve(['FE']);