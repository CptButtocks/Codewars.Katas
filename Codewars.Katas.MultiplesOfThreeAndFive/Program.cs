// See https://aka.ms/new-console-template for more information
// Kata: https://www.codewars.com/kata/514b92a657cdc65150000006/

Console.WriteLine(Solution(10));
Console.WriteLine(Solution(20));
Console.WriteLine(Solution(200));
Console.WriteLine(Solution(0));

static int Solution(int value)
{
    if (value < 0)
        return 0;

    int sum = 0;
    for (int i = 0; i < value; i++)
    {
        if (IsMultipleOfThreeOrFive(i)) sum += i;
    }

    return sum;
}

static bool IsMultipleOfThreeOrFive(int value) => IsMultipleOf(value, 3) || IsMultipleOf(value, 5);

static bool IsMultipleOf(int value, int n) => value % n == 0;

