using System.Reflection;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace UmlDesignBasics.Tests
{
    [TestFixture]
    public class SimpleClass6Tests
    {
        private Type classType;

        [SetUp]
        public void SetUp()
        {
            var assembly = typeof(CreatingSimpleClass2).Assembly;
            this.classType = assembly.GetType("UmlDesignBasics.SimpleClass6");
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
            Assert.AreEqual(0, this.classType.GetFields(BindingFlags.Instance | BindingFlags.Public).Length);
            Assert.AreEqual(8, this.classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Length);

            Assert.AreEqual(0, this.classType.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).Length);
            Assert.AreEqual(8, this.classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).Length);
            Assert.AreEqual(0, this.classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).Length);

            var flags = BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            Assert.AreEqual(1, this.classType.GetConstructors(flags).Length);
            Assert.AreEqual(0, this.classType.GetEvents(flags).Length);
            Assert.AreEqual(0, this.classType.GetProperties(flags).Length);
        }

        [TestCase("intField", typeof(int))]
        [TestCase("longField", typeof(long))]
        [TestCase("floatField", typeof(float))]
        [TestCase("doubleField", typeof(double))]
        [TestCase("charField", typeof(char))]
        [TestCase("booleanField", typeof(bool))]
        [TestCase("stringField", typeof(string))]
        [TestCase("objectField", typeof(object))]
        public void HasRequiredField(string fieldName, Type expectedType)
        {
            var fieldInfo = this.classType.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);

            Assert.NotNull(fieldInfo);
            Assert.AreEqual(expectedType, fieldInfo.FieldType);
            Assert.IsTrue(fieldInfo.FieldType == expectedType);
        }

        [TestCase("GetInteger", typeof(int), ExpectedResult = 754)]
        [TestCase("GetLong", typeof(long), ExpectedResult = 721)]
        [TestCase("GetFloat", typeof(float), ExpectedResult = -76.67F)]
        [TestCase("GetDouble", typeof(double), ExpectedResult = 372.127)]
        [TestCase("GetChar", typeof(char), ExpectedResult = 'e')]
        [TestCase("GetBoolean", typeof(bool), ExpectedResult = true)]
        [TestCase("GetString", typeof(string), ExpectedResult = "ghi")]
        [TestCase("GetObject", typeof(object), ExpectedResult = typeof(float))]
        public object HasGetMethod(string methodName, Type expectedReturnType)
        {
            var methodInfo = this.classType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public);

            Assert.NotNull(methodInfo);
            Assert.AreEqual(expectedReturnType, methodInfo.ReturnType);

            var instance = Activator.CreateInstance(this.classType);
            var result = methodInfo.Invoke(instance, Array.Empty<object>());
            Assert.NotNull(result);

            return result;
        }
    }
}
