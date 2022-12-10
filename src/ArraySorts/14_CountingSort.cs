namespace ArraySorts;

/*
 * Сортировка подсчетом (Counting sort) – алгоритм сортировки, который применяется
 * при небольшом количестве разных значений элементов массива данных.
 * Время работы алгоритма, линейно зависит от общего количества элементов массива и
 * от количества разных элементов.
 *
 * Идея алгоритма заключается в следующем:
 *  - считаем количество вхождений каждого элемента массива;
 *  - исходя из данных полученных на первом шаге, формируем отсортированный массив.
 */
public static partial class SortExtensions
{
    // Сортировка подсчетом
    public static int[] CountingSort(this int[] array)
    {
        if (array.Length < 2) return array;
        var max = array.Max();
        var min = array.Min();
        var range = max - min + 1;
        var count = new int[range];
        var output = new int[array.Length];
        foreach (var t in array) count[t - min]++;

        for (var i = 1; i < count.Length; i++) count[i] += count[i - 1];
        for (var i = array.Length - 1; i >= 0; i--)
        {
            output[count[array[i] - min] - 1] = array[i];
            count[array[i] - min]--;
        }
        for (var i = 0; i < array.Length; i++) array[i] = output[i];
        return array;
    }
}