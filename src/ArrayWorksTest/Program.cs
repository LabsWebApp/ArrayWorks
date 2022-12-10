using System.Diagnostics;
using System.Reflection;

//#region Min <-> Max
//var a = UniqueRandomArray(-10, 50, 10, R);
//WriteLine("Исходный массив:");
//a.PrintArray();
//a.SwapMinMax();
//a.PrintArray();
//WriteLine("[в массиве переставлены местами максимальное и минимальное значения]");
//#endregion

#region Sort

#region Sorting Methods 
void Sort(Func<int[], int[]> sort, int[]? array = null, bool unique = true)
{
    WriteLine($"\n{sort.GetMethodInfo().Name}:");
    if (array is null)
    {
        array = unique
            ? UniqueRandomArray(-10, 50, 10, R)
            : RandomArray(-10, 50, 10, R);
        array.PrintArray();
    }
    var result = sort(array);
    result.PrintArray();
    WriteLine($"[массив отсортирован - {result.IsSorted()}]");
}

(TimeSpan, string) Test(Func<int[], int[]> sort)
{
    Stopwatch sw = new();
    const int count = 50000;
    for (var i = 0; i < count; i++)
    {
        var array = RandomArray(-200, 500, 0, R);
        sw.Start();
        var sorted = sort(array);
        sw.Stop();
        if (!sorted.IsSorted())
        {
            WriteLine($"[шаг - {i}]: ");
            sorted.PrintArray();
            break;
        }
        if (i == count - 1) WriteLine($"{sort.GetMethodInfo().Name}Test - OK!");
    }
    return (sw.Elapsed, sort.GetMethodInfo().Name) ;
}
void SortTest(Func<int[], int[]> sort)
{
    Sort(sort);
    WriteLine($"[время тестирования = {Test(sort)}]");
}
#endregion

#region SortTests
//Sort(SortExtensions.BogoSort, a);
SortTest(SortExtensions.BubbleSort);
SortTest(SortExtensions.ShakerSort);
SortTest(SortExtensions.InsertionSort);
//SortTest(SortExtensions.StoogeSort);
SortTest(SortExtensions.PancakeSort);
SortTest(SortExtensions.ShellSort);
SortTest(SortExtensions.MergeSort);
SortTest(SortExtensions.SelectionSort);
SortTest(SortExtensions.QuickSort);
SortTest(SortExtensions.GnomeSort);
SortTest(SortExtensions.TreeSort);
SortTest(SortExtensions.CombSort);
SortTest(SortExtensions.CountingSort);
#endregion
#endregion

ReadKey();