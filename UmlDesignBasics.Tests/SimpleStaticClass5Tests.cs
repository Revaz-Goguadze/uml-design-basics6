using System.Reflection;
using NUnit.Framework;

namespace UmlDesignBasics.Tests
{
    [TestFixture]
    public class SimpleStaticClass5Tests
    {
        private Type classType;

        [SetUp]
        public void SetUp()
        {
            var assembly = typeof(CreatingSimpleClass2).Assembly;
            this.classType = assembly.GetType("UmlDesignBasics.SimpleStaticClass5");
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
            Assert.AreEqual(7, this.classType.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Length);
            Assert.AreEqual(0, this.classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Length);

            var flags = BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            Assert.AreEqual(0, this.classType.GetMethods(flags | BindingFlags.DeclaredOnly).Length);
            Assert.AreEqual(0, this.classType.GetConstructors(flags).Length);
            Assert.AreEqual(0, this.classType.GetProperties(flags).Length);
            Assert.AreEqual(0, this.classType.GetEvents(flags).Length);
        }

        [TestCase("BitsInByte", typeof(int), ExpectedResult = 8)]
        [TestCase("Pi", typeof(double), ExpectedResult = 3.14159653589793238)]
        [TestCase("SpeedOfLight", typeof(int), ExpectedResult = 300000)]
        [TestCase("Tau", typeof(float), ExpectedResult = 6.283185F)]
        [TestCase("NewLine", typeof(char), ExpectedResult = '\n')]
        [TestCase("BoolValue", typeof(bool), ExpectedResult = false)]
        [TestCase("HelloWorld", typeof(string), ExpectedResult = "Hello, world!")]
        public object HasRequiredField(string fieldName, Type expectedType)
        {
            // Act
            var fieldInfo = this.classType.GetField(fieldName, BindingFlags.Static | BindingFlags.Public);

            // Assert
            Assert.NotNull(fieldInfo);
            Assert.IsTrue(fieldInfo.IsStatic);
            Assert.AreEqual(expectedType, fieldInfo.FieldType);

            var value = fieldInfo.GetValue(null);
            return value;
        }
    }
}
