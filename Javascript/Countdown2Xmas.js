/*
Source: http://www.codewars.com/kata/56f6b23c9400f5387d000d48

Description:
Your function should take 1 argument (a Date object) 
which will be the day of the year it is currently. 
The function should then work out how many days it is until Christmas.
*/

function daysUntilChristmas(days) {
  var currentYear  = days.getFullYear();
  var currentMonth = days.getMonth();
  var currentDay   = days.getDate();
  
  var christmasDate = new Date(currentYear,11,25);;
  if( currentDay > 25 && currentMonth == 11){
    christmasDate = new Date(currentYear + 1,11,25);
  }

  var diffDays = (christmasDate - days) / ( 1000 * 3600 * 24 );
  
  return diffDays;
}

// should return 16
console.log(daysUntilChristmas(new Date(2016,11,9)));

// should return 0
console.log(daysUntilChristmas(new Date(2016,11,25)));

// should return 364
console.log(daysUntilChristmas(new Date(2016,11,26)));
