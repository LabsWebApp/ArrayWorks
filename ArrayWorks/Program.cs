using System.Numerics;
using System.Text;
// ReSharper disable ConditionIsAlwaysTrueOrFalse

static bool ArrayContains(int[] numbers, int number)
{
    foreach (var num in numbers) if (number == num) return true;
    return false;
}
static int[] UniqueRandomArray(int min, int max, int length, Random? random = null)
{
    if (min >= max) throw new ArgumentException("Не верно задан диапазон: min >= max");
    if ((max - min) < length) throw new ArgumentException("Диапазон не позволяет создать уникальный список: (max - min) <= length");

    random = random ?? new Random(DateTime.Now.Microsecond);
    var result = new int[length];
    var zeroFirst = true;
    for (var i = 0; i < length; i++)
    {
        var res = 0;
        do
        {
            res = random.Next(min, max);
            if (res == 0)
            {
                if (zeroFirst)
                {
                    zeroFirst = false;
                    break;
                }
                continue;
            }
        } while (ArrayContains(result, res));
        result[i] = res;
    }
    return result;
}

static void PrintArray(int[] numbers)
{
    var sb = new StringBuilder();
    foreach (var item in numbers) sb.Append(item).Append(' ');
    var result = sb.ToString().TrimEnd(' ');
    Console.WriteLine(result);
}

static void SwapMinMax(int[] numbers)
{
    int aForMin = 0, aForMax = 0;
    int bForMin = numbers.Length - 1, bForMax = bForMin;
    while (aForMax != bForMax)
    {
        if (numbers[aForMax] > numbers[bForMax]) bForMax--;
        else aForMax++;
        if (numbers[aForMin] < numbers[bForMin]) bForMin--;
        else aForMin++;
    }

    numbers[aForMax] ^= numbers[aForMin]; // a = a + b
    numbers[aForMin] ^= numbers[aForMax]; // b = a - b
    numbers[aForMax] ^= numbers[aForMin]; // a = a - b
}

static void SwapMinMaxGeneric<T>(IList<T> numbers) where T : INumber<T>
{
    int aForMin = 0, aForMax = 0;
    int bForMin = numbers.Count - 1, bForMax = bForMin;
    while (aForMax != bForMax)
    {
        if (numbers[aForMax] > numbers[bForMax]) bForMax--;
        else aForMax++;
        if (numbers[aForMin] < numbers[bForMin]) bForMin--;
        else aForMin++;
    }

    (numbers[aForMin], numbers[aForMax]) = (numbers[aForMax], numbers[aForMin]);
}

var array = UniqueRandomArray(-10, 50, 10);
PrintArray(array);
SwapMinMax(array);
PrintArray(array);

Console.WriteLine();

array = UniqueRandomArray(-10, 50, 10);
PrintArray(array);
SwapMinMaxGeneric(array);
PrintArray(array);

Console.ReadKey();

// БОНУС - Флаги
const BuildingOptions building = 
    BuildingOptions.Panel | BuildingOptions.Multistory | BuildingOptions.HasElevator;


Console.WriteLine($"\nBrick is our option = {(building & BuildingOptions.Brick) != 0}");
Console.WriteLine($"Panel is our option = {(building & BuildingOptions.Panel) != 0}");
Console.WriteLine($"Wooden is our option = {(building & BuildingOptions.Wooden) != 0}");
Console.WriteLine($"Multistory is our option = {(building & BuildingOptions.Multistory) != 0}");
Console.WriteLine($"HasElevator is our option = {(building & BuildingOptions.HasElevator) != 0}");

Console.WriteLine($"\nbuilding = {building} ({(int)building} - {IntTo2((int)building)})");
Console.WriteLine($"Brick = {(int)BuildingOptions.Brick} - {IntTo2((int)BuildingOptions.Brick)}");
Console.WriteLine($"Panel = {(int)BuildingOptions.Panel} - {IntTo2((int)BuildingOptions.Panel)}");
Console.WriteLine($"Wooden = {(int)BuildingOptions.Wooden} - {IntTo2((int)BuildingOptions.Wooden)}");
Console.WriteLine($"Multistory = {(int)BuildingOptions.Multistory} - {IntTo2((int)BuildingOptions.Multistory)}");
Console.WriteLine($"HasElevator = {(int)BuildingOptions.HasElevator} - {IntTo2((int)BuildingOptions.HasElevator)}");

Console.WriteLine(52 & 2);
Console.WriteLine(52 & 4);
Console.WriteLine(52 & 8);
Console.WriteLine(52 & 16);
Console.WriteLine(52 & 32);

Console.ReadKey();

string IntTo2(int number) => number == 1 ? "1" : IntTo2(number / 2) + number % 2;

[Flags]
internal enum BuildingOptions
{
    Brick = 2, Panel = 4, Wooden = 8, Multistory = 16, HasElevator = 32
}