function solve(args){
    var n = +args[0];
    var arr = args[1].split(' ');
    var k = n - 1;
    for(var i = n - 1; i > 0; i--){
        var j = FindMax(arr,i);
        var temp = +arr[j];
        arr[j] = +arr[k];
        arr[k] = temp;
        k--;
    }

    console.log(arr.join(' '));

    function FindMax(arr, index){
        var max = +arr[index];
        var maxIndex = +index;
        for(var i = index - 1; i >= 0; i--){
            if(arr[i] > max){
                max = +arr[i];
                maxIndex = +i;
            }
        }
        return maxIndex;
    }
}