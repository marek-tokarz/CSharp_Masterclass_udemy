using System.Linq.Expressions;

var numbers = new List<int> { 5, 1, 7, 2 };
numbers.Sort();

var words = new List<string> { "ddd", "aaa", "ccc", "bbb" };
words.Sort();

var people = new List<Person>
{
    new Person {Name = "John", YearOfBirth = 1980},
    new Person {Name = "Anna", YearOfBirth = 1915},
    new Person {Name = "Bill", YearOfBirth = 2011},
};

// will throw exception without IComparable<T> interface
// people.Sort();

people.Sort();

Console.ReadKey();

public class Person : IComparable<Person>
{
    public string Name { get; init; }
    public int YearOfBirth { get; init; }

    public int CompareTo(Person other)
    {
        if(this.YearOfBirth < other.YearOfBirth)
        {
            return 1;
        } 
        else if (this.YearOfBirth > other.YearOfBirth)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}

public class Employee : Person
{
    public void GoToWork() => Console.WriteLine("Going to work");
}