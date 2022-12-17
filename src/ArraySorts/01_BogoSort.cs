namespace ArraySorts;

/*
 * Случайная сортировка (Bogosort) – один из самых неэффективных алгоритмов сортировки массивов.
 *
 * Алгоритм случайной сортировки заключается в следующем:
 *  - вначале массив проверяется на упорядоченность,
 *  - если элементы не отсортированы, то перемешиваем их случайным образом и
 *      снова проверяем,
 *  - операции повторяются до тех пор, пока массив не будет отсортирован.
 */
public static partial class SortExtensions
{
    //перемешивание элементов массива
    private static void RandomPermutation<TNumber>(this TNumber[] array)
    {
        var n = array.Length;
        while (n > 1)
        {
            var i = Rand.Next(--n + 1);
            array.Swap(i, n);
        }
    }

    /// <summary>
    /// случайная сортировка, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный входящий массив</returns>
    public static int[] BogoSort(this int[] array)
    {
        while (!array.IsSorted()) array.RandomPermutation();
        return array;
    }

    /// <summary>
    /// случайная сортировка по убыванию, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный по убыванию входящий массив</returns>
    public static int[] BogoSortDesc<TNumber>(this int[] array)
    {
        while (!array.IsSortedDesc()) array.RandomPermutation();
        return array;
    }
}