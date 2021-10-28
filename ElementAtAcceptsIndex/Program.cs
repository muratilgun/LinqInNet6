using System;
using System.Linq;

var names = new[] {"Nick", "Mike","John","Leyla","David","Damian"};

var thirdItemFromTheEnd = names.ElementAt(^3);
// thirdItemFromTheEnd : "Leyla"
var ele = names.ElementAt(0);
// ele : "Nick"
Console.ReadKey();


/*C# 8.0 ve sonraki sürümlerde mevcut olan ^ operatörü, bir dizinin sonundan öğe konumunu belirtir.*/

/*Önceden, bir koleksiyonun sonundan bir şey elde etmek istiyorsanız, koleksiyonun uzunluğunu hesaplamanız
 ve ardından öğeyi bu dizine göre çıkarmanız ve gerektiğinde çıkarmanız gerekiyordu
 
 Movie lastMovie = movies.ElementAt(movies.Count() - 1);
 Movie lastMovie = movies.ElementAt(^1);
*/