/*
Source: http://www.codewars.com/kata/556deca17c58da83c00002db/train/csharp

Description:
Well met with Fibonacci bigger brother, AKA Tribonacci.

As the name may already reveal, it works basically like a Fibonacci, 
but summing the last 3 (instead of 2) numbers of the sequence 
to generate the next.

So, if we are to start our Tribonacci sequence with [1,1,1] 
as a starting input (AKA signature), we have this sequence:
[1,1,1,3,5,9,17,31,...]
But what if we started with [0,0,1] as a signature?
We would get: [0,0,1,1,2,4,7,13,24,...]

You need to create a fibonacci function that given a signature array/list, 
returns the first n elements - signature included of the so seeded sequence.

Signature will always contain 3 numbers; n will always be a non-negative number.

*/

function tribonacci(signature,n){
  var tribArray = signature;
  for(var i = 3; i <= n - 1; i++){
    tribArray[i] = tribArray[i - 1] + tribArray[i - 2] + tribArray[i - 3];
  }
  
  return tribArray.slice(0,n);
}

