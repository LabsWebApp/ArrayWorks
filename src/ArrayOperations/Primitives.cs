using System.Numerics;
using System.Text;

namespace ArrayOperations;

public static class Primitives
{  
    public static bool ArrayContains(this int[] numbers, int number)
    {
        foreach (var num in numbers) if (number == num) return true;
        return false;
    }

    public static int[] RandomArray(int min, int max, int length, Random? random = null)
    {
        if (min >= max) throw new ArgumentException("Не верно задан диапазон: min >= max");
        
        random ??= new Random(DateTime.Now.Microsecond);
        var result = new int[length];
        for (var i = 0; i < length; i++) result[i] = random.Next(min, max);
        return result;
    }

    public static int[] UniqueRandomArray(int min, int max, int length, Random? random = null)
    {
        if (min >= max) throw new ArgumentException("Не верно задан диапазон: min >= max");
        if (max - min < length) throw new ArgumentException("Диапазон не позволяет создать уникальный список: (max - min) < length");

        random = random ?? new Random(DateTime.Now.Microsecond);
        var result = new int[length];

        for (var i = 0; i < length; i++)
        {
            int res;
            do res = random.Next(min, max); while (ArrayContains(result, res));
            result[i] = res;
        }
        return result;
    }

    public static void PrintArray(this int[] numbers)
    {
        var sb = new StringBuilder();
        foreach (var item in numbers) sb.Append(item).Append(' ');
        var result = sb.ToString().TrimEnd(' ');
        Console.WriteLine(result);
    }
}