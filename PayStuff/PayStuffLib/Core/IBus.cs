namespace PayStuffLib.Core
{
    public interface IBus
    {
        void Publish<TEvent>(TEvent @evemt);
    }
}