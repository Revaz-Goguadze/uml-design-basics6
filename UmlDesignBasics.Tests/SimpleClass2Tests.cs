using System.Reflection;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace UmlDesignBasics.Tests
{
    [TestFixture]
    public class SimpleClass2Tests
    {
        private Type classType;

        [SetUp]
        public void SetUp()
        {
            var assembly = typeof(CreatingSimpleClass2).Assembly;
            this.classType = assembly.GetType("UmlDesignBasics.SimpleClass2");
        }

        [Test]
        public void IsClass()
        {
            Assert.IsTrue(this.classType.IsClass);
        }

        [Test]
        public void IsNotStaticClass()
        {
            Assert.IsFalse(this.classType.IsAbstract);
            Assert.IsFalse(this.classType.IsSealed);
        }

        [Test]
        public void InheritsObject()
        {
            Assert.AreEqual(typeof(object), this.classType.BaseType);
        }

        [Test]
        public void HasRequiredMembers()
        {
            Assert.AreEqual(0, this.classType.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Length);
            Assert.AreEqual(4, this.classType.GetFields(BindingFlags.Instance | BindingFlags.Public).Length);
            Assert.AreEqual(4, this.classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Length);

            var flags = BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            Assert.AreEqual(0, this.classType.GetMethods(flags | BindingFlags.DeclaredOnly).Length);
            Assert.AreEqual(1, this.classType.GetConstructors(flags).Length);
            Assert.AreEqual(0, this.classType.GetEvents(flags).Length);
            Assert.AreEqual(0, this.classType.GetProperties(flags).Length);
        }

        [TestCase("IntField", typeof(int), true)]
        [TestCase("longField", typeof(long), false)]
        [TestCase("FloatField", typeof(float), true)]
        [TestCase("DoubleField", typeof(double), true)]
        [TestCase("charField", typeof(char), false)]
        [TestCase("BooleanField", typeof(bool), true)]
        [TestCase("stringField", typeof(string), false)]
        [TestCase("objectField", typeof(object), false)]
        public void HasRequiredField(string fieldName, Type expectedType, bool isPublic)
        {
            // Arrange
            BindingFlags flags = isPublic
                ? BindingFlags.Instance | BindingFlags.Public
                : BindingFlags.Instance | BindingFlags.NonPublic;

            // Act
            var fieldInfo = this.classType.GetField(fieldName, flags);

            // Assert
            Assert.NotNull(fieldInfo);
            Assert.IsFalse(fieldInfo.IsStatic);
            Assert.AreEqual(expectedType, fieldInfo.FieldType);
        }
    }
}
