function solve(args) {
    let word = args[0];
    let reversed = "";
    for (let i = word.length - 1; i >= 0; --i) {
        reversed += word[i];
    }
    console.log(reversed);
}
solve([ 'sample' ]);