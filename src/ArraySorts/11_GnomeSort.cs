namespace ArraySorts;
/*
 * Гномья сортировка (Gnome sort) – простой в реализации алгоритм сортировки массива,
 * назван в честь садового гнома, который предположительно таким методом сортирует
 * садовые горшки. Самый очевидный алгоритм.
 *
 * Алгоритм находит первую пару неотсортированных элементов массива и меняет их местами.
 * При этом учитывается факт, что обмен приводит к неправильному расположению элементов,
 * примыкающих с обеих сторон к только что переставленным. Поскольку все элементы массива
 * после переставленных неотсортированы, необходимо перепроверить только элементы
 * до переставленных.
 */
public static partial class SortExtensions
{
    //Гномья сортировка
    private static TNumber[] GnomeSortBase<TNumber>(TNumber[] array, bool desc)
        where TNumber : INumber<TNumber>
    {
        var index = 1;
        var nextIndex = index + 1;
        var less = Less<TNumber>(desc);
        while (index < array.Length)
        {
            if (less(array[index - 1], array[index])) index = nextIndex++;
            else
            {
                array.Swap(index - 1, index--);
                if (index == 0) index = nextIndex++;
            }
        }
        return array;
    }

    /// <summary>
    /// Гномья сортировка, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный массив</returns>
    public static TNumber[] GnomeSort<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => GnomeSortBase(array, false);

    /// <summary>
    /// Гномья сортировка по убыванию, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный по убыванию входящий массив</returns>
    public static TNumber[] GnomeSortDesc<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => GnomeSortBase(array, true);
}