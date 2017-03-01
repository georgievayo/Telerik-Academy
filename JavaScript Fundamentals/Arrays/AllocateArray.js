function solve(args)
{
    var numbers = [];
    for(var i = 0; i< args[0]; i++){
        numbers[i] = i*5;
        console.log(numbers[i]);
    }
}
solve(['5']);