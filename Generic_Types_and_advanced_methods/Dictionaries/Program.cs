//                                            key     value 
var countryToCurrencyMapping = new Dictionary<string, string>();

// another way of initalization

/*
 * Refacotr in order to keep a few strings for one string 
 * (few acceptable currencies for one country)
var countryToCurrencyMapping1 = new Dictionary<string, string>
{  // KEY      VALUE
    ["USA"] = "USD",
    ["India"] = "INR",
    ["Spain"] = "EUR",
};

countryToCurrencyMapping.Add("USA", "USD");
countryToCurrencyMapping.Add("India", "INR");
countryToCurrencyMapping.Add("Spain", "EUR");

*/

var countryToCurrencyMapping1 = new Dictionary<string, List<string>>();

countryToCurrencyMapping1.Add("USA", new List<string> { "USD" });
countryToCurrencyMapping1.Add("India", new List<string> { "INR" });
countryToCurrencyMapping1.Add("Spain", new List<string> { "EUR" });

// Add another currency for USA
countryToCurrencyMapping1["USA"].Add("Dollar");

// countryToCurrencyMapping.Add("Italy", "EUR");

if (countryToCurrencyMapping.ContainsKey("Italy"))
{
    Console.WriteLine("Currency in Italy is " +
    countryToCurrencyMapping["Italy"]);
}

Console.WriteLine("Currency in Spain is " +
    countryToCurrencyMapping["Spain"]);

countryToCurrencyMapping["Poland"] = "PLN";
countryToCurrencyMapping["Poland"] = "EUR";

Console.WriteLine("Currency in Poland is " +
    countryToCurrencyMapping["Poland"]);

// EACH KEY IN DICTIONARY MUST BE UNIQUE
// countryToCurrencyMapping.Add("Spain", "ESP");

Console.WriteLine();

// Printing keys and values of a dictionary with a loop

foreach(var countryCurrencyPair in countryToCurrencyMapping)
{
    Console.WriteLine(
        $"Country: {countryCurrencyPair.Key}, " +
        $"currency: {countryCurrencyPair.Value}");
}

Console.ReadKey();