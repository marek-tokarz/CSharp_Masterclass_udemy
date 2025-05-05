var ints = new List<int> { 1, 2, 3 };
ints.AddToFront(10);

var decimals = new List<decimal> { 1.1m, 0.5m, 22.5m, 12m };

// now method ConvertTo() is non generic:
// var ints1 = decimals.ConvertTo();

// now ConvertTo() was changed to be a generic method
var ints1 = decimals.ConvertTo<decimal, int>();

var floats = new List<float> { 1.4f, -100.01f };
var longs = floats.ConvertTo<float, long>();

// we can create such collection, because an integer contains such public parameterless constructor
var ints2 = CreateCollectionOfRandomLength<int>(100);
var dates = CreateCollectionOfRandomLength<DateTime>(100);

// Type constraints limit the types that can be used as the generic parameter
// to some specific group that must meet certain criteria
IEnumerable<T> CreateCollectionOfRandomLength<T>(int maxLength) where T: new()
{                                                               // this will accept
    var length = new Random().Next(maxLength + 1);              // a public
                                                                // parameterless
    var result = new List<T>();                                 // constructor

    for(int i = 0; i < length; i++)
    {
        result.Add(new T());
    }

    return result;
}

Console.ReadKey();

static class ListExtensions
{
    public static void AddToFront<T>(this List<T> list, T item)
    {
        list.Insert(0, item);
    }

    public static List<TTarget> ConvertTo<TSource, TTarget>(this List<TSource> input)
    {
        var result = new List<TTarget>();

        foreach(var item in input)
        {
            TTarget itemAfterCasting = (TTarget)Convert.ChangeType(item, typeof(TTarget));
            result.Add(itemAfterCasting);
        }

        return result;
    }
}
