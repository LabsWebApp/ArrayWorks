using System.Text;

namespace ArrayOperations;

/// <summary>
/// Примитивы расширений для работы с массивами
/// </summary>
public static class ArrayPrimitiveExtensions
{  
    /// <summary>
    /// Определяет содержит ли массив чисел указанное число
    /// </summary>
    /// <param name="numbers">массив, в котором требуется найти число</param>
    /// <param name="number">число, которое требуется найти в массиве</param>
    /// <returns>true - если число найдено, в противном случае - false</returns>
    public static bool ArrayContains<TNumber>(this TNumber[] numbers, TNumber number)
        where TNumber : INumber<TNumber>
    {
        foreach (var num in numbers) if (number == num) return true;
        return false;
    }

    /// <summary>
    /// Конвертирует массив чисел в строку с возможностью вывода этой строки в консоль
    /// </summary>
    /// <param name="numbers">массив, который требуется конвертировать в строку</param>
    /// <param name="print">true (по умолчанию) - если необходим вывод на экран</param>
    /// <returns>строку с числами массива через пробел</returns>
    public static string PrintArray<TNumber>(this IEnumerable<TNumber> numbers, bool print = true)
        where TNumber : INumber<TNumber>
    {
        var sb = new StringBuilder();
        foreach (var item in numbers) sb.Append(item).Append(' ');
        var result = sb.ToString().TrimEnd(' ');
        if (print) Console.WriteLine(result);
        return result;
    }

    /// <summary>
    /// Варианты выбора индексов в списке найденных решений 
    /// </summary>
    public enum ClosestResults
    {
        /// <summary>
        /// индекс любого решения
        /// </summary>
        Any,

        /// <summary>
        /// минимальный индекс решения
        /// </summary>
        First,

        /// <summary>
        /// максимальный индекс решения
        /// </summary>
        Last, 

        /// <summary>
        /// индексы всех решений
        /// </summary>
        All
    }

    private delegate void Work(ref int m);
    public static readonly (int, int) NoResultTuple = (-1, -1);

    private static ValueTuple<int, int> BinarySearchBase<TNumber>(
        TNumber[] array, TNumber key, 
        int left, int right, 
        ClosestResults closes, 
        TNumber error, 
        bool desc)
    where TNumber : struct, INumber<TNumber>
    {
        if (array == Array.Empty<TNumber>()) 
            throw new ArgumentNullException(nameof(array), "Массив не может быть пустым");

        if (left < 0) left = 0;
        if (right < 0) right = array.Length - 1;

        if (right < left || right >= array.Length)
            throw new ArgumentOutOfRangeException($"{nameof(left)} or/and {nameof(right)}", 
                $"Нарушено одно или более условий: 0 <= {nameof(left)} <= {nameof(right)} < {nameof(array)}.Length");
        var closestNumbers = error < TNumber.Zero;
        if (closestNumbers) error = TNumber.Zero;

        var less = Less<TNumber>(desc);
        var lessEqual = LessEqual<TNumber>(desc);

        Func<TNumber, TNumber, bool> equals =
            error > TNumber.Zero
                ? (x, y) => Abs(x - y) <= error
                : (x, y) => x == y;


        ValueTuple<int, int> FindResults(int index)
        {
            if (error == TNumber.Zero && Abs(array[index] - key) != TNumber.Zero)
                return NoResultTuple;

            void Left(int x)
            {
                do
                {
                    var m = (left + x) >> 1;
                    if (equals(array[m], key)) x = m - 1;
                    else left = m + 1;
                } while (left <= x);
            }

            void Right(int x)
            {
                do
                {
                    var m = (x + right) >> 1;
                    if (equals(array[m], key)) x = m + 1;
                    else right = m - 1;
                } while (x <= right);
            }

            //bool Right(int x) => x <= right && equals(array[x], key);

            switch (closes)
            {
                case ClosestResults.Any:
                    return (index, index);
                case ClosestResults.First:
                    Left(index);
                    return (left, left);
                case ClosestResults.Last:
                    Right(index);
                    return (right, right);
                case ClosestResults.All:
                    Left(index);
                    Right(index);
                    return (left, right);
                default:
                    throw new ArgumentOutOfRangeException(nameof(closes), closes, null);
            }
        }

        if (left == right) return closestNumbers ? (left, right) : FindResults(left);

        if (closestNumbers)
        {
            if (lessEqual(key, array[left]))
            {
                key = array[left];
                return FindResults(left);
            }

            if (lessEqual(array[right], key))
            {
                key = array[right];
                return FindResults(right);
            }
        }

        int middle = 0, l = left, r = right;

        Work leftWork = closes is ClosestResults.All or ClosestResults.First
            ? (ref int m) =>
            {
                if (!equals(array[l], array[m])) left = m;
                l = m + 1;
            }
            : (ref int m) => l = m + 1;

        Work rightWork = closes is ClosestResults.All or ClosestResults.Last
            ? (ref int m) =>
            {
                if (!equals(array[r], array[m])) right = m;
                r = m - 1;
            }
            : (ref int m) => r = m - 1;

        do
        {
            middle = (l + r) >> 1;
            if (equals(key, array[middle])) return FindResults(middle);
            if (less(array[middle], key)) leftWork(ref middle);
            else rightWork(ref middle);
        } while (l <= r);

        if (!closestNumbers) return NoResultTuple;

        var delta = Abs(array[middle] - key);

        if (middle == left)
        {
            if (delta >= Abs(array[left + 1] - key))
                key = array[left++ + 1];
            else return (middle, middle);
            return FindResults( left);
        }

        if (middle == right)
        {
            if (delta >= Abs(array[right - 1] - key))
                key = array[right-- - 1];
            else return (middle, middle);
            return FindResults(right);
        }

        if (delta >= Abs(array[middle - 1] - key))
            key = array[middle-- - 1];
        else if (delta >= Abs(array[middle + 1] - key))
            key = array[middle++ + 1];
        else return (middle, middle);

        return FindResults(middle);
    }

    public static ValueTuple<int, int> BinarySearch<TNumber>(
        this TNumber[] array, TNumber key,
        int left = -1, int right = -1,
        ClosestResults closest = ClosestResults.Any,
        TNumber error = default)
        where TNumber : struct, INumber<TNumber> => BinarySearchBase(
        array, key, left, right, closest, error, false);

    public static ValueTuple<int, int> BinarySearchDesc<TNumber>(
        this TNumber[] array, TNumber key,
        int left = -1, int right = -1,
        ClosestResults closest = ClosestResults.Any,
        TNumber error = default)
        where TNumber : struct, INumber<TNumber> => BinarySearchBase(
        array, key, left, right, closest, error, true);

    public static TNumber Abs<TNumber>(TNumber x) 
        where TNumber : INumber<TNumber> => x < TNumber.Zero ? -x : x;
}