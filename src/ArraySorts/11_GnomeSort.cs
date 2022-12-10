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
    public static int[] GnomeSort(this int[] array)
    {
        if (array.Length < 2) return array;
        var index = 1;
        var nextIndex = index + 1;

        while (index < array.Length)
        {
            if (array[index - 1] < array[index]) index = nextIndex++;
            else
            {
                array.Swap(index - 1, index--);
                if (index == 0) index = nextIndex++;
            }
        }
        return array;
    }
}