namespace ArraySorts.Helpers;

/// <summary>
/// Простая реализация бинарного дерева
/// </summary>
internal class TreeNode<TNumber>
    where TNumber : INumber<TNumber>
{
    public TreeNode(TNumber data) => Data = data;

    /// <summary>
    /// данные
    /// </summary>
    public TNumber Data { get; set; }

    /// <summary>
    /// левая ветка дерева
    /// </summary>
    public TreeNode<TNumber>? Left { get; set; }

    /// <summary>
    /// правая ветка дерева
    /// </summary>
    public TreeNode<TNumber>? Right { get; set; }

    /// <summary>
    /// рекурсивное добавление узла в дерево
    /// </summary>
    /// <param name="node">узел, который требуется добавить</param>
    public void Insert(TreeNode<TNumber> node)
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

    /// <summary>
    /// рекурсивное преобразование дерева в отсортированный массив
    /// </summary>
    /// <param name="elements">аккумулятивная коллекция узлов дерева</param>
    /// <param name="desc">true - если необходимо отсортировать массив по убыванию иначе по возрастанию</param>
    /// <returns>отсортированный массив</returns>
    public TNumber[] Transform(bool desc, ICollection<TNumber>? elements = null)
    {
        elements ??= new List<TNumber>();

        if (desc) Right?.Transform(desc, elements);
        else Left?.Transform(desc, elements);

        elements.Add(Data);

        if (desc) Left?.Transform(desc, elements);
        else Right?.Transform(desc, elements);

        return elements.ToArray();
    }
}