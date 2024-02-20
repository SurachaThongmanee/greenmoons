
Random random = new Random();
int number = 1000;

do
{
    number = random.Next(0, number);
    Console.WriteLine($"show: {number}");
} while (number != 0);

