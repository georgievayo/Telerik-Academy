function solve(args) {
    var n = parseInt(args[0]);
    var arr = [n];
    for (var i = 1; i < n + 1; i++) {
        arr[i - 1] = +args[i];
    }
    for (var i = 0; i < n; i++) {
        var indexOfMin = +i;
        for (var j = i + 1; j < n; j++) {
            if (arr[j] < arr[indexOfMin]) {
                indexOfMin = +j;
            }
        }
        if (i != indexOfMin) {
            arr[i] = arr[i] ^ arr[indexOfMin];
            arr[indexOfMin] = arr[i] ^ arr[indexOfMin];
            arr[i] = arr[i] ^ arr[indexOfMin];
        }
    }
    
    for (var i = 0; i < n; i++) {
        console.log(arr[i]);
    }
}
solve(['6', '3', '4', '-1', '5', '2', '7']);