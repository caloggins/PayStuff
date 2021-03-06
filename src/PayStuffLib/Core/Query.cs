﻿namespace PayStuffLib.Core
{
    public abstract class Query<TParameter, TResult> : IQuery
    {
        public abstract TResult Get(TParameter parameter);
    }
}