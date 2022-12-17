namespace ArraySorts;

/*
 * Сортировка слиянием (Merge sort) – алгоритм сортировки массива,
 * который реализован по принципу "разделяй и властвуй".
 * Задача сортировки массива разбивается на несколько подзадач
 * сортировки массивов меньшего размера, после выполнения которых,
 * результат комбинируется, что и приводит к решению начальной задачи.
 *
 * Алгоритм сортировки слиянием выглядит следующим образом:
 *  - Входной массив разбивается на две части одинакового размера;
 *  - Каждый из подмассивов сортируется отдельно, по этому же принципу, то есть 
 *      производится повторное разбитие до тех пор, пока длина подмассива не достигнет
 *      единицы. В таком случае каждый единичный массив считается отсортированным;
 */
public static partial class SortExtensions
{
    //метод для слияния массивов
    private static void Merge<TNumber>(TNumber[] array, int lowIndex, int middleIndex, int highIndex, bool desc)
        where TNumber : INumber<TNumber>
    {
        var left = lowIndex;
        var right = middleIndex + 1;
        var tempArray = new TNumber[highIndex - lowIndex + 1];
        var index = 0;
        var less = Less<TNumber>(desc);

        while (left <= middleIndex && right <= highIndex)
        {
            if (less(array[left], array[right])) tempArray[index++] = array[left++];
            else tempArray[index++] = array[right++];
        }

        for (var i = left; i <= middleIndex; i++) tempArray[index++] = array[i];

        for (var i = right; i <= highIndex; i++) tempArray[index++] = array[i];

        for (var i = 0; i < tempArray.Length; i++) array[lowIndex + i] = tempArray[i];
    }

    //сортировка слиянием
    private static TNumber[] MergeSort<TNumber>(TNumber[] array, int lowIndex, int highIndex, bool desc)
        where TNumber : INumber<TNumber>
    {
        if (lowIndex < highIndex)
        {
            var middleIndex = (lowIndex + highIndex) >> 1;
            MergeSort(array, lowIndex, middleIndex, desc);
            MergeSort(array, middleIndex + 1, highIndex, desc);
            Merge(array, lowIndex, middleIndex, highIndex, desc);
        }

        return array;
    }

    private static TNumber[] MergeSortBase<TNumber>(TNumber[] array, bool desc)
        where TNumber : INumber<TNumber> =>
        MergeSort(array, 0, array.Length - 1, desc);

    /// <summary>
    /// сортировка слиянием, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный входящий массив</returns>
    public static TNumber[] MergeSort<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => MergeSortBase(array, false);

    /// <summary>
    /// сортировка слиянием по убыванию, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный по убыванию входящий массив</returns>
    public static TNumber[] MergeSortDesc<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => MergeSortBase(array, true);
}