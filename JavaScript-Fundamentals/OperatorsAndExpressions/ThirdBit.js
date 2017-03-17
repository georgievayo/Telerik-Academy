function solve(args){
    var number = parseInt(args[0]);
    var mask = 1 << 3;
    var numAndMask = (number & mask) >> 3;
    if(numAndMask == 1){
        console.log('1');
    }
    else{
        console.log('0');
    }

}

solve(['15']);