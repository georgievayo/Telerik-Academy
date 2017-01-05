function solve(args){
    var number = parseInt(args[0]);
    if(number > 0){
        var square = Math.sqrt(number);
        var isPrime = true;
        for(var i = 2; i <= square; i++){
            if(number % i == 0){
                isPrime = false;
            }
        }
        if(isPrime){
            console.log('true');
        }
        else{
            console.log('false');
        }
    }
    else{
        console.log('false');
    }
}
solve(['6']);