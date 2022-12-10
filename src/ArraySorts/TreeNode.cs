namespace ArraySorts.Helpers;

/// <summary>
/// Простая реализация бинарного дерева
/// </summary>
internal class TreeNode
{
    public TreeNode(int data) => Data = data;

    //данные
    public int Data { get; set; }

    //левая ветка дерева
    public TreeNode? Left { get; set; }

    //правая ветка дерева
    public TreeNode? Right { get; set; }

    //рекурсивное добавление узла в дерево
    public void Insert(TreeNode node)
    {
        if (node.Data < Data)
        {
            if (Left is null) Left = node;
            else Left.Insert(node);
        }
        else
        {
            if (Right is null) Right = node;
            else Right.Insert(node);
        }
    }

    //рекурсивное преобразование дерева в отсортированный массив
    public int[] Transform(ICollection<int>? elements = null)
    {
        elements ??= new List<int>();

        Left?.Transform(elements);

        elements.Add(Data);

        Right?.Transform(elements);

        return elements.ToArray();
    }
}