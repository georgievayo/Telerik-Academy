function solve(args){
    var x = parseFloat(args[0]);
    var y = parseFloat(args[1]);
    var output = "";
     if ((x - 1) * (x - 1) + (y - 1) * (y - 1) <= 1.5 * 1.5)
        {
            output += "inside circle";
        }
        else
        {
            output += "outside circle";
        }
        if ((x >= -1 && x <= 5) && (y <= 1 && y >= -1))
        {
            output += " inside rectangle";
        }
        else
        {
            output += " outside rectangle";
        }
        console.log(output);
}
solve(['2.5', '2']);