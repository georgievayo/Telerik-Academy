function solve(args){
    var n = parseInt(args[0]);
            var arr = new Array();
            for (var i = 1; i < n + 1; i++)
            {
                arr[i - 1] = parseInt(args[i]);
            }
            var x = parseInt(args[n+1]);
            var min = 0;
            var max = n - 1;
            do
            {
                var mid = parseInt((min + max) / 2);
                if (x > arr[mid])
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }
                if (arr[mid] == x)
                {
                    console.log(mid);
                    break;
                }
                if (min > max && arr[mid] != x)
                {
                    console.log("-1");
                }
                
            } while (min <= max);
}