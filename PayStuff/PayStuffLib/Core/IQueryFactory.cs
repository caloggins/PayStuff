namespace PayStuffLib.Core
{
    public interface IQueryFactory
    {
        TQuery Create<TQuery>()
            where TQuery : IQuery;

        void Release(IQuery dead);
    }
}