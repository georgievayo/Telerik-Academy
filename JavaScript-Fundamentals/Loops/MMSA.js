function solve(args){
    var i = 0;
    var sum = 0;
    var min = parseFloat(args[0]);
    var max = parseFloat(args[0]);

    while(args[i] != null){
        var number = parseFloat(args[i]);
        sum+=number;
        if(number < min)
        {
            min = number;
        }
        if(number > max){
            max = number;
        }
        i++;
    }

    console.log('min=' + min.toFixed(2));
    console.log('max=' + max.toFixed(2));
    console.log('sum=' + sum.toFixed(2));
    console.log('avg=' + (sum/i).toFixed(2));
}