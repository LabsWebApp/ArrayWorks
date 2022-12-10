using System.Numerics;

namespace ArrayOperations;

public static class HelperExtension
{
    //public static void Swap(this int[] array, int i, int j) =>
    //    (array[i], array[j]) = (array[j], array[i]);

    public static void Swap<T>(this IList<T> list, int i, int j) =>
        (list[i], list[j]) = (list[j], list[i]);

    //метод для проверки упорядоченности массива
    public static bool IsSorted(this int[] array)
    {
        for (var i = 0; i < array.Length - 1; i++) 
            if (array[i] > array[i + 1]) 
                return false;
        return true;
    }

    public static void SwapMinMax(this int[] numbers)
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

        numbers.Swap(aForMin, aForMax);
        //numbers[aForMax] ^= numbers[aForMin]; // a = a + b
        //numbers[aForMin] ^= numbers[aForMax]; // b = a - b
        //numbers[aForMax] ^= numbers[aForMin]; // a = a - b
    }

    public static void SwapMinMaxGeneric<T>(this IList<T> numbers) where T : INumber<T>
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

        numbers.Swap(aForMin, aForMax);
    }

    public static string IntTo2(this int number) =>
        number == 1 ? "1" : IntTo2(number / 2) + number % 2;
}