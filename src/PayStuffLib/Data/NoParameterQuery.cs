namespace PayStuffLib.Data
{
    public abstract class NoParameterQuery<TResult> : IQuery
    {
        public abstract TResult Get();
    }
}