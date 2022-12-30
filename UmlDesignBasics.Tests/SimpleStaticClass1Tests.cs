using System.Reflection;
using NUnit.Framework;

namespace UmlDesignBasics.Tests
{
    [TestFixture]
    public class SimpleStaticClass1Tests
    {
        private Type classType;

        [SetUp]
        public void SetUp()
        {
            var assembly = typeof(CreatingSimpleClass2).Assembly;
            this.classType = assembly.GetType("UmlDesignBasics.SimpleStaticClass1");
        }

        [Test]
        public void IsClass()
        {
            Assert.IsTrue(this.classType.IsClass);
        }

        [Test]
        public void IsStaticClass()
        {
            Assert.IsTrue(this.classType.IsAbstract);
            Assert.IsTrue(this.classType.IsSealed);
        }

        [Test]
        public void IsPublic()
        {
            Assert.IsTrue(this.classType.IsPublic);
        }

        [Test]
        public void InheritsObject()
        {
            Assert.AreEqual(typeof(object), this.classType.BaseType);
        }

        [Test]
        public void HasRequiredMembers()
        {
            var flags = BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            Assert.AreEqual(0, this.classType.GetFields(flags).Length);
            Assert.AreEqual(0, this.classType.GetMethods(flags | BindingFlags.DeclaredOnly).Length);
            Assert.AreEqual(0, this.classType.GetConstructors(flags).Length);
            Assert.AreEqual(0, this.classType.GetEvents(flags).Length);
            Assert.AreEqual(0, this.classType.GetProperties(flags).Length);
        }
    }
}
