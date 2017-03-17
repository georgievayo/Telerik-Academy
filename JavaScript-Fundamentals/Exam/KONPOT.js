function solve(args) {
    let text = "";
    for (let i = 0; i < args.length; i++) {
        text += args[i].replace(/\s+/g, "");
    }
    text = text.replace(/^;+/, "");
    text = text.replace(/;$/, "");
    text = text.replace(/;{2,}/g, ";");
    text = text.replace(/;{1}{{1}/g, "{");
    text = text.replace(/;+}{1}/g, "}");
    text = text.replace(/{{1};+/g, "{");
    text = text.replace(/}{1};+/g, "}");
    text = text.replace(/{{1}}{1}/g, "");
    //console.log(text);


    //console.log(text);

    let matches = text.match(/[a-zA-Z0-9_]+|_/g);
    let counter = 0;
    let newMatches = [];


    for (let i = 0; i < matches.length; i++) {
        if (counter < 63) {
            
                text = text.replace(matches[i], 'a');
            counter++;
        }
        else {
            text = text.replace(matches[i], 'ab');
        }
    }
    console.log(text);
    console.log(text.length);
    //console.log(matches);
}

solve([
    '; ;;;jGefn4E5Pvq    ;;  ;  ; ;',
    'tQRZ5MMj26Ov { {    {;    ;;    5OVyKBFu7o1T2 ;szDVN2dWhex1V;1gDdNdANG2',
    ';    ;    ;  ;; jGefn4E5Pvq   ;;    ;p0OWoVFZ8c;;}    ;  ; ;',
    '5OVyKBFu7o1T2   ;  szDVN2dWhex1V ;    ;tQRZ5MMj26Ov    ;  ;   };',
    '1gDdNdANG2    ;   p0OWoVFZ8c ;  jGefn4E5Pvq ;; {;Z9n;;',
    ';1gDdNdANG2;   ;;    ;   ;jGefn4E5Pvq    ;; ;;p0OWoVFZ8c;;    ;;',
    ';',
    'tQRZ5MMj26Ov  ;',
    '{    ;szDVN2dWhex1V;   ;',
    ';   jGefn4E5Pvq   ;  ;  } }}'
]);
solve([
    '1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12; 13; 14;',
    '15; 16; 17; 18; 19; 20; 21; 22; 23; 24; 25; 26; 27; 28;',
    '29; 30; 31; 32; 33; 34; 35; 36; 37; 38; 39; 40; 41; 42;',
    '43; 44; 45; 46; 47; 48; 49; 50; 51; 52; 53; 54; 55; 56;',
    '57; 58; 59; 60; 61; 62; 63; 64; 65; 66; 67; 68; 69; 70;'
]);