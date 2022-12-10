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
public static partial class SortExtensions
{
    //метод возвращающий индекс опорного элемента
    private static int Partition(int[] array, int minIndex, int maxIndex)
    {
        var pivot = minIndex - 1;
        for (var i = minIndex; i < maxIndex; i++)
            if (array[i] < array[maxIndex]) array.Swap(++pivot, i);

        array.Swap(++pivot, maxIndex);
        return pivot;
    }

    //быстрая сортировка
    private static int[] QuickSort(this int[] array, int minIndex, int maxIndex)
    {
        if (array.Length < 2 || minIndex >= maxIndex) return array;

        var pivotIndex = Partition(array, minIndex, maxIndex);
        QuickSort(array, minIndex, pivotIndex - 1);
        QuickSort(array, pivotIndex + 1, maxIndex);

        return array;
    }

    public static int[] QuickSort(this int[] array) =>
        array.QuickSort(0, array.Length - 1);
}