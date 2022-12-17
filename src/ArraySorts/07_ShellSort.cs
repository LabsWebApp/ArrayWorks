namespace ArraySorts;

/*
 * Сортировка Шелла (Shell sort) – алгоритм сортировки массива,
 * который является обобщением сортировки вставками.
 * 
 * Алгоритм сортировки Шелла базируется на двух идеях:
 *  - Сортировка вставками показывает лучшие результаты на практически
 *      упорядоченных массивах данных;
 *  - Сортировка вставками неэффективна для смешанных данных,
 *      потому что за одну итерацию элементы смещаются только на одну позицию.
 * Для устранения недостатков алгоритма Insertion Sort, в сортировке Шелла осуществляется
 * несколько сортировок вставками. При этом в каждой итерации сравниваются элементы,
 * которые размещены на разных расстояниях один от другого, начиная с наиболее
 * отдаленных (d = 1⁄2 длины массива) до сравнения соседних элементов (d = 1).
 */
public static partial class SortExtensions
{
    // Сортировка Шелла
    private static TNumber[] ShellSortBase<TNumber>(TNumber[] array, bool desc)
        where TNumber : INumber<TNumber>
    {
        //расстояние между элементами, которые сравниваются
        var d = array.Length >> 1;
        var greater = Greater<TNumber>(desc);
        while (d > 0)
        {
            for (var i = d; i < array.Length; i++)
            {
                var j = i;
                while (j >= d && greater(array[j - d], array[j]))
                {
                    array.Swap(j, j - d);
                    j -= d;
                }
            }

            d >>= 1;
        }

        return array;
    }

    /// <summary>
    /// Сортировка Шелла, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный входящий массив</returns>
    public static TNumber[] ShellSort<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => ShellSortBase(array, false);

    /// <summary>
    /// Сортировка Шелла по убыванию, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный по убыванию входящий массив</returns>
    public static TNumber[] ShellSortDesc<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => ShellSortBase(array, true);
}