function solve(args){
    var output = "";
    for(var i = 1; i <= args[0]; i++){
        output += i;
        if(i < args[0])
        output += ' ';

    }
    console.log(output);
}

solve(['10']);