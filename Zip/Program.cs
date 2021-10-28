using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

var names = new[] {"Nick Mike","John Leyla","David Damian"};
var ages = new[] { 28, 22, 25 };
var yearsOfExprerience = new[] { 10, 5, 2 };

// var zip = names.Zip(ages);
IEnumerable<(string Name, int Age, int yearsOfExp)> zip = names.Zip(ages, yearsOfExprerience);
Console.ReadKey(); 
/* 3 Parameter Zip Overload
 * Daha önce LINQ, .NET geliştiricilerine iki koleksiyon arasında paralel olarak numaralandırmalarına izin verecek bir Zip yöntemi sunmuştu:
 * Bu geliştiricilerin çeşitli koleksiyonlar arasında geçiş yapmak için zahmetsiz ve yeniden adlandırılmış türler oluşturmasını engelledi.
 * Ancak, üç koleksiyonu birlikte sıralamak isteyebileceğiniz bazı durumlar vardı ve bu özellikte .Net 6 ile getirildi.
 */