function solve(args){
    for(var row = 1; row <= args[0]; row++)
    {
        var number = row;
        var rowS = "";
        for(var col = 1; col <= args[0];col++)
        {
            rowS += number += ' ';
            number++;
        }
        console.log(rowS);
    }
}