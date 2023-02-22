namespace ArraySorts;

/*
 * Интро сортировка (Intro Sort) (также известная как интроспективная сортировка) —
 * это гибридный алгоритм сортировки, который обеспечивает как высокую среднюю производительность,
 * так и оптимальную производительность в худшем случае.
 * Сначала вычисляем индекс опорного элемента из Быстрой сортировки, если он <=16,
 * то работает Сортировка вставками. В противном случае вычисляем двойной логарифм от длины массива,
 * и если индекс опорного элемента больше этого числа, то используется алгоритм HeapSort,
 * противном случае используется алгоритм Быстрой сортировки.
 */
public static partial class SortExtensions
{
    private static TNumber[] IntroSortBase<TNumber>(TNumber[] array, bool desc) 
        where TNumber : INumber<TNumber>
    {
        if (array.Length < 2) return array;
        var less = Less<TNumber>(desc);
        var partition = Partition(array, 0, array.Length - 1, less);

        if (partition < 16) 
            return InsertionSortBase(array, desc);
        if (partition > 2 * Math.Log(array.Length)) 
            HeapSortBase(array, desc);
        else
            QuickSortBase(array, desc);
        return array;
    }

    /// <summary>
    /// Интро сортировка, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>массив, составленный из отсортированных элементов входящего массива</returns>
    public static TNumber[] IntroSort<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => IntroSortBase(array, false);

    /// <summary>
    /// Интро сортировка, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>массив, составленный из отсортированных по убыванию элементов входящего массива</returns>
    public static TNumber[] IntroSortDesc<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => IntroSortBase(array, true);
}