// See https://aka.ms/new-console-template for more information

Console.WriteLine(EvenOrOdd(2));
Console.WriteLine(EvenOrOdd(1));
Console.WriteLine(EvenOrOdd(0));
Console.WriteLine(EvenOrOdd(7));
Console.WriteLine(EvenOrOdd(-1));

static string EvenOrOdd(int number)
{
    return number % 2 == 0 ? "Even" : "Odd";
}