namespace PayStuffLib.Dependents
{
    using System;
    using Core;
    using Data;

    public class CreateDependent : Command
    {
        private readonly SavePerson savePerson;
        private readonly IBus bus;

        public CreateDependent(SavePerson savePerson, IBus bus)
        {
            this.savePerson = savePerson;
            this.bus = bus;
        }

        public virtual void Run(Guid employeeId, Dependent dependent)
        {
            savePerson.Run(employeeId, dependent.Name);

            bus.Publish(new DependentCreated {Id = dependent.Id});
        }
    }
}