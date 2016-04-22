/*
Source: http://www.codewars.com/kata/53907ac3cd51b69f790006c5

Description:
Calculate type of triangle with three given sides 
a, b and c (given in any order).

If all angles are less than 90°, this triangle is acute 
and function should return 1.

If one angle is strictly 90°, this triangle is right and 
function should return 2.

If one angle more than 90°, this triangle is obtuse and 
function should return 3.

If three sides cannot form triangle, or one angle is 180° 
(which turns triangle into segment) - function should return 0.
*/

function triangleType(a, b, c){

  var sides = [a, b, c];
  sides.sort(function(i, j){return i - j;} );
  
  var trianglesType = {nottriangle: 0, acute: 1, right: 2, obtuse: 3};
  
  // check if it is not a triangle at all
  if( sides[2] >= sides[1] + sides[0]){
    return trianglesType["nottriangle"];
  }
  
  // check if triangle is right 
  if( Math.pow(sides[2], 2) == Math.pow(sides[0], 2) + Math.pow(sides[1], 2) ){
    return trianglesType["right"];
  }
  else {
    // calculate cosine of biggest angle, according the law of cosines 
    var angleCosine = ( Math.pow(sides[0], 2) + Math.pow(sides[1], 2) 
      - Math.pow(sides[2], 2) ) / ( 2 * sides[0] * sides[1] );
    
    // if its cosine lies between -1 and 0 so it is obtuse angle. 
    // So, triangle is obtuse too
    if( angleCosine > -1 && angleCosine < 0 ){
      return trianglesType["obtuse"];
    }
    
    // if its cosine lies between 0 and 1, angle is acute. 
    // So, triangle is also acute
    else if( angleCosine > 0 && angleCosine < 1 ){
      return trianglesType["acute"];
    }
  }
}

 // return 0 (Not triangle)
console.log(triangleType(2, 4, 6));

// return 1 (Acute)
console.log(triangleType(8, 5, 7));

// return 2 (Right)
console.log(triangleType(3, 4, 5));

// return 3 (Obtuse)
console.log(triangleType(7, 12, 8)); 
