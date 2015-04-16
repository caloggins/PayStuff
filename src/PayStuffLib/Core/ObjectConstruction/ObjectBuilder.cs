namespace PayStuffLib.Core.ObjectConstruction
{
    using System;
    using System.Collections.Generic;

    public class ObjectBuilder<TToBuild> : IObjectBuilder<TToBuild>
        where TToBuild : class , new()
    {
        private readonly List<Action<TToBuild>> setters = new List<Action<TToBuild>>();

        public IObjectBuilder<TToBuild> With(Action<TToBuild> setter)
        {
            setters.Add(setter);
            return this;
        }

        public TToBuild Build()
        {
            var thing = new TToBuild();
            setters.ForEach(action => action(thing));
            return thing;
        }
    }
}