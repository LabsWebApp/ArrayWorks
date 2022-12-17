namespace ArraySorts;

/*
 * Сортировка вставками (insertion sort) - это алгоритм сортировки,
 * в котором все элементы массива просматриваются поочередно,
 * при этом каждый элемент размещается в соответственное место
 * среди ранее упорядоченных значений.
 *
 * Алгоритм работы сортировки вставками заключается в следующем:
 *  - в начале работы упорядоченная часть пуста;
 *  - добавляем в отсортированную область первый элемент массива
 *      из неупорядоченных данных;
 *  - переходим к следующему элементу в не отсортированных данных,
 *      и находим ему правильную позицию в отсортированной части массива,
 *      тем самым мы расширяем область упорядоченных данных;
 *  - повторяем предыдущий шаг для всех оставшихся элементов.
 */
public static partial class SortExtensions
{
    //сортировка вставками
    private static TNumber[] InsertionSortBase<TNumber>(TNumber[] array, bool desc)
        where TNumber : INumber<TNumber>
    {
        var greater = Greater<TNumber>(desc);
        for (var i = 1; i < array.Length; i++)
        {
            var j = i;

            while (j > 0 && greater(array[j - 1], array[j]))
            {
                array.Swap(j - 1, j);
                --j;
            }
        }
        return array;
    }

    /// <summary>
    /// сортировка вставками, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный входящий массив</returns>
    public static TNumber[] InsertionSort<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => InsertionSortBase(array, false);

    /// <summary>
    /// сортировка вставками по убыванию, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный по убыванию входящий массив</returns>
    public static TNumber[] InsertionSortDesc<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => InsertionSortBase(array, true);
}