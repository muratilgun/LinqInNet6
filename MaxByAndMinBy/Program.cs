using System;
using System.Linq;

var students = new[]
{
    new Student("Niyazi Bakkal", 28),
    new Student("Recep Ivedik", 22),
    new Student("Hatice Kaynak", 24)
};
var youngest = students.MinBy(x => x.Age);
var oldest = students.MaxBy(x => x.Age);

#region old
//
// var youngest = students.OrderBy(x => x.Age).First();
// var oldest = students.OrderByDescending(x => x.Age).First();

#endregion
Console.ReadKey();
public class Student
{
    public Student(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
    public string Name { get; set; }
    public int Age { get; set; }
}
