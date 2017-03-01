/* Task Description */
/* 
* Create a module for a Telerik Academy course
  * The course has a title and presentations
    * Each presentation also has a title
    * There is a homework for each presentation
  * There is a set of students listed for the course
    * Each student has firstname, lastname and an ID
      * IDs must be unique integer numbers which are at least 1
  * Each student can submit a homework for each presentation in the course
  * Create method init
    * Accepts a string - course title
    * Accepts an array of strings - presentation titles
    * Throws if there is an invalid title
      * Titles do not start or end with spaces
      * Titles do not have consecutive spaces
      * Titles have at least one character
    * Throws if there are no presentations
  * Create method addStudent which lists a student for the course
    * Accepts a string in the format 'Firstname Lastname'
    * Throws if any of the names are not valid
      * Names start with an upper case letter
      * All other symbols in the name (if any) are lowercase letters
    * Generates a unique student ID and returns it
  * Create method getAllStudents that returns an array of students in the format:
    * {firstname: 'string', lastname: 'string', id: StudentID}
  * Create method submitHomework
    * Accepts studentID and homeworkID
      * homeworkID 1 is for the first presentation
      * homeworkID 2 is for the second one
      * ...
    * Throws if any of the IDs are invalid
  * Create method pushExamResults
    * Accepts an array of items in the format {StudentID: ..., Score: ...}
      * StudentIDs which are not listed get 0 points
    * Throw if there is an invalid StudentID
    * Throw if same StudentID is given more than once ( he tried to cheat (: )
    * Throw if Score is not a number
  * Create method getTopStudents which returns an array of the top 10 performing students
    * Array must be sorted from best to worst
    * If there are less than 10, return them all
    * The final score that is used to calculate the top performing students is done as follows:
      * 75% of the exam result
      * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
*/

function solve() {
  let courseTitle = "";
  let coursePresentations = [];
  let courseStudents = [];
  const VALIDATOR = {
    validateTitle: function(title){
      if(typeof title !== 'string' || title.startsWith(" ") || 
      title.endsWith(" ") || (/\s{2,}/g).test(title) || title.length < 1){
        throw Error();
      }
    },
    validateStudentName: function(name){
      if(name[0] === name[0].toLowerCase()){
        throw Error();
      }

      for(let i = 1; i < name.length; i++){
        if(name[i] !== name[i].toLowerCase()){
          throw Error();
        }
      }
    },
    validateID: function(id){
      if(typeof id !== 'number' || id < 1){
        throw Error();
      }
    }
  };

const generateID = (function () {
		let counter = 0;
		return function () {
			counter += 1;
			return counter;
		};
	})();


	var Course = {
		init: function(title, presentations) {
      VALIDATOR.validateTitle(title);
      courseTitle = title;
      if(presentations.length === 0){
        throw Error();
      }
      for(let i = 0; i < presentations.length; i++){
        VALIDATOR.validateTitle(presentations[i]);
      }
      coursePresentations = presentations;
      courseStudents = [];
      return this;
		},

		addStudent: function(name) {
      const names = name.split(' ');
      if(names.length > 2){
        throw Error();
      }
      VALIDATOR.validateStudentName(names[0]);
      VALIDATOR.validateStudentName(names[1]);
      var student = {
        firstname: names[0],
        lastname: names[1],
        id: generateID(),
        score: 0,
        submittedHomeworks: 0
      };
      courseStudents.push(student);
      return student.id;
		},

		getAllStudents: function() {
        return courseStudents;
		},

		submitHomework: function(studentID, homeworkID) {
      VALIDATOR.validateID(studentID);
      if(typeof homeworkID !== 'number' || homeworkID <= 0 || homeworkID > coursePresentations.length){
        throw Error();
      }
      let index = courseStudents.findIndex(x => x.id === studentID);
      courseStudents[index].submittedHomeworks++;
		},

		pushExamResults: function(results) {
      let ids = [];
      results.forEach(function(element) {
        if(element.StudentID === undefined || element.StudentID > courseStudents.length + 1 || ids.indexOf(element.StudentID) > -1 || element.score === 'undefined'){
          throw Error();
        }
        VALIDATOR.validateID(element.StudentID);
        if(typeof element.score !== 'number'){
          throw Error();
        }
        ids.push(element.StudentID);
        let index = courseStudents.findIndex(x => x.id === element.StudentID);
        if(index > -1){
        courseStudents[index].score = element.score;          
        }
      });
		},
		getTopStudents: function() {
      let result = [];
      courseStudents.sort((a,b) => (75/100) * a.score + (25/100)*(a.submittedHomeworks / coursePresentations.length) > (75/100) * b.score + (25/100)*(b.submittedHomeworks / coursePresentations.length) ? -1: 1);
      if(courseStudents.length <= 10){
        return courseStudents;
      }
      else{
        for(let i = 0; i < 10; i++){
          result.push(courseStudents[i]);
        }
        return result;
      }
		}
	};

	return Course;
}


module.exports = solve;
