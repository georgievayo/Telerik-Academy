function solve(args){
    var n = +args[0];
    var numbers = args[1].split(' ');
    var number = +args[2];
    var counter = 0;
    for(var i = 0; i < n; i++){
        if(numbers[i]==number)
            counter++;
    }
    console.log(counter);
}