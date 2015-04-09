namespace PayStuffLib.Core
{
    public interface IBus
    {
        void Publish<TMessage>(TMessage message)
            where TMessage : class;
    }
}