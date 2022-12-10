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
    private static void RandomPermutation(this int[] array)
    {
        var n = array.Length;
        while (n > 1)
        {
            n--;
            var i = R.Next(n + 1);
            array.Swap(i, n);
        }
    }

    //случайная сортировка
    public static int[] BogoSort(this int[] array)
    {
        if (array.Length < 2) return array;
        while (!array.IsSorted()) array.RandomPermutation();
        return array;
    }
}