namespace Core
{
    public interface IMapper<TSource, TTarget>
    {
        TTarget Map(TSource source);
    }

    public interface IMapper<TSource1, TSource2, TTarget>
    {
        TTarget Map(TSource1 source1, TSource2 source2);
    }
}