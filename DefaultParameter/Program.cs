/*Basitçe söylemek gerekirse, bu yöntemler bir koleksiyona bakar ve bir koşul karşılanırsa bir eşleşme döndürür.
 Bir koşul karşılanmazsa, o tür için varsayılan değer kullanılır. 
 Null olacak başvuru türleri için sayısal türler 0, booleanlar ise false.*/
 
Name name = names.FirstOrDefault(m => m.Cast.Includes("Muro Abcd"));
/* Eğer herhangi bir name bulamazsa FirstOrDefault metotu varsayılan değeri ile gider.
ve name null olarak set edilecektir.Ancak, .NET 6'da LINQ artık koşulla hiçbir şeyin 
eşleşmemesi durumunda kullanılacak özel bir parametre belirlemeye olanak tanır.
Bu, boş değerlerle uğraşmaktan kaçınılabilinir ve bunun yerine güvenli bir 
alternatif belirtilebilinir.*/
 
 
Name defaultValue = names.First();

Name name = names.FirstOrDefault(m => m.Cast.Includes("Muro Abcd"), defaultValue);
/*Bu durumda, FirstOrDefault bir eşleşme sağlamadığında defaultValue parametresini kullanır.
Bu değişiklik, artık özel bir defaultValue parametresi belirtebildiğiniz
benzer şekillerde SingleOrDefault ve LastOrDefault için de geçerlidir.*/