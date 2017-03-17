function solve(args) {
    var heights = args[0].split(' ').map(Number);
    var maxValley = 0;
    var Valley = 0;
    for (var i = 0; i < heights.length; i++) {
        if (isPeak(i) === true) {
            Valley += heights[i];
            var j;
            for(j = i + 1; isPeak(j) === false; j++){
                Valley += heights[j];
            }
            Valley += heights[j];
            if (Valley > maxValley) {
                maxValley = Valley;
            }
            Valley = heights[j];
            i = j;
        }
    }

    console.log(maxValley);

    function isPeak(index) {
        if (index === 0 || index === heights.length - 1){
            return true;
        }
        if(heights[index] > heights[index - 1] && heights[index] > heights[index + 1]){
            return true;
        }
        return false;
    }
}

solve([
    "5 1 7 4 8"
]);