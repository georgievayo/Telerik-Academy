function solve(args) {
    let text = args[0].split('>');
    let tag = 'o';
    let parsedText = "";
console.log(text);
for(let i = 0; i < text.length; i++){
    let index = 0;
    while(text[i][index] != '<' || index != text[i].length - 1)
    {
        if(tag === 'o'){
        parsedText += text[i][index];
        }
        else if(tag === 'u'){
        parsedText += text[i][index].toUpperCase();            
        }
        else{
        parsedText += text[i][index].toLowerCase();                      
        }
        index++;
        console.log(parsedText);
    }
    if(index != text[i].length - 1 && text[i][index] === '<')
    {
        if(text[i][index + 1] === 'o'){
            tag = 'o';
        }
        else if(text[i][index + 1] === 'u'){
             tag = 'u';
        }
        else{
            tag = 'l';
        }
    }
}
console.log(parsedText);
}

solve(['We are <orgcase>liViNg</orgcase> in a <upcase>yellow submarine</upcase>. We <orgcase>doN\'t</orgcase> have <lowcase>anything</lowcase> else.']);