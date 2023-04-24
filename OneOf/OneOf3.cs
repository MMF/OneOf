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

    public static implicit operator T1(OneOf<T1, T2, T3> oneOfObject) =>
        oneOfObject.valueOfT1;

    public static implicit operator T2(OneOf<T1, T2, T3> oneOfObject) =>
        oneOfObject.valueOfT2;

    public static implicit operator T3(OneOf<T1, T2, T3> oneOfObject) =>
        oneOfObject.valueOfT3;

    public Tout Match<Tout>(Func<T1, Tout> f1, Func<T2, Tout> f2, Func<T3, Tout> f3)
        where Tout : class
    {
        if (valueOfT1?.Equals(default(T1)) == false) return f1(valueOfT1);
        if (valueOfT2?.Equals(default(T2)) == false) return f2(valueOfT2);
        if (valueOfT3?.Equals(default(T3)) == false) return f3(valueOfT3);

        throw new InvalidOperationException("Invalid Match!");
    }
}
