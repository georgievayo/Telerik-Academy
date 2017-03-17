function solve(args){
    var a = parseFloat(args[0]);
    var b = parseFloat(args[1]);
    var c = parseFloat(args[2]);

    if(a > b)
    {
        if(a > c)
        {
            console.log(a);
        }
        else
        {
            console.log(c);
        }
    }
    else
    {
        if(b > c)
        {
            console.log(b);
        }
        else{
            console.log(c);
        }
    }
}