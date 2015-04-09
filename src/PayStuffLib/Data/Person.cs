namespace PayStuffLib.Data
{
    using System;
    using DapperExtensions.Mapper;

    public class Person
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public string Name { get; set; }
    }

    public sealed class PersonMap : ClassMapper<Person>
    {
        public PersonMap()
        {
            Table("");

            Map(person => person.Id).Key(KeyType.Guid);
            AutoMap();
        }
    }
}