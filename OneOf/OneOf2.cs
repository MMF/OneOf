namespace OneOf;

public class OneOf<T1, T2>
{
    private readonly T1 valueOfT1;
    private readonly T2 valueOfT2;

    public OneOf(T1 value) => valueOfT1 = value;
    public OneOf(T2 value) => valueOfT2 = value;

    public static implicit operator OneOf<T1, T2>(T1 value) =>
        new OneOf<T1, T2>(value);

    public static implicit operator OneOf<T1, T2>(T2 value) =>
        new OneOf<T1, T2>(value);

    public static implicit operator T1(OneOf<T1, T2> oneOfObject) =>
        oneOfObject.valueOfT1;

    public static implicit operator T2(OneOf<T1, T2> oneOfObject) =>
        oneOfObject.valueOfT2;

    public Tout Match<Tout>(Func<T1, Tout> f1, Func<T2, Tout> f2)
        where Tout : class
    {
        if (valueOfT1?.Equals(default(T1)) == false) return f1(this.valueOfT1);
        if (valueOfT2?.Equals(default(T2)) == false) return f2(this.valueOfT2);

        throw new InvalidOperationException("Invalid Match!");
    }
}
