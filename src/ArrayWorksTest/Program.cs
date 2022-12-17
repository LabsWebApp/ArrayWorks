using System.Diagnostics;
using System.Reflection;
using ArrayWorksTest;
using BenchmarkDotNet.Running;

#region Benchmark

//BenchmarkRunner.Run<SortBenchmark>();
//ReadKey();
#endregion

//#region BinarySearch

//int i = 0;

//int Count(double[] a1, double key, double err)
//{
//    int res = 0;
//    a1.AsParallel().ForAll(x =>
//    {
//        if (Abs(x - key) <= err) 
//            Interlocked.Increment(ref res);
//    });
//    return res;
//}
//while (i++ < 1000) 
//{
//    var arr = RandomDoubleArray(Rand.Next(-5,  -2), Rand.Next(-1, 10), 15000);

//    arr.QuickSortRecursiveDesc();
//    var key = arr[100] + 0.01;
//    var c = Count(arr, key, 0.01);
//    var t = arr.BinarySearchDesc(key, closest: ClosestResults.All, error: 0.1 /*, left: 2, right: 28*/);

//    if (t.Item2 - t.Item1 + 1 != c)
//    {
//        if (t.Item1 >= 0)
//        {
//            WriteLine($"arr[{t.Item1}] = {arr[t.Item1]} key = {key} ({arr[t.Item1] - key})");
//            WriteLine($"arr[{t.Item2}] = {arr[t.Item2]} key = {key} ({key - arr[t.Item2]})");
//        }
//        //arr.PrintArray();t.Item1
//        WriteLine($"{t}; шаг: {i - 1}; count = {c}");
//        break;
//    }
//    if(i%100==0) {WriteLine(t); }

//    //arr.QuickSortRecursiveDesc().PrintArray();
//    //var key = Convert.ToDouble(ReadLine());
//    //WriteLine(arr.BinarySearchDesc(key, closest: ClosestResults.All, error: 1/*, left: 2, right: 28*/));
//}
//WriteLine("****");
//ReadKey();
//#endregion

//#region Min <-> Max
//var a = UniqueIntRandomArray(-10, 50, 10);
//WriteLine("Исходный массив:");
//a.PrintArray();
//a.MinMaxSwap();
//a.PrintArray();
//WriteLine("[в массиве переставлены местами максимальное и минимальное значения]");
//#endregion

#region Sort
const int tests = 100000;
var finalReport = "*****\nИТОГО:";

#region Methods 
void Sort(Func<int[], int[]> sort, int[]? array = null, bool unique = true)
{
    string name = sort.GetMethodInfo().Name;
    bool desc = name.EndsWith("Desc");

    WriteLine($"\n{name}:");
    if (array is null)
    {
        array = unique
            ? UniqueIntRandomArray(-10, 50, 10)
            : RandomIntArray(-10, 50, 10);
        array.PrintArray();
    }
    var result = sort(array);
    result.PrintArray();
    WriteLine($"[массив отсортирован - {(desc ? result.IsSortedDesc() : result.IsSorted())}]");

    array = Array.Empty<int>();

    try
    {
        if (array != sort(array)) throw new Exception("Пустой массив не сработал.");
        WriteLine("Пустой массив - OK!");
    }
    catch (Exception e)
    {
        WriteLine("Пустой массив - ERROR:");
        WriteLine(e);
    }

    array = new[] { 1 };

    try
    {
        if (array[0] != sort(array)[0]) throw new Exception($"Единичный массив не сработал.({array[0]})");
        WriteLine("Единичный массив - OK!");

    }
    catch (Exception e)
    {
        WriteLine(e);
    }
}

(TimeSpan, string) Test(Func<int[], int[]> sort)
{
    Stopwatch sw = new();
    
    string name = sort.GetMethodInfo().Name;
    bool desc = name.EndsWith("Desc");
    for (var i = 0; i < tests; i++)
    {
        var array = RandomIntArray(
            Rand.Next(-200000, -500),
            Rand.Next(500, 200000),
            10000);
        sw.Start();
        var sorted = sort(array);
        sw.Stop();
        if (!desc && !sorted.IsSorted())
        {
            WriteLine($"[шаг - {i}]: ");
            sorted.PrintArray();
            break;
        }
        if (desc && !sorted.IsSortedDesc())
        {
            WriteLine($"[шаг - {i}]: ");
            sorted.PrintArray();
            break;
        }

        if (i == tests - 1) WriteLine($"*****\n!!!{name}Test - OK!!!");
    }
    return (sw.Elapsed, sort.GetMethodInfo().Name);
}
void SortTest(Func<int[], int[]> sort)
{
    Sort(sort);
    var test = Test(sort);
    WriteLine($"[время тестирования = {test.Item1}; среднее время = {(int)(test.Item1.TotalMicroseconds / tests)}мкс]");
    finalReport +=
        $"\n{test.Item2}: время тестирования = {test.Item1}; среднее время = {(int)(test.Item1.TotalMicroseconds / tests)}мкс";
}
#endregion

#region SortTests
//Sort(SortExtensions.BogoSort, a);
//Sort(SortExtensions.BogoSortDesc, a);
SortTest(SortExtensions.BubbleSort);
SortTest(SortExtensions.BubbleSortDesc);
SortTest(SortExtensions.ShakerSort);
SortTest(SortExtensions.ShakerSortDesc);
SortTest(SortExtensions.InsertionSort);
SortTest(SortExtensions.InsertionSortDesc);
//SortTest(SortExtensions.StoogeSort<int>);
//SortTest(SortExtensions.StoogeSortDesc<int>);
SortTest(SortExtensions.PancakeSort);
SortTest(SortExtensions.PancakeSortDesc);
SortTest(SortExtensions.ShellSort);
SortTest(SortExtensions.ShellSortDesc);
SortTest(SortExtensions.MergeSort);
SortTest(SortExtensions.MergeSortDesc);
SortTest(SortExtensions.SelectionSort);
SortTest(SortExtensions.SelectionSortDesc);
SortTest(SortExtensions.QuickSortRecursive);
SortTest(SortExtensions.QuickSort);
SortTest(SortExtensions.QuickSortDesc);
SortTest(SortExtensions.QuickSortRecursiveDesc);
SortTest(SortExtensions.GnomeSort);
SortTest(SortExtensions.GnomeSortDesc);
SortTest(SortExtensions.TreeSort);
SortTest(SortExtensions.TreeSortDesc);
SortTest(SortExtensions.CombSort);
SortTest(SortExtensions.CombSortDesc);
SortTest(SortExtensions.CountingSort);
SortTest(SortExtensions.CountingSortDesc);
SortTest(SortExtensions.IntroSort);
SortTest(SortExtensions.IntroSortDesc);

WriteLine(finalReport);
#endregion

#endregion

ReadKey();