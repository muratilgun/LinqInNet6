using System;
using System.Linq;

var names = new[] {"Nick", "Mike","John","Leyla","David","Damian"};

var slice = names.Skip(2).Take(2);
// "John" , "Leyla"
var slicee = names.Take(2..4);
// "John" , "Leyla"

var sliceee = names.Take(^4..4);
// "John" , "Leyla"
// .Net 6 ile Take metotuna aralık ekleyebilme ve index operatörünü kabul etme özellikleri eklendi
Console.ReadKey();