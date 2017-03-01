function solve(args){
    let text = args[0];
    text = text.replace(/\s/g, "&nbsp;");
    console.log(text);
}
solve([ 'hello world' ]);