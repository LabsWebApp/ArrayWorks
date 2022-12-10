namespace ArrayOperations;

public static class RandomSingleton
{
    private static Random? _random;
    public static Random R
    {
        get
        {
            _random ??= new Random(DateTime.Now.Microsecond); 
            return _random;
        }
    }
}