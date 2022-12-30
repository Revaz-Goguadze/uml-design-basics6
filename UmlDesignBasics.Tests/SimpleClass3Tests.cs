using System.Reflection;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace UmlDesignBasics.Tests
{
    [TestFixture]
    public class SimpleClass3Tests
    {
        private Type classType;

        [SetUp]
        public void SetUp()
        {
            var assembly = typeof(CreatingSimpleClass2).Assembly;
            this.classType = assembly.GetType("UmlDesignBasics.SimpleClass3");
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
            Assert.AreEqual(0, this.classType.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).Length);
            Assert.AreEqual(8, this.classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).Length);
            Assert.AreEqual(0, this.classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).Length);

            var flags = BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            Assert.AreEqual(0, this.classType.GetFields(flags).Length);
            Assert.AreEqual(1, this.classType.GetConstructors(flags).Length);
            Assert.AreEqual(0, this.classType.GetEvents(flags).Length);
            Assert.AreEqual(0, this.classType.GetProperties(flags).Length);
        }

        [TestCase("GetInteger", typeof(int), ExpectedResult = int.MaxValue)]
        [TestCase("GetLong", typeof(long), ExpectedResult = long.MinValue)]
        [TestCase("GetFloat", typeof(float), ExpectedResult = float.Epsilon)]
        [TestCase("GetDouble", typeof(double), ExpectedResult = double.NaN)]
        [TestCase("GetChar", typeof(char), ExpectedResult = 'c')]
        [TestCase("GetBoolean", typeof(bool), ExpectedResult = true)]
        [TestCase("GetString", typeof(string), ExpectedResult = "abcdef")]
        public object HasRequiredMethod(string methodName, Type expectedReturnType)
        {
            var methodInfo = this.classType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public);
            Assert.NotNull(methodInfo);
            Assert.AreEqual(expectedReturnType, methodInfo.ReturnType);

            var instance = Activator.CreateInstance(this.classType);
            var result = methodInfo.Invoke(instance, Array.Empty<object>());

            Assert.NotNull(result);
            return result;
        }

        [Test]
        public void HasGetObjectMethod()
        {
            var methodInfo = this.classType.GetMethod("GetObject", BindingFlags.Instance | BindingFlags.Public);

            Assert.NotNull(methodInfo);
            Assert.IsFalse(methodInfo.IsStatic);
            Assert.AreEqual(typeof(object), methodInfo.ReturnType);

            var instance = Activator.CreateInstance(this.classType);
            var result = methodInfo.Invoke(instance, Array.Empty<object>());

            Assert.NotNull(result);
            Assert.AreEqual(typeof(object), result.GetType());
        }
    }
}
