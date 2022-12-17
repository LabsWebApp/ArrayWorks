namespace ArraySorts;

/*
 * Быстрая сортировка (quick sort), или сортировка Хоара – один из самых быстрых
 * алгоритмов сортирования данных.
 * Алгоритм Хоара – это модифицированный вариант метода прямого обмена.
 * Другие популярные варианты этого метода - сортировка пузырьком и шейкерная сортировка,
 * в отличии от быстрой сортировки, не очень эффективны.
 *
 * Идея алгоритма следующая:
 *  - Необходимо выбрать опорный элемент массива, им может быть любой элемент,
 *      от этого не зависит правильность работы алгоритма;
 *  - Разделить массив на три части, в первую должны войти элементы меньше опорного,
 *      во вторую - равные опорному и в третью - все элементы больше опорного;
 *  - Рекурсивно выполняются предыдущие шаги, для подмассивов с меньшими и
 *      большими значениями, до тех пор, пока в них содержится больше одного элемента.
 * Поскольку метод быстрой сортировки разделяет массив на части, он относиться
 * к группе алгоритмов разделяй и властвуй.
 */

/*
 * Вариант сортировки использует рекурсию
 * (НЕ ПРАВИЛЬНОЕ РЕШЕНИЕ) - приводит к переполнению стека
 */
public static partial class SortExtensions
{
    //метод возвращающий индекс опорного элемента
    private static int Partition<TNumber>(TNumber[] array, int left, int right, Func<TNumber, TNumber, bool> less)
        where TNumber : INumber<TNumber>
    {
        var pivot = array[right];

        var pivotIndex = left;

        for (var i = left; i < right; i++)
            if (less(array[i], pivot)) array.Swap(pivotIndex++, i);

        array[right] = array[pivotIndex];
        array[pivotIndex] = pivot;
        return pivotIndex;
    }

    //быстрая сортировка
    private static TNumber[] QuickSortRecursive<TNumber>(this TNumber[] array, 
        int left, int right, bool desc)
        where TNumber : INumber<TNumber>
    {
        if (array.Length < 2 || left >= right) return array;

        var less = Less<TNumber>(desc);

        var pivotIndex = Partition(array, left, right, less);

        QuickSortRecursive(array, left, pivotIndex - 1, desc);
        QuickSortRecursive(array, pivotIndex + 1, right, desc);

        return array;
    }

    private static TNumber[] QuickSortRecursiveBase<TNumber>(TNumber[] array, bool desc)
        where TNumber : INumber<TNumber> =>
        array.QuickSortRecursive(0, array.Length - 1, desc);

    /// <summary>
    /// быстрая сортировка, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный входящий массив</returns>
    public static TNumber[] QuickSortRecursive<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => QuickSortRecursiveBase(array, false);

    /// <summary>
    /// быстрая сортировка по убыванию, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный по убыванию входящий массив</returns>
    public static TNumber[] QuickSortRecursiveDesc<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => QuickSortRecursiveBase(array, true);
}