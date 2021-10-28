using System;
using System.Collections.Generic;
using System.Linq;

var firstSet = new[] {"Nick Mike"};
var secondSet = new[] {"John Leyla"};
var thirdSet = new[] {"David Damian"};

IEnumerable<string> names  = firstSet.Concat(secondSet).Concat(thirdSet);

if (names.TryGetNonEnumeratedCount(out var count))
{
 Console.WriteLine($"The count is {count}");
}
else
{
 Console.WriteLine("Could not get a count of names without enumerating the collection");
}
#region old

// var count = names.Count();
// var orderedName = names.OrderBy(x => x);

#endregion

Console.ReadKey();

/*
 * LINQ ile çalışırken, her zaman uzunluğu saymayı kolaylaştıran bir Liste veya başka tür bir koleksiyonla çalışmazsınız. Aslında, IQueryable uygulayanlar gibi belirli koleksiyon türleri ile çalışırken, Count() yöntemini çağırmak gibi basit bir işlem bile tüm sorgunun yeniden değerlendirilmesine neden olabilir.

Bununla mücadele etmek için .NET 6, çok özel TryGetNonEnumeratedCount yöntemini ekledi. Bu yöntem, koleksiyondaki öğelerin sayısının belirlenmesinin koleksiyonun numaralandırılmasına neden olup olmayacağını kontrol edecektir. Olmazsa, sayı üretilir ve bir out parametresinde saklanır ve yöntemden bir true değeri döndürülür. Sayının değerlendirilmesi, koleksiyonun numaralandırılmasına neden olacaksa, yöntem bunun yerine yalnızca false döndürür ve out parametresini 0'da bırakır.
 */