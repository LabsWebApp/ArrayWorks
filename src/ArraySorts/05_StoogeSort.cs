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
    private static int[] StoogeSort(this int[] array, int startIndex, int endIndex)
    {
        if (array.Length < 2) return array;
        if (array[startIndex] > array[endIndex]) array.Swap(startIndex, endIndex);

        if (endIndex - startIndex > 1)
        {
            var len = (endIndex - startIndex + 1) / 3;
            array.StoogeSort(startIndex, endIndex - len);
            array.StoogeSort(startIndex + len, endIndex);
            array.StoogeSort(startIndex, endIndex - len);
        }
        return array;
    }

    public static int[] StoogeSort(this int[] a) => 
        StoogeSort(a, 0, a.Length - 1);
}