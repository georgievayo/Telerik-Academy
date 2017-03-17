function solve(args){
let word = args[0].toLowerCase();
let text = args[1].toLowerCase();
let count = 0;

for(let i = 0; i < text.length; i++){
if(text[i] === word[0]){
    if(text.substring(i, i + word.length) === word){
        count++;
    }
}
}
console.log(count);
}
solve([
    'in',
    'We are living in an yellow submarine. We don\'t have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.'
]);