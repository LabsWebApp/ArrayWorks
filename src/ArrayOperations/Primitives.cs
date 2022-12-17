namespace ArrayOperations;

/// <summary>
/// Статические методы для помощи в создании массивов со случайным набором элементов
/// </summary>
public static class Primitives
{
    private static Random? _rand;

    /// <summary>
    /// Singleton for a Random-instance
    /// </summary>
    public static Random Rand
    {
        get
        {
            _rand ??= new Random(DateTime.Now.Millisecond); 
            return _rand;
        }
    }

    /// <summary>
    /// Создание случайным образом массива с элементами типа System.Int32, заданной длины,
    /// с заданными диапазоном возможных значений элементов массива.
    /// </summary>
    /// <param name="min">минимально возможное значение элемента в массиве</param>
    /// <param name="max">максимально возможное значение элемента в массиве</param>
    /// <param name="length">длина массива</param>
    /// <param name="random">экземпляр класса System.Random;
    /// по-умолчанию: null (метод возьмёт экземпляр из свойства ArrayOperations.Primitives.Random)</param>
    /// <returns>случайный массив с элементами типа System.Int32</returns>
    /// <exception cref="ArgumentException"></exception>
    public static int[] RandomIntArray(int min, int max, int length, Random? random = null)
    {
        if (length < 1) throw new ArgumentOutOfRangeException(nameof(length),
            "Длина массива не может быть < 1");
        if (min > ++max) throw new ArgumentOutOfRangeException(
            $"{nameof(min)} or/and {nameof(max)}",
            "Не верно задан диапазон: min > max");

        var result = new int[length];

        if (min == max)
        {
            for (var i = 0; i < length; i++) result[i] = min;
            return result;
        }

        random ??= Rand;
        for (var i = 0; i < length; i++) result[i] = random.Next(min, max);
        return result;
    }

    /// <summary>
    /// Создание случайным образом массива с элементами типа System.Int32, заданной длины,
    /// с заданными диапазоном возможных значений элементов массива.
    /// </summary>
    /// <param name="min">минимально возможное значение элемента в массиве</param>
    /// <param name="max">максимально возможное значение элемента в массиве</param>
    /// <param name="length">длина массива</param>
    /// <param name="random">экземпляр класса System.Random;
    /// по-умолчанию: null (метод возьмёт экземпляр из свойства ArrayOperations.Primitives.Random)</param>
    /// <returns>случайный массив с элементами типа System.Int32</returns>
    /// <exception cref="ArgumentException"></exception>
    public static int[] UniqueIntRandomArray(int min, int max, int length, Random? random = null)
    {
        if (length < 1) throw new ArgumentOutOfRangeException(nameof(length),
            "Длина массива не может быть < 1");
        if (min > max++) throw new ArgumentOutOfRangeException(
            $"{nameof(min)} or/and {nameof(max)}",
            "Не верно задан диапазон: min > max");
        if (max - min < length) throw new ArgumentOutOfRangeException(nameof(length), 
            "Диапазон не позволяет создать уникальный список: (max - min) < length");
        random ??= Rand;

        var result = new int[length];
        
        var hasNotZero = min <= 0 && max >= 0;

        for (var i = 0; i < length; i++)
        {
            int res;
            do
            {
                res = random.Next(min, max);
                if (!hasNotZero || res != 0) continue;
                hasNotZero = false;
                break;
            } while (result.ArrayContains(res));
            result[i] = res;
        }
        return result;
    }

    /// <summary>
    /// Создание случайным образом массива с элементами типа System.Double, заданной длины,
    /// с заданными диапазоном возможных значений элементов массива.
    /// </summary>
    /// <param name="min">минимально возможное значение элемента в массиве</param>
    /// <param name="max">максимально возможное значение элемента в массиве</param>
    /// <param name="length">длина массива</param>
    /// <param name="random">экземпляр класса System.Random;
    /// по-умолчанию: null (метод возьмёт экземпляр из свойства ArrayOperations.Primitives.Random)</param>
    /// <returns>случайный массив с элементами типа System.Double</returns>
    /// <exception cref="ArgumentException"></exception>
    public static double[] RandomDoubleArray(int min, int max, int length, Random? random = null)
    { 
        if (length < 1) throw new ArgumentOutOfRangeException(nameof(length),
            "Длина массива не может быть < 1");
        if (min > max) throw new ArgumentOutOfRangeException(
            $"{nameof(min)} or/and {nameof(max)}",
            "Не верно задан диапазон: min > max");

        var result = new double[length];

        if (min == max)
        {
            for (var i = 0; i < length; i++) result[i] = min;
            return result;
        }

        random ??= Rand;
        for (var i = 0; i < length; i++) result[i] = min + random.NextDouble() * (max - min);
        return result;
    }

    /// <summary>
    /// Создание случайным образом массива с элементами типа System.Double, заданной длины,
    /// с заданными диапазоном возможных значений элементов массива.
    /// </summary>
    /// <param name="min">минимально возможное значение элемента в массиве</param>
    /// <param name="max">максимально возможное значение элемента в массиве</param>
    /// <param name="length">длина массива</param>
    /// <param name="random">экземпляр класса System.Random;
    /// по-умолчанию: null (метод возьмёт экземпляр из свойства ArrayOperations.Primitives.Random)</param>
    /// <returns>случайный массив с элементами типа System.Double</returns>
    /// <exception cref="ArgumentException"></exception>
    public static double[] UniqueDoubleRandomArray(double min, double max, int length, Random? random = null)
    {
        if (length < 1) throw new ArgumentOutOfRangeException(nameof(length),
            "Длина массива не может быть < 1");
        if (min >= max) throw new ArgumentOutOfRangeException(
            $"{nameof(min)} or/and {nameof(max)}",
            "Не верно задан диапазон: min > max");
        random ??= Rand;

        var result = new double[length];

        var hasNotZero = min <= 0 && max >= 0;

        for (var i = 0; i < length; i++)
        {
            double res;
            do
            {
                res = min + random.NextDouble() * (max - min);
                if (!hasNotZero || res != 0) continue;
                hasNotZero = false;
                break;
            } while (result.ArrayContains(res));
            result[i] = res;
        }
        return result;
    }

    /// <summary>
    /// Создаёт функцию - строгого сравнение двух чисел, учитывая убывание и возрастание
    /// </summary>
    /// <typeparam name="TNumber">тип сравниваемых чисел</typeparam>
    /// <param name="greaterFirst">true - если первое число должно быть больше при "desc" равным false,
    /// и должно быть меньше при "desc" равным true, чем второе число;
    /// false - если первое число должно быть меньше при "desc" равным false,
    /// и должно быть больше при "desc" равным true, чем второе число</param>
    /// <param name="desc">true - убывание; false - возрастание</param>
    /// <returns>функция строгого сравнения</returns>
    private static Func<TNumber, TNumber, bool> GreaterLess<TNumber>
        (bool greaterFirst, bool desc)
        where TNumber : INumber<TNumber> => (greaterFirst, desc) switch
    {
        (true, false) => (x, y) => x > y,
        (true, true) => (x, y) => y > x,
        (false, false) => (x, y) => x < y,
        (false, true) => (x, y) => y < x
    };

    /// <summary>
    /// Создаёт функцию - сравнение двух чисел, учитывая убывание и возрастание
    /// </summary>
    /// <typeparam name="TNumber">тип сравниваемых чисел</typeparam>
    /// <param name="greaterFirst">true - если первое число должно быть больше или равным при "desc" равным false,
    /// и должно быть меньше или равным при "desc" равным true, чем второе число;
    /// false - если первое число должно быть меньше или равным при "desc" равным false,
    /// и должно быть больше или равным при "desc" равным true, чем второе число</param>
    /// <param name="desc">true - убывание; false - возрастание</param>
    /// <returns>функция сравнения</returns>
    private static Func<TNumber, TNumber, bool> GreaterLessEqual<TNumber>
        (bool greaterFirst, bool desc)
        where TNumber : INumber<TNumber> => (greaterFirst, desc) switch
    {
        (true, false) => (x, y) => x >= y,
        (true, true) => (x, y) => y >= x,
        (false, false) => (x, y) => x <= y,
        (false, true) => (x, y) => y <= x
    };

    public static Func<TNumber, TNumber, bool> Greater<TNumber>(bool desc)
        where TNumber : INumber<TNumber> => desc
        ? (x, y) => y > x : (x, y) => x > y;
    public static Func<TNumber, TNumber, bool> GreaterEqual<TNumber>(bool desc)
        where TNumber : INumber<TNumber> => desc
        ? (x, y) => y >= x : (x, y) => x >= y;
    public static Func<TNumber, TNumber, bool> Less<TNumber>(bool desc)
        where TNumber : INumber<TNumber> => desc
        ? (x, y) => y < x : (x, y) => x < y;
    public static Func<TNumber, TNumber, bool> LessEqual<TNumber>(bool desc)
        where TNumber : INumber<TNumber> => desc
        ? (x, y) => y <= x : (x, y) => x <= y;
}