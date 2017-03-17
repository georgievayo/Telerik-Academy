function solve(args){
    var points = [];
    var distances = [];
   for(var i = 0; i < 12; i+=2){
       var point = {x: +args[i], y: +args[i+1]};
       points.push(point);
   }
   for(var i = 0; i < 6; i+=2){
       var dist = Math.sqrt(Math.pow((points[i+1].x - points[i].x),2)+Math.pow((points[i+1].y - points[i].y),2));
       distances.push(dist);
       console.log(dist.toFixed(2));
   }
   if(distances[0] + distances[1] > distances[2] && distances[0] + distances[2] > distances[1] && distances[1] + distances[2] > distances[0]){
       console.log("Triangle can be built");
   }
   else{
       console.log("Triangle can not be built");
   }
   
}