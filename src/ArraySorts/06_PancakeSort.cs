namespace ArraySorts;

/*
 * Блинная сортировка (pancake sort) – алгоритм сортировки массива,
 * в к-ом сортировка осуществляется переворотом части массива.
 * В этом алгоритме, к массиву, позволено применять только одну операцию –
 * переворот части массива. И в отличии от других методов сортировки,
 * где пытаются уменьшить количество сравнений,
 * в этом нужно минимизировать количество переворотов.
 *
 * Идея алгоритма заключается в том, чтобы за каждый проход, переместить
 * максимальный элемент в конец массива. Для этого необходимо выполнить следующие шаги:
 *  1. В начале выбрать подмассив, равный по длине текущему массиву;
 *  2. Найти в нем позицию максимального элемента;
 *  3. Если максимальный элемент расположен не в конце подмассива, то:
 *      - Переворачиваем часть массива от начала до максимального значения;
 *      - Переворачиваем весь выбранный подмассив;
 *  4. Уменьшаем рабочую область массива и переходим ко второму шагу.
 */
public static partial class SortExtensions
{
    //метод для получения индекса максимального элемента подмассива
    private static int IndexOfMax(this int[] a, int n, bool desc)
    {
        var result = 0;
        var greater = Greater<int>(desc);
        for (var i = 1; i <= n; ++i) if (greater(a[i], a[result])) result = i;
        return result;
    }

    //метод для переворота массива
    private static void Flip(this int[] a, int end)
    {
        for (var start = 0; start < end; start++, end--) a.Swap(start, end);
    }

    //блинная сортировка
    private static int[] PancakeSortBase(int[] array, bool desc)
    {
        for (var subArrayLength = array.Length - 1; subArrayLength >= 0; subArrayLength--)
        {
            //получаем позицию максимального элемента подмассива
            var indexOfMax = array.IndexOfMax(subArrayLength, desc);
            if (indexOfMax != subArrayLength)
            {
                //переворот массива до индекса максимального элемента
                //максимальный элемент подмассива расположится вначале
                array.Flip(indexOfMax);
                //переворот всего подмассива
                array.Flip(subArrayLength);
            }
        }

        return array;
    }

    /// <summary>
    /// блинная сортировка, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный входящий массив</returns>
    public static int[] PancakeSort(this int[] array) => PancakeSortBase(array, false);

    /// <summary>
    /// блинная сортировка по убыванию, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный по убыванию входящий массив</returns>
    public static int[] PancakeSortDesc(this int[] array) => PancakeSortBase(array, true);
}