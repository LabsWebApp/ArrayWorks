namespace ArrayOperations;

/// <summary>
/// Расширения для массивов/списков, которые могут помочь в решении задач с массивами
/// </summary>
public static class HelperExtension
{
    /// <summary>
    /// Меняет местами два элемента в списке
    /// </summary>
    /// <typeparam name="T">тип элементов</typeparam>
    /// <param name="list">список, в к-ом нужно поменять элементы</param>
    /// <param name="i">индекс первого элемента</param>
    /// <param name="j">индекс второго элемента</param>
    public static void Swap<T>(this IList<T> list, int i, int j) =>
        (list[i], list[j]) = (list[j], list[i]);

    /// <summary>
    /// метод для проверки упорядоченности списка по возрастанию
    /// </summary>
    /// <typeparam name="TNumber">тип числа</typeparam>
    /// <param name="array">входящий список</param>
    /// <returns>true, если список упорядочен</returns>
    public static bool IsSorted<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber>
    {
        for (var i = 0; i < array.Length - 1; i++) 
            if (array[i] > array[i + 1]) 
                return false;
        return true;
    }

    /// <summary>
    /// метод для проверки упорядоченности списка по убыванию
    /// </summary>
    /// <typeparam name="TNumber">тип числа</typeparam>
    /// <param name="array">входящий список</param>
    /// <returns>true, если список упорядочен</returns>
    public static bool IsSortedDesc<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber>
    {
        for (var i = 0; i < array.Length - 1; i++) 
            if (array[i] < array[i + 1]) 
                return false;
        return true;
    }

    /// <summary>
    /// Находит индекс последнего максимального и первого минимального элемента в списке чисел 
    /// </summary>
    /// <typeparam name="TNumber">численный тип элементов в списке</typeparam>
    /// <param name="numbers">список, в котором требуется найти максимальный и минимальный элемент</param>
    /// <returns>Кортеж из двух чисел - первое это индекс минимального элемента, второе - максимального</returns>
    public static ValueTuple<int, int> MinMax<TNumber>(this IList<TNumber> numbers) 
        where TNumber : INumber<TNumber>
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

        return (aForMin, aForMax);
        // Как менять местами:
        //numbers[aForMax] ^= numbers[aForMin]; // a = a + b
        //numbers[aForMin] ^= numbers[aForMax]; // b = a - b
        //numbers[aForMax] ^= numbers[aForMin]; // a = a - b
    }

    /// <summary>
    /// Находит максимальное минимальное число в списке чисел 
    /// </summary>
    /// <typeparam name="TNumber">численный тип элементов в списке</typeparam>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public static ValueTuple<TNumber, TNumber> MinMaxValues<TNumber>(this IList<TNumber> numbers)
        where TNumber : INumber<TNumber>
    {
        var minMax = numbers.MinMax();
        return (numbers[minMax.Item1], numbers[minMax.Item2]);
    }

    /// <summary>
    /// Меняет местами максимальный и минимальный элемент в списке
    /// </summary>
    /// <typeparam name="TNumber">численный тип элементов в списке</typeparam>
    /// <param name="numbers">входящий список</param>
    public static void MinMaxSwap<TNumber>(this IList<TNumber> numbers) 
        where TNumber : INumber<TNumber>
    {
        var (min, max) = numbers.MinMax();

        numbers.Swap(min, max);
    }
}