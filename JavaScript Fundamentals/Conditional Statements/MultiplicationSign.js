function solve(args){
    var a = parseFloat(args[0]);
    var b = parseFloat(args[1]);
    var c = parseFloat(args[2]);
if (a == 0 || b == 0 || c == 0)
        {
            console.log("0");
        }
        else if ((a > 0 && b > 0 && c > 0) || (a < 0 && b < 0 && c > 0) || (a > 0 && b < 0 && c < 0) || (a < 0 && b > 0 && c < 0))
        {
            console.log("+");
        }
        else console.log("-");
}