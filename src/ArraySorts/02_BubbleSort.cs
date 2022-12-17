namespace ArraySorts;

/*
 * Сортировка пузырьком (bubble sort) - один из самых простых для понимания методов сортировки массивов.
 *
 * Алгоритм заключается в циклических проходах по массиву,
 * за каждый проход элементы массива попарно сравниваются и,
 * если их порядок не правильный, то осуществляется обмен.
 * Обход массива повторяется до тех пор, пока массив не будет упорядочен.
 */
public static partial class SortExtensions
{
    //сортировка пузырьком
    private static TNumber[] BubbleSortBase<TNumber>(TNumber[] array , bool desc)
        where TNumber : INumber<TNumber>
    {
        var greater = Greater<TNumber>(desc);
        var len = array.Length;
        for (var i = 1; i < len; i++)
            for (var j = 0; j < len - i; j++) 
                if (greater(array[j], array[j + 1])) 
                    array.Swap(j, j + 1);
        return array;
    }

    /// <summary>
    /// сортировка пузырьком, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный входящий массив</returns>
    public static TNumber[] BubbleSort<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => BubbleSortBase(array, false);

    /// <summary>
    /// сортировка пузырьком по убыванию, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный по убыванию входящий массив</returns>
    public static TNumber[] BubbleSortDesc<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => BubbleSortBase(array, true);
}