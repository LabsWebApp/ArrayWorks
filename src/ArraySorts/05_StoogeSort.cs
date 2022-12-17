namespace ArraySorts;

/*
 * Сортировка по частям (Stooge sort) – рекурсивный алгоритм сортировки массива.
 *
 * Алгоритм сортировки stooge sort заключается в следующем:
 *  - Если значение последнего элемента массива меньше, чем значение первого элемента,
 *      то меняем их местами;
 *  - Если в массиве содержится три и более элемента, то:
 *      - Рекурсивно вызываем метод для первых 2⁄3 элементов;
 *      - Рекурсивно вызываем метод для последних 2⁄3 элементов;
 *      - Снова рекурсивно вызываем метод для первых 2⁄3 элементов;
 */
public static partial class SortExtensions
{
    //сортировка по частям
    private static int[] StoogeSort(this int[] array, int startIndex, int endIndex, bool desc)
    {
        if (array.Length < 2) return array;
        var greater = Greater<int>(desc);
        if (greater(array[startIndex], array[endIndex])) array.Swap(startIndex, endIndex);

        if (endIndex - startIndex > 1)
        {
            var len = (endIndex - startIndex + 1) / 3;
            array.StoogeSort(startIndex, endIndex - len, desc);
            array.StoogeSort(startIndex + len, endIndex, desc);
            array.StoogeSort(startIndex, endIndex - len, desc);
        }
        return array;
    }

    private static int[] StoogeSortBase(this int[] a, bool desc) => 
        StoogeSort(a, 0, a.Length - 1, desc);

    /// <summary>
    /// сортировка по частям, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный входящий массив</returns>
    public static int[] StoogeSort<TNumber>(this int[] array) => StoogeSortBase(array, false);

    /// <summary>
    /// сортировка по частям по убыванию, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный по убыванию входящий массив</returns>
    public static int[] StoogeSortDesc<TNumber>(this int[] array) => StoogeSortBase(array, true);
}