function solve(args){
let text = "";
for(let i = 0; i < args.length; i++){
    text += args[i].trimLeft();
}
const openTag = /\<[a-z]*\>/g;
const closeTag = /\<\/[a-z]*\>/g;
var output;

output = text.replace(closeTag, "");
output = output.replace(openTag, "");
console.log(output);
}

solve([
    '<html>',
    '  <head>',
    '    <title>Sample site</title>',
    '  </head>',
    '  <body>',
    '    <div>text',
    '      <div>more text</div>',
    '      and more...',
    '    </div>',
    '    in body',
    '  </body>',
    '</html>'
]);