function solve(args) {
    const size = args[0].split(' ').map(Number);
    const ROWS = size[0];
    const COLS = size[1];
    let LPos;
    let NPos;
    let WPos;
    const positionsAll = args[1].split(";");
    let field = new Array(ROWS);
    for (let i = 0; i < ROWS; i++) {
        field[i] = new Array(COLS);
    }
    //Get starting positions
    for (let i = 0; i < positionsAll.length; i++) {
        var positions = positionsAll[i].split(' ').map(Number);
        if (i === 0) {
            WPos = { row: positions[0], col: positions[1] };
        }
        else if (i === 1) {
            NPos = { row: positions[0], col: positions[1] };
        }
        else {
            LPos = { row: positions[0], col: positions[1] };
        }
    }

    // Set starting positions
    field[WPos.row][WPos.col] = 'w';
    field[NPos.row][NPos.col] = 'n';
    field[LPos.row][LPos.col] = 'l';

    //Read commands
    let n = args.length;
    let i = 2;
    let WisStucked = false;
    let NisStucked = false;

    while (i < n) {
        let command = args[i].split(' ');
        if (command[0] === 'mv') {
            // TODO move command

            if (command[1] === 'Lsjtujzbo') {
                // if princess didn't lay a trap
                if(field[LPos.row][LPos.col] !== 'x'){
                field[LPos.row][LPos.col] = undefined;
                }
                Move(LPos, command[2]);
            }
            else if (command[1] === 'Wboup' && !WisStucked) {
                field[WPos.row][WPos.col] = undefined;
                Move(WPos, command[2]);
                // if troll go to trap
                if(field[WPos.row][WPos.col] === 'x'){
                    WisStucked = true;
                }
                field[WPos.row][WPos.col] = 'w';
            }
            else if (command[1] === 'Nbslbub' && !NisStucked) {
                field[NPos.row][NPos.col] = undefined;
                Move(NPos, command[2]);
                // if troll go to trap                
                if(field[NPos.row][NPos.col] === 'x'){
                    NisStucked = true;
                }
                field[NPos.row][NPos.col] = 'n';
            }

            if(NisStucked && NPos.row === WPos.row && NPos.col === WPos.col){
                NisStucked = false;
            }
             if(WisStucked && NPos.row === WPos.row && NPos.col === WPos.col){
                WisStucked = false;
            }

        }
        else {
            // TODO trap command

            field[LPos.row][LPos.col] = 'x';
        }

        if(PrincessCanBeCaught(NPos, LPos) || PrincessCanBeCaught(WPos, LPos)){
            console.log("The trolls caught Lsjtujzbo at " + LPos.row + " " + LPos.col);
        }

        if((WisStucked && NisStucked) || (LPos.row === ROWS - 1 && LPos.col === COLS - 1)){
            console.log("Lsjtujzbo is saved! " + WPos.row + ' ' + WPos.col + ' ' + NPos.row + ' ' + NPos.col);
        }
        i++;
    }
function PrincessCanBeCaught(pos, LPos){
    return ((pos.row === LPos.row && (pos.col === LPos - 1 || pos.col === LPos + 1)) 
    || (pos.row === LPos.row - 1 && (pos.col === LPos.col - 1 || pos.col === LPos.col || pos.col === LPos.col + 1)) 
    || (pos.row === LPos.row + 1 && (pos.col === LPos.col - 1 || pos.col === LPos.col || pos.col === LPos.col + 1)));
}

    function Move(pos, dir) {
        switch (dir) {
            case 'd': pos.row += 1; break;
            case 'u': pos.row -= 1; break;
            case 'l': pos.col -= 1; break;
            case 'r': pos.col += 1; break;
        }
        if (pos.row < 0) {
            pos.row += 1;
        }
        if (pos.row >= ROWS) {
            pos.row -= 1;
        }
        if (pos.col < 0) {
            pos.col += 1;
        }
        if (pos.col >= ROWS) {
            pos.col -= 1;
        }
    }
}

solve([
    '7 7',
    '0 1;0 2;3 3',
    'mv Lsjtujzbo l',
    'lay trap',
    'mv Lsjtujzbo r',
    'lay trap',
    'mv Lsjtujzbo r',
    'lay trap',
    'mv Lsjtujzbo d',
    'mv Lsjtujzbo r',
    'mv Lsjtujzbo r',
    'mv Lsjtujzbo r',
    'mv Lsjtujzbo r',
    'mv Wboup d',
    'mv Wboup d',
    'mv Wboup l',
    'mv Wboup l',
    'mv Nbslbub r',
    'mv Nbslbub r',
    'mv Nbslbub r',
    'mv Nbslbub d',
    'mv Lsjtujzbo d',
    'mv Lsjtujzbo l',
    'mv Lsjtujzbo l',
    'mv Nbslbub l',
    'mv Nbslbub d',
    'mv Nbslbub d',
    'mv Wboup d',
    'mv Wboup d',
    'mv Wboup r',
    'mv Lsjtujzbo d',
    'mv Wboup d',
    'mv Wboup d',
    'mv Wboup r',
    'mv Lsjtujzbo r',
    'mv Lsjtujzbo r'
]);