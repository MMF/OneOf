namespace OneOf;

public class OneOf<T1, T2, T3>
{
    private readonly T1 valueOfT1;
    private readonly T2 valueOfT2;
    private readonly T3 valueOfT3;

    public OneOf(T1 value) => valueOfT1 = value;
    public OneOf(T2 value) => valueOfT2 = value;
    public OneOf(T3 value) => valueOfT3 = value;

    public static implicit operator OneOf<T1, T2, T3>(T1 value) =>
        new OneOf<T1, T2, T3>(value);

    public static implicit operator OneOf<T1, T2, T3>(T2 value) =>
        new OneOf<T1, T2, T3>(value);

    public static implicit operator OneOf<T1, T2, T3>(T3 value) =>
        new OneOf<T1, T2, T3>(value);

    public Tout Match<Tout>(Func<T1, Tout> f1, Func<T2, Tout> f2, Func<T3, Tout> f3)
        where Tout : class
    {
        if (valueOfT1 is not null) return f1(valueOfT1);
        if (valueOfT2 is not null) return f2(valueOfT2);
        if (valueOfT3 is not null) return f3(valueOfT3);

        throw new InvalidOperationException("Invalid Match!");
    }
}
