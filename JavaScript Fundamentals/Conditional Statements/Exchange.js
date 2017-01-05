function solve(args){
    var a = parseFloat(args[0]);
    var b = parseFloat(args[1]);
    if(a > b){
        var temp = a;
        a = b;
        b = temp;
    }
    console.log(a + ' ' + b)
}