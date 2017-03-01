function solve(args) {
    var minAge = +args[2];
    var first = "";
    var last = "";
    for (var i = 0; i < args.length; i += 3) {
        var person = { firstName: args[i], lastName: args[i + 1], age: +args[i + 2] };
        console.log(person);
        console.log(minAge);
        if (person.age <= minAge) {
            minAge = person.age;
            first = person.firstName;
            last = person.lastName;
            //console.log(first);
        }
    }
    console.log(first + " " + last);
}
solve([
  'Gosho', 'Petrov', '32',
  'Bay', 'Ivan', '81',
  'John', 'Doe', '42'
]);