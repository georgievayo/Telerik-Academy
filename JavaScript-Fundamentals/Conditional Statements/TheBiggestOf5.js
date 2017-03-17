function solve(args) {
    var a = parseFloat(args[0]);
    var b = parseFloat(args[1]);
    var c = parseFloat(args[2]);
    var d = parseFloat(args[3]);
    var e = parseFloat(args[4]);
    var max1 = a;
    var max2 = c;
    if (b > a) {
        max1 = b;
    }
    if (d > c) {
        max2 = d;
    }
    if (max2 > max1) {
        max1 = max2;
    }
    if (e > max1) {
        max1 = e;
    }
    console.log(max1);
}