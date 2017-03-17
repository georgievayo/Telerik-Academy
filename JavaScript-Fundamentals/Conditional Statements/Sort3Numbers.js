function solve(args){
    var a = parseFloat(args[0]);
    var b = parseFloat(args[1]);
    var c = parseFloat(args[2]);
    var output = "";
    if(a > b)
    {
        if(a > c)
        {
            output += a += ' ';
            if(b > c)
            {
                output += b += ' ';
                output += c;
            }
            else{
                output += c += ' ';
                output +=b;
            }
        }
        else
        {
            output += c += ' ';
            output += a += ' ';
            output += b;
        }
    }
    else
    {
        if(b > c)
        {
            output += b += ' ';
            if(a > c)
            {
                output += a += ' ';
                output += c;
            }
            else{
                output += c += ' ';
                output += a;
            }
        }
        else{
            output += c += ' ';
            output += b += ' ';
            output +=a;

        }
    }
                console.log(output);
}