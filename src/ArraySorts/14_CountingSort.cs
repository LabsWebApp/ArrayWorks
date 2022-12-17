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
    public static int[] CountingSortBase(int[] array, bool desc)
    {
        if (array.Length < 2) return array;
        var (min, max) = array.MinMaxValues();
        var range = max - min + 1;
        var count = new int[range];
        var output = new int[array.Length];
        foreach (var t in array) count[t - min]++;

        void SetOutput(int item)
        {
            output[count[item - min] - 1] = item;
            count[item - min]--;
        }

        if (desc) 
        {
            for (var i = count.Length - 2; i >= 0; i--) count[i] += count[i + 1];
            foreach (var item in array) SetOutput(item);
        }
        else
        {
            for (var i = 1; i < count.Length; i++) count[i] += count[i - 1];
            for (var i = array.Length - 1; i >= 0; i--) SetOutput(array[i]);
        }
        //Если нужна отсортировка исходного массива:
        //for (var i = 0; i < array.Length; i++) array[i] = output[i];
        return output;
    }

    /// <summary>
    /// Сортировка подсчетом, входящий массив не будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>массив, составленный из отсортированных элементов входящего массива</returns>
    public static int[] CountingSort(this int[] array) => CountingSortBase(array, false);

    /// <summary>
    /// Сортировка подсчетом, входящий массив будет не отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>массив, составленный из отсортированных по убыванию элементов входящего массива</returns>
    public static int[] CountingSortDesc(this int[] array) => CountingSortBase(array, true);
}