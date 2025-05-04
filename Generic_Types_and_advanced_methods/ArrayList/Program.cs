using System.Collections;

ArrayList ints = new ArrayList { 2, 3, 4, 5 };

int sum = 0;
foreach(object number in ints)
{
    sum += (int)number;
}
// above code causes problems with casting, also has a poor performance
// due to a 'boxing' concept - casting a variable to an object type
// this is not a case when we use List with a specific type:

List<int> ints1 = new List<int> { 2, 3, 4, 5 };

int sum1 = 0;
foreach (int number in ints)
{
    sum1 += number;
}

ArrayList strings = new ArrayList { "a", "b", "c" };

ArrayList variousItems = new ArrayList { 1, false, "abc", new DateTime() };
object[] objects = new object[] { 1, false, "abc", new DateTime() };

Console.ReadKey();