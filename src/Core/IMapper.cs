namespace Core
{
    public interface IMapper<TSource, TTarget>
    {
        TTarget Map(TSource source);
    }
}