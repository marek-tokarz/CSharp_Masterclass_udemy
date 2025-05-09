var numbers = new[] { 1, 4, 7, 19, 2 };

// Func<int, bool> predicate1 = IsLargerThan10;
//Console.WriteLine(
//    "IsAnyLargerThan10? " + IsAny(numbers, predicate1));

// we can pass directly a methods (we do not need a variables)
Console.WriteLine(
    "IsAnyLargerThan10? " + IsAny(numbers, n => n > 10));

// Func<int, bool> predicate2 = IsEven;
//Console.WriteLine(
//   "IsAnyEven " + IsAny(numbers, predicate2));

// we can pass directly a methods (we do not need a variables)
Console.WriteLine(
    "IsAnyEven " + IsAny(numbers, n => n % 2 == 0));

Console.ReadKey();

Func<int, DateTime, string, decimal> someFunc;
// takes: int, DateTime, string and returns decimal

Action<string, string, bool> someAction;
// takes: string, string, bool and returns void (a void function)


// not needed after implementing a lambda functions
/*
bool IsLargerThan10(int number)
{
    return number > 10;
}

bool IsEven(int number)
{
    return number % 2 == 0;
}
*/


bool IsAny(
    IEnumerable<int> numbers,
    Func<int,bool> predicate)
{
    foreach (var number in numbers)
    {
        if (predicate(number))
        {
            return true;
        }
    }
    return false;
}

// not needed after refactor
/*
bool IsAnyLargerThan10(
    IEnumerable<int> numbers)
{
    foreach(var number in numbers)
    {
        if(number > 10)
        {
            return true;
        }
    }
    return false;
}

bool IsAnyEven(IEnumerable<int> numbers)
{
    foreach (var number in numbers)
    {
        if (number % 2 == 0)
        {
            return true;
        }
    }
    return false;
}
*/