using ArraySorts.Helpers;

namespace ArraySorts;

/*
 * Сортировка бинарным деревом (Tree sort) – алгоритм сортировки, который заключается
 * в построении двоичного дерева поиска по ключам массива, с последующим построением
 * результирующего массива упорядоченных элементов путем обхода дерева.
 *
 * Алгоритм сортировки бинарным деревом:
 *  - Элементы неотсортированного массива данных добавляются в двоичное дерево поиска;
 *  - 
 */
public static partial class SortExtensions
{
    //метод для сортировки с помощью двоичного дерева
    public static int[] TreeSort(int[] array)
    {
        if (array.Length < 2) return array;
        var treeNode = new TreeNode(array[0]);
        for (var i = 1; i < array.Length; i++) treeNode.Insert(new TreeNode(array[i]));
        return treeNode.Transform();
    }
}