function solve(args){
    var name = args[0];
console.log(Print(name));
}
function Print(name){
    var output = 'Hello, ';
    output += name;
    output += '!';
    return(output);
}
solve(['Pesho']);