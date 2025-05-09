ProcessString processString1 = TrimTo5Letters;
ProcessString processString2 = ToUpper;

Console.WriteLine(processString1("Hellooooooooooooo"));
Console.WriteLine(processString2("Hellooooooooooooo"));

Console.WriteLine();

Print print1 = text => Console.WriteLine(text.ToUpper());
Print print2 = text => Console.WriteLine(text.ToLower());
Print multicast = print1 + print2;
Print print4 = text => Console.WriteLine(text.Substring(0, 3));
multicast += print4;
multicast("Crocodile");

// assigning to a Func with a lambda expression
Func<string, string, int> sumLengths1 =
    (text1, text2) => text1.Length + text2.Length;

// assigning to a Func with a predefined method
Func<string, string, int> sumLengths2 = SumLengths;

Console.ReadKey();

int SumLengths(string text1, string text2)
{
    return text1.Length + text2.Length;
}

string TrimTo5Letters(string input)
{
    return input.Substring(0, 5);
}

string ToUpper(string input)
{
    return input.ToUpper();
}

delegate string ProcessString(string input);

delegate void Print(string input);