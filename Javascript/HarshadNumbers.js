/*
Source: http://www.codewars.com/kata/54a0689443ab7271a90000c6

Description:
Harshad numbers are positive numbers that can be divided 
(without remainder) by the sum of their digits.

Your task is to complete the skeleton Harshad object 
("static class") which has 3 functions.

1) "isValid" that checks if the number is a Harshad 
number or not // Harshad.isValid( 1 ) returns true
2) "getNext" that returns the next Harshad number 
// Harshad.getNext( 0 ) returns 1
3) "getSerie" that returns a serie of n Harshad number, 
optional start value not included 
// Harshad.getSerie( 3, 1000 ) returns [ 1002, 1008, 1010 ]
// Harshad.getSerie( 3 ) returns [ 1, 2, 3 ]

*/

/**
 * Utility class for Harshad numbers (also called Niven numbers).
 *
 * @namespace Harshad
 */
var Harshad = ( function() {
  'use strict';

  return {
    /**
     * Returns true when the given number is a valid Harshad number.
     *
     * @param {Number} number The given number
     * @returns {Boolean}
     * @function Harshad.isValid
     */
    isValid: function( number ) {

      var sumOfDigits = 0;
      var numberString = number.toString();
      for(var i = 0; i < numberString.length; i++){
        sumOfDigits += parseInt(numberString.charAt(i));
      }
      
      return number % sumOfDigits == 0 ? true : false;
    },
    /**
     * Gets the next Harshad number after the given number.
     *
     * @param {Number} number The given number
     * @returns {Number}
     * @function Harshad.getNext
     */
    getNext: function( number ) {

      var isHarshad = 0;
      var nextNumber = number;
      while( !isHarshad ){
        nextNumber += 1;
        if( Harshad.isValid(nextNumber) ){
          return nextNumber;
        }
      }
    },
    /**
     * Returns the suite of Harshad numbers, starting after a given number.
     *
     * @param {Number} count The number of elements to return
     * @param {Number} start The number after which the serie should start;
     *  defaults to 0
     * @returns {Array}
     * @function Harshad.getSerie
     */
    getSerie: function( count, start ) {
    
      var series = [];
      var startNumber = start ? start : 0;
      var i = 1;
      var newNumber;
      while (i <= count ){
        newNumber = Harshad.getNext(startNumber);
        series.push(newNumber);
        startNumber = newNumber;
         i++;
      }
      
      return series;
    }
  };

} () );
