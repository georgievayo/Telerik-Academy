function solve(args) {
    var n = +args[0];
    var arr = [n + 1];
    for(var i = 2; i <= n; i++){
        arr[i] = false;
    }
    arr[0] = arr[1] = true;
    var biggest = 0;
    for (var i = 2, len = Math.sqrt(n); i <= len; i++) {
        if (arr[i] == false) {
            for (var j = i * i; j <= n; j += i) {
                arr[j] = true;
            }
        }
    }
    for(var i = n; i >= 0; i--){
        if(!arr[i]){
            return i;
            break;
        }
    }
}