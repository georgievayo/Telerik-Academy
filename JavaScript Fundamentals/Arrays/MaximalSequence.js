function solve(args){
    var arr = [];
    var n = args[0];
    var count = 1;
    var maxCount = 1;
    var element = arr[0];
    for(var i = 1; i < n + 1; i++){
        arr[i-1] = parseInt(args[i]);
    }
    for(var i = 1; i < arr.length; i++){
        if(arr[i] == element){
            count++;
             if(maxCount < count){
                maxCount = count;
            }
        }
        else{
            count = 1;
            element = arr[i];
        }
    }
    console.log(maxCount);
}