namespace ArraySorts;

/*
 * Сортировка перемешиванием (cocktail sort, shaker sort), или шейкерная сортировка –
 * это усовершенствованная разновидность сортировки пузырьком, при которой сортировка
 * производиться в двух направлениях, меняя направление при каждом проходе.
 *
 * Проанализировав алгоритм пузырьковой сортировки, можно заметить:
 *  - если при обходе части массива не было обменов элементов,
 *      то эту часть можно исключить, так как она уже отсортирована;
 *  - при проходе от конца массива к началу минимальное значение сдвигается
 *      на первую позицию, при этом максимальный элемент перемещается только
 *      на один индекс вправо.
 * Исходя из приведенных идей, модифицируем сортировку пузырьком следующим образом:
 *  - на каждой итерации, фиксируем границы части массива в которой происходит обмен;
 *  - массив обходиться поочередно от начала массива к концу и от конца к началу;
 * При этом минимальный элемент перемещается в начало массива,
 * а максимальный - в конец, после этого уменьшается рабочая область массива.
 */
public static partial class SortExtensions
{
    //сортировка перемешиванием
    private static TNumber[] ShakerSortBase<TNumber>(TNumber[] array, bool desc)
        where TNumber : INumber<TNumber>
    {
        var greater = Greater<TNumber>(desc);
        for (var i = 0; i < array.Length >> 1; i++)
        {
            var swapFlag = false;
            //проход слева направо
            for (var j = i; j < array.Length - i - 1; j++)
            {
                if (greater(array[j], array[j + 1]))
                {
                    array.Swap(j, j + 1);
                    swapFlag = true;
                }
            }

            //проход справа налево
            for (var j = array.Length - 2 - i; j > i; j--)
            {
                if (greater(array[j - 1], array[j]))
                {
                    array.Swap(j - 1, j);
                    swapFlag = true;
                }
            }

            //если обменов не было выходим
            if (!swapFlag) break;
        }

        return array;
    }

    /// <summary>
    /// сортировка перемешиванием, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный входящий массив</returns>
    public static TNumber[] ShakerSort<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => ShakerSortBase(array, false);

    /// <summary>
    /// сортировка перемешиванием по убыванию, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный по убыванию входящий массив</returns>
    public static TNumber[] ShakerSortDesc<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => ShakerSortBase(array, true);
}