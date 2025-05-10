//                                            key     value 
var countryToCurrencyMapping = new Dictionary<string, string>();

// another way of initalization

var countryToCurrencyMapping1 = new Dictionary<string, string>
{  // KEY      VALUE
    ["USA"] = "USD",
    ["India"] = "INR",
    ["Spain"] = "EUR",
};

countryToCurrencyMapping.Add("USA", "USD");
countryToCurrencyMapping.Add("India", "INR");
countryToCurrencyMapping.Add("Spain", "EUR");

// countryToCurrencyMapping.Add("Italy", "EUR");

if(countryToCurrencyMapping.ContainsKey("Italy"))
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