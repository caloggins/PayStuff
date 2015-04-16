namespace PayStuffLib.Core.ObjectConstruction
{
    using System;

    public interface IObjectBuilder<out TToBuild>
        where TToBuild : class, new()
    {
        IObjectBuilder<TToBuild> With(Action<TToBuild> setter);
        TToBuild Build();
    }
}