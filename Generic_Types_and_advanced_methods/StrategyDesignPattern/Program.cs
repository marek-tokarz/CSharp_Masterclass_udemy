var numbers = new List<int> { 10, 12, -100, 55, 17, 22 };

Console.WriteLine(@"Select filter:
Even
Odd
Positive");

var userInput = Console.ReadLine();

List<int> result;
switch(userInput)
{
    case "Even":
        result = SelectEven(numbers);
        break;
    case "Odd":
        result = SelectOdd(numbers);
        break;
    case "Positive":
        result = SelectPositive(numbers);
        break;
    default:
        throw new NotSupportedException(
            $"{userInput} is not a valid filter");
}

Print(result);

Console.ReadKey();

List<int> SelectEven(List<int> numbers)
{
    var result = new List<int>();

    foreach(var number in numbers)
    {
        if(number % 2 == 0)
        {
            result.Add(number);
        }
    }

    return result;
}

List<int> SelectOdd(List<int> numbers)
{
    var result = new List<int>();

    foreach (var number in numbers)
    {
        if (number % 2 == 1)
        {
            result.Add(number);
        }
    }

    return result;
}

List<int> SelectPositive(List<int> numbers)
{
    var result = new List<int>();

    foreach (var number in numbers)
    {
        if (number > 0)
        {
            result.Add(number);
        }
    }

    return result;
}

void Print(IEnumerable<int> numbers)
{
    Console.WriteLine(string.Join(", ", numbers));
}