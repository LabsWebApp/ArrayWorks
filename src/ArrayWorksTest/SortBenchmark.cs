using BenchmarkDotNet.Attributes;

namespace ArrayWorksTest;

[MemoryDiagnoser]
[RankColumn]
public class SortBenchmark
{
    [Params(10, 1000, 30000)]
    public int Length;

    public double[] TestArray;

    [GlobalSetup]
    // RandomDoubleArray случайно заполняет
    public void SetArray() => TestArray = RandomDoubleArray(-500, 750, Length);

    [Benchmark(Description = "Sort")]
    public void SortTest()
    {
        Array.Sort(TestArray);
    }

    //[Benchmark(Description = "RQuick")]
    //public void QuickSortRecursiveTest()
    //{
    //    var x = TestArray.QuickSortRecursive();
    //}

    //[Benchmark(Description = "RQuick")]
    //public void QuickSortRecursiveTest()
    //{
    //    var x = TestArray.QuickSortRecursive();
    //}

    [Benchmark(Description = "Quick")]
    public void QuickSortTest()
    {
        var x = TestArray.QuickSort();
    }

    //[Benchmark(Description = "Shaker")]
    //public void ShakerSortTest()
    //{
    //    var x = TestArray.ShakerSort();
    //}

   [Benchmark(Description = "Insertion")]
    public void InsertionSortTest()
    {
        var x = TestArray.InsertionSort();
    }

    [Benchmark(Description = "Intro")]
    public void IntroSortTest()
    {
        var x = TestArray.IntroSort();
    }

    //[Benchmark(Description = "Shell")]
    //public void ShellSortTest()
    //{
    //    var x = TestArray.ShellSort();
    //}

    //[Benchmark(Description = "Merge")]
    //public void MergeSortTest()
    //{
    //    var x = TestArray.MergeSort();
    //}

    //[Benchmark(Description = "Selection")]
    //public void SelectionSortTest()
    //{
    //    var x = TestArray.SelectionSort();
    //}

    //[Benchmark(Description = "Tree")]
    //public void TreeSortTest()
    //{
    //    var x = TestArray.TreeSort();
    //}

    //[Benchmark(Description = "Counting")]
    //public void Counting()
    //{
    //    var x = TestArray.CountingSort();
    //}
}