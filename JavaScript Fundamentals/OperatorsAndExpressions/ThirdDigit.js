function solve(args){
    var digit = parseInt((args[0]/100))%10;
    if( digit === 7)
    {
        console.log('true');
    }
    else{
        console.log('false ' + digit);
    }
}