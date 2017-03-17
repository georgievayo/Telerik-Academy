function solve(args)
{
    var a = args[0];
    var b = args[1];
    var perimeter = 2*a+2*b;
    var area = a*b;
    console.log(area.toFixed(2) + ' ' + perimeter.toFixed(2));
}