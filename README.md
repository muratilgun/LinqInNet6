# Bu çalışmayla beraber bahsedilmesi gereken konular 

___________________________________



## 1️⃣ Chunk

<img style="float: left;" src="https://i.ibb.co/84fBYFw/1568721916752.jpg">**IEnumerable'ı belirtilen boyuttaki parçalara böler.** Ek bilgi =

**IEnumerable,** generic olamayan bir koleksiyon üzerinde iterasyon(liste içerisinde dönmemizi) yapmamızı sağlar. Aslında daha çok **memory(bellek)** üzerinde muhafıza edilen veriler üzerinden gerekli sorgulama işlemleri yapar. **System.Collection** üzerinden gelir. **IEnumerable** sınıfı içerisinde sadece **GetEnumerator** metodu bulundurmaktadır. **GetEnumerator** metodu bir koleksiyon dizi içerinden iterasyon yapmamızı sağlayarak  geriye **IEnumerator** tipinde bir sınıf döndürmektedir. Aslında çok kullandığımız **foreach** döngüsü **IEnumrable** sınıfı üzerinden **GetEnumerator** işlenerek çalışmaktadır.

```C#
var chunked = ChunkBy(names, 3);

IEnumerable<IEnumerable<T>> ChunkBy<T>(IEnumerable<T> source, int chunkSize)
{
   return source
         .Select((x, i) => new { Index = i, Value = x })
         .GroupBy(x => x.Index / chunkSize)
         .Select(x => x.Select(v => v.Value));
}

```

Yukarıdaki kod bloğu yerine .Net6 ile gelen Chunk metotu => 

```c#
var chunked = names.Chunk(3);
```

________________________________________________________________

## :two:DefaultParameter

 <img style="float: left;" src="https://i.ibb.co/b78MZQm/2302.jpg"> **.Net 6**  ile birlikte **FirstOrDefault**, **SingleOrDefault**  ve **LastOrDefault** metotları için varsayılan değer atama işlemlerini  yapabiliyoruz. Yani basitçe söylemek gerekirse, bu yöntemler bir koleksiyona bakar ve bir koşul karşılanırsa bir eşleşme döndürür.
Bir koşul karşılanmazsa, o tür için varsayılan değer kullanılır. 
**Null** olacak başvuru türleri için sayısal türler `0`, booleanlar ise `false`.





```c#
Name name = names.FirstOrDefault(m => m.Cast.Includes("Muro Abcd"));
```

 Eğer herhangi bir name bulamazsa **FirstOrDefault** metodu varsayılan değeri ile gider. Ve name `null` olarak set edilecektir. Ancak, **.NET 6**'da **LINQ** artık koşulla hiçbir şeyin eşleşmemesi durumunda kullanılacak özel bir parametre belirlemeye olanak tanır.
Bu, boş değerlerle uğraşmaktan kaçınabiliriz ve bunun yerine güvenli bir alternatif belirtebiliriz.

```c#
Name defaultValue = names.First();
Name name = names.FirstOrDefault(m => m.Cast.Includes("Muro Abcd"), defaultValue);
```

Bu durumda, **FirstOrDefault** bir eşleşme sağlamadığında `defaultValue` parametresini kullanır.
Bu değişiklik, artık özel bir `defaultValue` parametresi belirtebildiğiniz benzer şekillerde **SingleOrDefault** ve **LastOrDefault** için de geçerlidir.

_____________________________________________________________________________________________________________

## :three: ElementAtAcceptsIndex

<img style="float: left;"  src="https://i.ibb.co/QFMQ3F6/2302.jpg" alt="2302" border="0"> **ElementAt** anahtar sözcüğü ile dizide bulunan verilerin index numarasına göre tek eleman döner. `C# 8.0` ve sonraki sürümlerde mevcut olan `^` operatörü, bir dizinin sonundan öğe konumunu belirtir. Önceden, bir koleksiyonun sonundan bir şey elde etmek istiyorsanız, koleksiyonun uzunluğunu hesaplamanız ve ardından öğeyi bu dizine göre çıkarmanız ve gerektiğinde çıkarmanız gerekiyordu.





```c#
 Movie lastMovie = movies.ElementAt(movies.Count() - 1);
 Movie lastMovie = movies.ElementAt(^1);
```

Yada

```csharp
var thirdItemFromTheEnd = names.ElementAt(^3);
```

### **:a: System.Index**

Dizi ve koleksiyon yapılarındaki index kavramının static tip olarak belirlenmiş halidir. Temelde index değerini tutmakla beraber **^** operatörüyle birlikte daha fazla bir anlam ifade etmekte ve dizinin index değerlerini tersine ifade edecek şekilde bir sorumluluk yüklenmektedir.

### :b:System.Range

Koleksiyonel veri üzerinde hangi değerler ile çalışacağımızı belirleyebilmek için index üzerinden aralık vermemizi ve bu bağıntıyı **..** operatörü ile gerçekleştirmemizi sağlayan yapılanmanın kendine özgü türü Range yapısıdır.

### :ab:  **^ Operatörü**

Koleksiyonel yapılarda index değerinin tersini ifade eder. Normal index yapılanmasına nazaran ters index durumu 0’dan değil, 1’den başlamaktadır. Yani 10 elemanlı bir dizide; sonuncu eleman 9. indexe sahiptir lakin tersine operatörüyle ~~“^0”~~ değil “^1” değerine tekabül etmektedir.

### :cl: .. Operatörü

Koleksiyonel verilerde belirli aralığı temsil eden operatördür. Aralık operatörü diyede isimlendirebiliriz. Genellikle indexer[ ] operatörü içerisinde indexsel aralığı belirlemek için kullanılır.

_______________________________

## :four: MaxByAndMinBy

<img style="float: left;" src="https://i.ibb.co/pdw2xnm/2302.jpg">**NET 6**, .NET geliştiricilerine MinBy ve MaxBy ek metotları getirdi. Bu iki yöntem, koleksiyonunuza bakmanıza ve en büyüğünü veya en küçüğünü bulmanızı sağlar.

.NET 6'dan önce, bir şeyin en büyüğüne veya en küçüğüne sahip olan varlığı elde etmek için değeri bulmak için Maks veya Min'i kullanmanız, ardından ilgili varlığı bulmak için tekrar sorgulamanız gerekiyordu.





```csharp
int numBattles = movies.Max(m => m.NumSpaceBattles);
Movie mostAction = movies.First(m => m.NumSpaceBattles == numBattles);
```

Yukarıdaki kod bloğu kullanılabilinir. Ancak 1 yerine 2 satır kod alıyor ve koleksiyonu birkaç kez numaralandırıyor.

.NET 6'nın MinBy ve MaxBy LINQ ek metotlarıyla artık bunu tek bir kod satırında daha hızlı yapabiliriz:

```csharp
Movie mostAction = movies.MaxBy(m => m.NumSpaceBattles);
```

Yada MaxByAndMinBy projesinde yazdığım en yaşlı ve en geci bulma operasyonları diğer kullanım örnekleridir.

Ek bilgi => Projede yer alan diğer bir başlık 

### :a: Encapsulation  

```c#
public classDemoEncap {
   // private variables declared
   // these can only be accessed by
   // public methods of class
   private String studentName;
   private int studentAge;
      
   // using accessors to get and 
   // set the value of studentName
   public String Name
   {
      get { return studentName; }
      set { studentName = value;}
   }
   // using accessors to get and 
   // set the value of studentAge
   public int Age
   {
     get {return studentAge;}
     set {studentAge = value;}
   }
}
```

Yukarıdaki programda, değişkenler private olarak bildirildiği için DemoEncap sınıfı kapsüllenmiştir. Bu özel değişkenlere erişmek için, özel alanların değerlerini almak ve ayarlamak için get ve set yöntemini içeren Ad ve Yaş erişimcilerini kullanıyoruz. Access modifier, diğer sınıftan erişebilmeleri için public olarak tanımlanır.

**Encapsulation  Avantajları:**

**Veri Gizleme:** Kullanıcı, sınıfın iç uygulaması hakkında hiçbir fikre sahip olmayacaktır. Değişkenlerde sınıfın nasıl saklandığı kullanıcı tarafından görülmeyecektir. Yalnızca değerleri erişimcilere ilettiğimizi ve değişkenlerin bu değere başlatıldığını biliyor.
**Arttırılmış Esneklik:** Sınıfın değişkenlerini ihtiyacımıza göre salt okunur veya salt yazılır olarak yapabiliriz. Değişkenleri salt okunur yapmak istiyorsak, kodda yalnızca Get Accessor kullanmamız gerekir. Değişkenleri salt yazılır yapmak istiyorsak, yalnızca Set Accessor kullanmamız gerekir.
**Yeniden Kullanılabilirlik:** Kapsülleme aynı zamanda yeniden kullanılabilirliği artırır ve yeni gereksinimlerle kolayca değiştirilebilir.
Kodu test etmek kolaydır: Kapsüllenmiş kodun birim testi için test edilmesi kolaydır.

### :b: Object and Collection Initializers  - Nesne ve Koleksiyon Başlatıcıları

Nesne başlatıcıları, oluşturma zamanında ardından atama deyimleri satırları gelecek şekilde bir oluşturucu çağırmak zorunda kalmadan, bir nesnenin istediğiniz erişilebilir alanlarına veya özelliklerine değerler atamanıza olanak tanır. Nesne başlatıcı sözdizimi, bir oluşturucu için bağımsız değişkenler belirtmenize veya bağımsız değişkenleri (ve parantez sözdizimini) atmanıza olanak tanır.

Aşağıdaki örnek, adlandırılmış bir tür ile nesne başlatıcının nasıl kullanılacağını ve `Cat` parametresiz oluşturucu çağırmayı gösterir. `Cat` sınıfında otomatik uygulanan özelliklerin kullanımına dikkat  edin. 

```csharp
public class Cat
{
    // Auto-implemented properties.
    public int Age { get; set; }
    public string Name { get; set; }

    public Cat()
    {
    }
    
    public Cat(string name)
    {
        this.Name = name;
    }

}
```

```c#
Cat cat = new Cat { Age = 10, Name = "Fluffy" };
Cat sameCat = new Cat("Fluffy"){ Age = 10 };
```

Nesne başlatıcıları söz dizimi bir örnek oluşturmanıza olanak sağlar ve bundan sonra yeni oluşturulan nesneyi atamada değişkene atanmış özellikleriyle atar.

### :ab: Anonim türlerde Nesne Başlatıcıları

Nesne başlatıcıları herhangi bir bağlamda kullanılabilir, ancak linq sorgu ifadelerinde özellikle yararlıdır. Sorgu ifadeleri, aşağıdaki bildirimde gösterildiği gibi yalnızca bir nesne başlatıcı kullanılarak başlatılmış olan anonim türleri sık kullanır.

```c#
var pet = new { Age = 10, Name = "Fluffy" };
```



______________________

## :five:Take Accept Range/Index

<img style="float: left;" src="https://i.ibb.co/rwVLWRS/Ads-z.jpg">.Net 6 ile gelen diğer bir özellik ise  take metodunun index ve range operatörlerini kabul etmesi oldu. Örnek çalışma da görüldüğü üzere işleri kolaylaştıran diğer bir ek özellik olmuş.







```c#
var slice = names.Skip(2).Take(2);
// "John" , "Leyla"
var slicee = names.Take(2..4);
// "John" , "Leyla"
var sliceee = names.Take(^4..4);
// "John" , "Leyla"
```

__________________



## :six: TryGetNonEnumeratedCount

<img style="float: left;" src="https://i.ibb.co/Tbcpvw6/Ads-z.jpg" alt="Ads-z" border="0"> **LINQ** ile çalışırken, her zaman uzunluğu saymayı kolaylaştıran bir Liste veya başka tür bir koleksiyonla çalışmazsınız. Aslında, **IQueryable** uygulayanlar gibi belirli koleksiyon türleri ile çalışırken, **Count()** yöntemini çağırmak gibi basit bir işlem bile tüm sorgunun yeniden değerlendirilmesine neden olabilir.Bununla mücadele etmek için **.NET 6**, çok özel **TryGetNonEnumeratedCount** yöntemini ekledi. Bu yöntem, koleksiyondaki öğelerin sayısının belirlenmesinin koleksiyonun numaralandırılmasına neden olup olmayacağını kontrol edecektir. Olmazsa, sayı üretilir ve bir `out` parametresinde saklanır ve yöntemden bir true değeri döndürülür. Sayının değerlendirilmesi, koleksiyonun numaralandırılmasına neden olacaksa, yöntem bunun yerine yalnızca `false` döndürür ve `out` parametresini 0'da bırakır. 

___________________

## **:seven: Zip**

<img style="float: left;" src="https://i.ibb.co/Pr63r2y/Ads-z.jpg">**3 Parameter Zip Overload**

Daha önce LINQ, .NET geliştiricilerine iki koleksiyon arasında paralel olarak numaralandırmalarına izin verecek bir Zip yöntemi sunmuştu. Bu geliştiricilerin çeşitli koleksiyonlar arasında geçiş yapmak için zahmetsiz ve yeniden adlandırılmış türler oluşturmasını engelledi. Ancak, üç koleksiyonu birlikte sıralamak isteyebileceğiniz bazı durumlar vardı ve bu özellikte .Net 6 ile getirildi.



```c#
var names = new[] {"Nick Mike","John Leyla","David Damian"};
var ages = new[] { 28, 22, 25 };
var yearsOfExprerience = new[] { 10, 5, 2 };

// var zip = names.Zip(ages);
IEnumerable<(string Name, int Age, int yearsOfExp)> zip = names.Zip(ages, yearsOfExprerience);
```

_____

## SON OLARAK EKLEMEK İSTEDİĞİM EK BİLGİLER  :label:

:question::question: **NULL COALESCING OPERATOR**

```csharp
FormsAuth = formsAuth ?? new FormsAuthenticationWrapper();
```

```csharp
if(formsAuth != null)
    FormsAuth = formsAuth;
else
    FormsAuth = new FormsAuthenticationWrapper();
```

***Soldaki değer*** `null`  ***değilse, onu kullan, yoksa sağdaki olanı  kullan*** anlamına gelir.

Bu operatör arka arkaya(overload) olacak şekilde kullanabilir. Aşağıdaki ifade, boş olmayan ilk `Answer` i geçip ikinci `Answer` e atayacaktır.  (tüm Cevaplar null ise o zaman `Answer` `null` olur)

```csharp
string Answer = Answer1 ?? Answer2 ?? Answer3 ?? Answer4;
```

 :red_circle: Null coalescing operator için bir örnek daha vericek olursam 

```csharp
return ifNotNullValue ?? otherwiseValue;
```

yada kısaca

```c#
return ifNotNullValue != null ? ifNotNullValue : otherwiseValue;
```

### **:question::question:=  NULL - COALESCING ASSIGMENT**

Null-coalescing atama operatörü ( **??=** )  operatörü . Bu operatör, yalnızca sol işlenenin değeri boşsa, sağ (operand)işlenenin değerini sol işlenene atamak için kullanılır. Sol işlenen boş olmayan olarak değerlendirilirse, bu operatör sağ işleneni değerlendirmez.

```c#
p ??= q
```

P, ??= operatörünün sol ve q sağ işlenenidir. p değeri null ise, ??= operatörü p'deki q değerini atar. Veya p'nin değeri boş değilse, o zaman q'yu değerlendirmez.

**Önemli noktalar:**

- ??= operatörünün sol işleneni bir değer, bir property veya indexer element öğesi olmalıdır.
- sağ işlenen ile bağlantılı olmalıdır.
- bu operator overload edilemez.
- **referans**(class, array, string,delegate, record.. ) veya **değer**(bool, byte, char, decimal, double, enum, float, int) türleri ile kullanılabilinir.

```c#
variable ??= otherwiseValue;
```

```csharp
if (variable is null) variable = otherwiseValue;
```

