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
    private static void Merge(this int[] array, int lowIndex, int middleIndex, int highIndex)
    {
        var left = lowIndex;
        var right = middleIndex + 1;
        var tempArray = new int[highIndex - lowIndex + 1];
        var index = 0;

        while (left <= middleIndex && right <= highIndex)
        {
            if (array[left] < array[right]) tempArray[index++] = array[left++];
            else tempArray[index++] = array[right++];
        }

        for (var i = left; i <= middleIndex; i++) tempArray[index++] = array[i];

        for (var i = right; i <= highIndex; i++) tempArray[index++] = array[i];

        for (var i = 0; i < tempArray.Length; i++) array[lowIndex + i] = tempArray[i];
    }

    //сортировка слиянием
    private static int[] MergeSort(this int[] array, int lowIndex, int highIndex)
    {
        if (array.Length < 2) return array;
        if (lowIndex < highIndex)
        {
            var middleIndex = (lowIndex + highIndex) >> 1;
            MergeSort(array, lowIndex, middleIndex);
            MergeSort(array, middleIndex + 1, highIndex);
            Merge(array, lowIndex, middleIndex, highIndex);
        }

        return array;
    }

    public static int[] MergeSort(this int[] array) =>
        MergeSort(array, 0, array.Length - 1);
}