function solve(args){
let expression = args[0];
let openBrackets = 0;
let closeBrackets = 0;
for(let i = 0; i < expression.length; i++){
    if(expression[i] === '('){
        openBrackets++;
    }
    if(expression[i] === ')'){
        closeBrackets++;
    }
}
if(closeBrackets === openBrackets){
    console.log('Correct');
}
else{
    console.log('Incorrect');
}
}
solve([ '((a+b)/5-d)' ]);