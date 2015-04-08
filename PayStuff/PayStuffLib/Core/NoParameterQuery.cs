namespace PayStuffLib.Core
{
    public abstract class NoParameterQuery<TResult> : IQuery
    {
        public abstract TResult Get();
    }
}