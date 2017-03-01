function solve(args){
    var sizes = args[0].split(' ').map(Number);
    var arr = new Array(sizes[0]);
    for(var i = 0; i < arr.length; i++){
        arr[i] = new Array(sizes[1]);
    }
    var coordinates = args[1].split(';');
    for(var i = 0; i < coordinates.length; i++){
        var coord = coordinates[i].split(' ').map(Number);
        arr[coord[0]][coord[1]] = -1;
    }

//Koceto's tanks
    arr[0][0] = 0;
    arr[0][1] = 1;
    arr[0][2] = 2;
    arr[0][3] = 3;
//Cuki's tanks
arr[sizes[0] - 1][sizes[1] - 1] = 4;
arr[sizes[0] - 1][sizes[1] - 2] = 5;
arr[sizes[0] - 1][sizes[1] - 3] = 6;
arr[sizes[0] - 1][sizes[1] - 4] = 7;

var tankPositions = [
    {row: 0, col: 0},
    {row: 0, col: 1},
    {row: 0, col: 2},
    {row: 0, col: 3},
    {row: sizes[0] - 1, col: sizes[1] - 1},
    {row: sizes[0] - 1, col: sizes[1] - 2},
    {row: sizes[0] - 1, col: sizes[1] - 3},
    {row: sizes[0] - 1, col: sizes[1] - 4},
];
    const n = +args[2];
    for(var i = 0; i < n; i++)
    {
        const request = args[i + 3];
        if(isMove(request) === true)
        {
            var items = request.split(' ');
    tankPositions
            Move()
        }
        else{

        }
    }
function Move(request){
    
    
    var deltaRow, deltaCol;
    if(items[3]==='l'){
        // arr[row][col - (+items[2])] = arr[row][col];
        // arr[row][col] = '';
        deltaCol = -1;
    }
    else if(items[3]==='r')
    {
        // arr[row][col + (+items[2])] = arr[row][col];
        // arr[row][col] = '';
        deltaCol = 1;
    }
    else if(items[3] === 'd')
    {
        // arr[row + (+items[2])][col] = arr[row][col];
        // arr[row][col] = '';
        deltaRow = 1;
    }
    else if(items[3] === 'u'){
        // arr[row - (+items[2])][col] = arr[row][col];
        // arr[row][col] = '';
        deltaRow = -1;
    }
}

function Shoot(request){

}

function isMove(str){
    if(str.startsWith("mv")){
        return true;
    }
    return false;
}
console.log(arr);

}
solve(['10 5', '2 0;2 1;2 2;2 3;2 4']);