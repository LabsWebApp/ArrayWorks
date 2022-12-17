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
    private static int IndexOfMin<TNumber>(this TNumber[] array, int n, bool desc)
        where TNumber : INumber<TNumber>
    {
        var result = n;
        var less = Less<TNumber>(desc);
        for (var i = n; i < array.Length; ++i)
            if (less(array[i], array[result]))
                result = i;

        return result;
    }

    //сортировка выбором
    private static TNumber[] SelectionSort<TNumber>(this TNumber[] array, int currentIndex, bool desc)
        where TNumber : INumber<TNumber>
    {
        if (currentIndex == array.Length) return array;

        var index = array.IndexOfMin(currentIndex, desc);
        if (index != currentIndex) array.Swap(index, currentIndex);

        return array.SelectionSort(currentIndex + 1, desc);
    }

    private static TNumber[] SelectionSortBase<TNumber>(TNumber[] array, bool desc)
        where TNumber : INumber<TNumber> =>
        array.SelectionSort(0, desc);

    /// <summary>
    /// сортировка выбором, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный входящий массив</returns>
    public static TNumber[] SelectionSort<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => SelectionSortBase(array, false);

    /// <summary>
    /// сортировка выбором по убыванию, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный по убыванию входящий массив</returns>
    public static TNumber[] SelectionSortDesc<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => SelectionSortBase(array, true);
}