namespace ArraySorts;

/*
 * Сортировка бинарным деревом (Tree sort) – алгоритм сортировки, который заключается
 * в построении двоичного дерева поиска по ключам массива, с последующим построением
 * результирующего массива упорядоченных элементов путем обхода дерева.
 *
 * Алгоритм сортировки бинарным деревом:
 *  - Элементы неотсортированного массива данных добавляются в двоичное дерево поиска;
 *  - Для получения отсортированного массива, производится обход бинарного дерева
 *      с переносом данных из дерева в результирующий массив.
 */
public static partial class SortExtensions
{
    //метод для сортировки с помощью двоичного дерева
    private static TNumber[] TreeSortBase<TNumber>(TNumber[] array, bool desc)
        where TNumber : INumber<TNumber>
    {
        if (array.Length < 1) return array;
        var treeNode = new TreeNode<TNumber>(array[0]);
        for (var i = 1; i < array.Length; i++) treeNode.Insert(new TreeNode<TNumber>(array[i]));

        //Если нужна отсортировка исходного массива:
        //var output = treeNode.Transform(desc);
        //for (var i = 0; i < array.Length; i++) array[i] = output[i];
        //return array;

        return treeNode.Transform(desc);
    }

    /// <summary>
    /// метод для сортировки с помощью двоичного дерева, входящий массив не будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>массив, составленный из отсортированных элементов входящего массива</returns>
    public static TNumber[] TreeSort<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => TreeSortBase(array, false);

    /// <summary>
    /// метод для сортировки с помощью двоичного дерева, входящий массив не будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>массив, составленный из отсортированных по убыванию элементов входящего массива</returns>
    public static TNumber[] TreeSortDesc<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => TreeSortBase(array, true);
}