namespace ArraySorts;

/*
 * ����� ���������� (Intro Sort) (����� ��������� ��� ��������������� ����������) �
 * ��� ��������� �������� ����������, ������� ������������ ��� ������� ������� ������������������,
 * ��� � ����������� ������������������ � ������ ������.
 * ������� ��������� ������ �������� �������� �� ������� ����������, ���� �� <=16,
 * �� �������� ���������� ���������. � ��������� ������ ��������� ������� �������� �� ����� �������,
 * � ���� ������ �������� �������� ������ ����� �����, �� ������������ �������� HeapSort,
 * ��������� ������ ������������ �������� ������� ����������.
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
    /// ����� ����������, �������� ������ ����� ������������
    /// </summary>
    /// <param name="array">�������� ������</param>
    /// <returns>������, ������������ �� ��������������� ��������� ��������� �������</returns>
    public static TNumber[] IntroSort<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => IntroSortBase(array, false);

    /// <summary>
    /// ����� ����������, �������� ������ ����� ������������
    /// </summary>
    /// <param name="array">�������� ������</param>
    /// <returns>������, ������������ �� ��������������� �� �������� ��������� ��������� �������</returns>
    public static TNumber[] IntroSortDesc<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => IntroSortBase(array, true);
}