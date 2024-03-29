﻿namespace ArraySorts;

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
 * Вариант сортировки не использует рекурсию (правильная сортировка)
 */
public static partial class SortExtensions
{
    //быстрая сортировка
    private static TNumber[] QuickSortBase<TNumber>(TNumber[] array, bool desc)
        where TNumber : INumber<TNumber>
    {
        if (array.Length < 2) return array;

        var greater = Greater<TNumber>(desc);
        var greaterEqual = GreaterEqual<TNumber>(desc);
        var lessEqual = LessEqual<TNumber>(desc);

        var stack = new Stack<int>();

        var index = 0;
        var right = array.Length - 1;

        stack.Push(index);
        stack.Push(right);

        while (stack.Count > 0)
        {
            var rightSubarray = stack.Pop();
            var leftSubarray = stack.Pop();
            var left = leftSubarray + 1;
            index = leftSubarray;
            right = rightSubarray;

            var pivot = array[index];

            if (left > right) continue;

            while (left < right)
            {
                while (left <= right && lessEqual(array[left], pivot)) left++;    
                while (left <= right && greaterEqual(array[right], pivot)) right--;

                if (right >= left) array.Swap(left, right);
            }

            if (index <= right)
                if (greater(array[index], array[right]))
                    array.Swap(index, right);

            if (leftSubarray < right)
            {
                stack.Push(leftSubarray);
                stack.Push(right - 1);
            }

            if (rightSubarray > right)
            {
                stack.Push(right + 1);
                stack.Push(rightSubarray);
            }
        }

        return array;
    }

    /// <summary>
    /// быстрая сортировка, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный входящий массив</returns>
    public static TNumber[] QuickSort<TNumber>(this TNumber[] array)
        where TNumber : struct, INumber<TNumber> => QuickSortBase(array, false);

    /// <summary>
    /// быстрая сортировка по убыванию, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный по убыванию входящий массив</returns>
    public static TNumber[] QuickSortDesc<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => QuickSortBase(array, true);
}