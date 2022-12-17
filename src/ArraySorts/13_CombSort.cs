namespace ArraySorts;

/*
 * Сортировка расчёской (Comb sort) – алгоритм сортировки массива, является улучшенным
 * вариантом сортировки пузырьком, при этом, по скорости выполнения,
 * конкурирует с алгоритмом быстрой сортировки.
 * Основная идея сортировки расческой заключается в устранении так званых “черепах”
 * – маленьких значений в конце массива, которые существенно замедляют сортировку пузырьком.
 *
 * Алгоритм сортировки расческой.
 * В сортировке пузырьком всегда сравниваются два соседних элемента массива данных,
 * расстояние между ними равно единице. Основная идея сортировки расческой в
 * использовании большего расстояния между сравниваемыми элементами. При этом
 * первоначально необходимо брать большое расстояние, и постепенно уменьшать его,
 * по мере упорядочивания данных вплоть до единицы. Изначально сравнивается первый и
 * последний элемент массива, и на каждой итерации уменьшается разрыв между элементами
 * на фактор уменьшения. Итерации продолжаются до тех пор, пока разность индексов больше
 * единицы, а затем массив сортируется пузырьковой сортировкой.
 * Оптимальное значение фактора уменьшения равно 1/(1-e-φ) ≈ 1.247,
 * где е – основание натурального логарифма, а φ – золотое сечение.
 */
public static partial class SortExtensions
{
    //метод для генерации следующего шага
    private static int GetNextStep(int s)
    {
        s = s * 1000 / 1247;
        return s > 1 ? s : 1;
    }

    //Сортировка расчёской
    private static TNumber[] CombSortBase<TNumber>(TNumber[] array, bool desc)
        where TNumber : INumber<TNumber>
    {
        var arrayLength = array.Length;
        var currentStep = arrayLength - 1;

        var greater = Greater<TNumber>(desc);
        while (currentStep > 1)
        {
            for (var i = 0; i + currentStep < array.Length; i++)
                if (greater(array[i], array[i + currentStep])) 
                    array.Swap(i, i + currentStep);

            currentStep = GetNextStep(currentStep);
        }

        //сортировка пузырьком
        for (var i = 1; i < arrayLength; i++)
        {
            var swapFlag = false;
            for (var j = 0; j < arrayLength - i; j++)
            {
                if (greater(array[j], array[j + 1]))
                {
                    array.Swap(j, j + 1);
                    swapFlag = true;
                }
            }

            if (!swapFlag) break;
        }

        return array;
    }

    /// <summary>
    /// Сортировка расчёской, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный массив</returns>
    public static TNumber[] CombSort<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => CombSortBase(array, false);

    /// <summary>
    /// Сортировка расчёской, входящий массив будет отсортирован
    /// </summary>
    /// <param name="array">входящий массив</param>
    /// <returns>отсортированный по убыванию входящий массив</returns>
    public static TNumber[] CombSortDesc<TNumber>(this TNumber[] array)
        where TNumber : INumber<TNumber> => CombSortBase(array, true);
}