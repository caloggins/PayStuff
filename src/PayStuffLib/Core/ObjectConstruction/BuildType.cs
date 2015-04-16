namespace PayStuffLib.Core.ObjectConstruction
{
    public class BuildType<TThingToBuild>
        where TThingToBuild : class, new()
    {
        public static IObjectBuilder<TThingToBuild> Setup()
        {
            return new ObjectBuilder<TThingToBuild>();
        }
    }
}