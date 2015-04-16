namespace PayStuffLib.Tests.Core
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;
    using PayStuffLib.Core;
    using PayStuffLib.Core.ObjectConstruction;

    public class BuilderTests
    {
        public class WhenAnObjectIsBuilt : BuilderTests
        {
            [Test]
            public void ItShouldNotBeNull()
            {
                var thing = GetThing();

                thing.Should().NotBeNull();
            }

            [Test]
            public void ItShouldAlwaysBeANewObject()
            {
                var thing1 = GetThing();

                var thing2 = GetThing();

                thing1.Should().NotBeSameAs(thing2);
            }
        }

        public class WhenAPropertyValueIsGiven : BuilderTests
        {
            [Test]
            public void ItShouldBeSetOnTheSubject()
            {
                var thing = GetThingWithSetProperty("foo");

                thing.Foo.Should().Be("foo");
            }
        }

        public class WhenAPropertyValueIsNotGiven : BuilderTests
        {
            [Test]
            public void ItShouldBeTheDefaultValue()
            {
                var thing = GetThing();

                thing.Bar.Should().Be(default(Guid));
            } 
        }

        private SampleThing GetThing()
        {
            var thing = BuildType<SampleThing>.Setup()
                .Build();

            return thing;
        }

        private SampleThing GetThingWithSetProperty(string propertyValue)
        {
            var thing = BuildType<SampleThing>.Setup()
                .With(t => t.Foo = propertyValue)
                .Build();

            return thing;
        }
    }

    public class SampleThing
    {
        public string Foo { get; set; }
        public Guid Bar { get; set; }
    }
}