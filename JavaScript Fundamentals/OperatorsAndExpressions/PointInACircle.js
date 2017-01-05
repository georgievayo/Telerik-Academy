function solve(args){
    var x = parseFloat(args[0]);
    var y = parseFloat(args[1]);
    var distance = (Math.sqrt(x * x + y * y)).toFixed(2);
        if (distance <= 2)
        {
            console.log("yes " + distance);
        }
        else console.log("no " + distance);

}