var numbers = new List<int> { 5, 3, 2, 8, 16, 7 };
SimpleTuple<int, int> minAndMax = GetMinAndMax(numbers);
Console.WriteLine("Smallest number is " + minAndMax.Item1);
Console.WriteLine("Largest number is " + minAndMax.Item2);

Console.ReadKey();

SimpleTuple<int, int> GetMinAndMax(IEnumerable<int> input)
{
    if(!input.Any())
    {
        throw new InvalidOperationException(
            $"The input collection cannot be empty.");
    }

    int min = input.First();
    int max = input.First();

    foreach(var number in input)
    {
        if(number < min)
        {
            min = number;
        }

        if(number > max)
        {
            max = number;
        }
    }

    return new SimpleTuple<int, int>(min, max);
}

public class SimpleTuple<T1, T2>
{
    public SimpleTuple(T1 item1, T2 item2)
    {
        Item1 = item1;
        Item2 = item2;
    }

    public T1 Item1 { get; }
    public T2 Item2 { get; }
}