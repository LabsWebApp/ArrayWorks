namespace ArraySorts;

/*
 * Сортировка пузырьком (bubble sort) - один из самых простых для понимания методов сортировки массивов.
 *
 * Алгоритм заключается в циклических проходах по массиву,
 * за каждый проход элементы массива попарно сравниваются и,
 * если их порядок не правильный, то осуществляется обмен.
 * Обход массива повторяется до тех пор, пока массив не будет упорядочен.
 */
public static partial class SortExtensions
{
    //сортировка пузырьком
    public static int[] BubbleSort(this int[] array)
    {
        if (array.Length < 2) return array;
        var len = array.Length;
        for (var i = 1; i < len; i++)
            for (var j = 0; j < len - i; j++) 
                if (array[j] > array[j + 1]) 
                    array.Swap(j, j + 1);
        return array;
    }
}