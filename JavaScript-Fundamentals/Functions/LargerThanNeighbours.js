function solve(args){
    var n = +args[0];
    var numbers = args[1].split(' ');
    var counter = 0;
    for(var i = 1; i < n - 1; i++){
        if(+numbers[i] > +numbers[i-1] && +numbers[i] > +numbers[i+1]){
            counter++;
            //console.log(numbers[i]);
        }
    }
    return(counter);
}
solve(['6', '-26 -25 -28 31 2 27']);