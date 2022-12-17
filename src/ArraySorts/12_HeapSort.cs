namespace ArraySorts;

/*
 * —ортировка кучей (Heep sort) или бинарным деревом Ц алгоритм сортировки, который заключаетс€
 * в построении двоичного дерева поиска по ключам массива, с последующим построением
 * результирующего массива упор€доченных элементов путем обхода дерева.
 *
 * ќсобенностью кучи €вл€етс€ то, что само дерево не строитс€, а имитируетс€
 */
public static partial class SortExtensions
{
    private static void Heapify<TNumber>(TNumber[] array, int heap, int index) 
        where TNumber : INumber<TNumber>
    {
        while (true)
        {
            var largest = index;
            var left = (index << 1) + 1;
            var right = (index << 1) + 2;
            if (left < heap && array[left] > array[largest]) largest = left;
            if (right < heap && array[right] > array[largest]) largest = right;
            if (largest != index)
            {
                array.Swap(index, largest);
                index = largest;
                continue;
            }
            break;
        }
    }

    private static void HeapifyDesc<TNumber>(TNumber[] array, int heapSize, int index) 
        where TNumber : INumber<TNumber>
    {
        while (true)
        {
            var smallest = index; 
            var left = (index << 1) + 1;
            var right = (index << 1) + 2;
            if (left < heapSize && array[left] < array[smallest]) smallest = left;
            if (right < heapSize && array[right] < array[smallest]) smallest = right;
            if (smallest != index)
            {
                array.Swap(index, smallest);
                index = smallest;
                continue;
            }

            break;
        }
    }

    private static TNumber[] HeapSortBase<TNumber>(TNumber[] array, bool desc)
        where TNumber : INumber<TNumber>
    {
        var heap = array.Length;
        Action<TNumber[], int, int> heapify = desc ? HeapifyDesc : Heapify;

        for (var i = (heap >> 1) - 1; i >= 0; i--)
            heapify(array, heap, i);
        for (var i = heap - 1; i >= 0; i--)
        {
            array.Swap(0, i);
            heapify(array, i, 0);
        }

        return array;
    }

    /// <summary>
    /// сортировка кучей, вход€щий массив будет отсортирован
    /// </summary>
    /// <param name="array">вход€щий массив</param>
    /// <returns>отсортированный вход€щий массив</returns>
    public static TNumber[] HeepSort<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => HeapSortBase(array, false);

    /// <summary>
    /// сортировка кучей по убыванию, вход€щий массив будет отсортирован
    /// </summary>
    /// <param name="array">вход€щий массив</param>
    /// <returns>отсортированный по убыванию вход€щий массив</returns>
    public static TNumber[] HeepSortSortDesc<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => HeapSortBase(array, true);
}