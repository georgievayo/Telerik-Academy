function solve(args){
    let heights = args[0].split(' ').map(Number);
    let sum = 0;
    for(let i = 1; i < heights.length - 3; i++){
        if(isHeight(i) && isHeight(i + 2)){
            sum += heights[i+1];
        }
    }
    function isHeight(index){
        return heights[index] > heights[index - 1] && heights[index] > heights[index + 1];
    }
    console.log(sum);
}
solve([
    "53 20 1 30 2 40 3 10 1"
]);