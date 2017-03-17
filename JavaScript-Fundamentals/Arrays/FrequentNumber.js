function solve(args){
    var n = parseInt(args[0]);
            var arr = new Array;
            for (var i = 1; i < n + 1; i++)
            {
                arr[i - 1] = parseInt(args[i]);
            }
           arr.sort();
            var counter = 1, maxCount = 0, firstElement = arr[0], repeatingNumber = arr[0];
            for (var i = 1; i < n; i++)
            {
                if (arr[i] == firstElement)
                {
                    counter++;
                    if (counter > maxCount)
                    {
                        maxCount = counter;
                        repeatingNumber = arr[i];
                    }
                }
                else
                {
                    firstElement = arr[i];
                    counter = 1;
                }
            }
            var output = "";
            output +=repeatingNumber;
            output += " (";
            output+= maxCount;
            output += " times)";
            console.log(output);
}
solve(['13', '4', '1', '1', '4', '2', '3', '4', '4', '1', '2', '4', '9', '3']);