namespace PayStuffLib.Data
{
    using System;
    using System.Data;
    using Core.ObjectConstruction;
    using DapperExtensions;

    public interface ISavePerson
    {
        void Run(Guid employeeId, Guid dependentId, string dependentName);
    }

    public class SavePerson : ISavePerson
    {
        private readonly IDbConnection connection;
        private readonly IObjectBuilder<Person> builder;

        public SavePerson(IDbConnection connection, IObjectBuilder<Person> builder)
        {
            this.connection = connection;
            this.builder = builder;
        }

        public void Run(Guid employeeId, Guid dependentId, string dependentName)
        {
            var person = builder.With(_ => _.Id = dependentId)
                .With(_ => _.ParentId = employeeId)
                .With(_ => _.Name = dependentName)
                .Build();

            connection.Insert(person);
        }
    }
}