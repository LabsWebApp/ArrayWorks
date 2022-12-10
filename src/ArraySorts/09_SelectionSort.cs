namespace ArraySorts;

/*
 * Сортировка выбором (Selection sort) – алгоритм сортировки массива, который по скорости
 * выполнения сравним с сортировкой пузырьком.
 *
 * Алгоритм сортировки выбором состоит из следующих шагов:
 *  - Для начала определяем позицию минимального элемента массива;
 *  - Делаем обмен минимального элемента с элементом в начале массива.
 *      Получается, что первый элемент массива уже отсортирован;
 *  - Уменьшаем рабочую область массива, отбрасывая первый элемент,
 *      а для подмассива который получился, повторяем сортировку.
 */
public static partial class SortExtensions
{
    //метод поиска позиции минимального элемента подмассива, начиная с позиции n
    private static int IndexOfMin(this int[] array, int n)
    {
        var result = n;
        for (var i = n; i < array.Length; ++i)
            if (array[i] < array[result])
                result = i;

        return result;
    }

    //сортировка выбором
    private static int[] SelectionSort(this int[] array, int currentIndex)
    {
        if (array.Length < 2) return array;
        if (currentIndex == array.Length) return array;

        var index = array.IndexOfMin(currentIndex);
        if (index != currentIndex) array.Swap(index, currentIndex);

        return array.SelectionSort(currentIndex + 1);
    }

    public static int[] SelectionSort(this int[] array) =>
        array.SelectionSort(0);
}