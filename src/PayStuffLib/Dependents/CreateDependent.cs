namespace PayStuffLib.Dependents
{
    using System;
    using Core;
    using Data;

    public class CreateDependent : Command
    {
        private readonly Func<Guid> idGenerator;
        private readonly SavePerson savePerson;
        private readonly IBus bus;

        public CreateDependent(Func<Guid> idGenerator, SavePerson savePerson, IBus bus)
        {
            this.idGenerator = idGenerator;
            this.savePerson = savePerson;
            this.bus = bus;
        }

        public Func<DependentCreated> Message =  () => new DependentCreated(); 

        public virtual void Run(Guid employeeId, Dependent dependent)
        {
            savePerson.Run(employeeId, idGenerator(), dependent.Name);

            var message = Message();
            message.Id = dependent.Id;
            bus.Publish(message);
        }
    }
}