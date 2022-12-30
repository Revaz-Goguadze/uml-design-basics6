using System.Reflection;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace UmlDesignBasics.Tests
{
    [TestFixture]
    public class SimpleClass4Tests
    {
        private static readonly object[][] Data =
        {
            new object[] { "GetInteger", "SetInteger", typeof(int), int.MaxValue },
            new object[] { "GetLong", "SetLong", typeof(long), long.MinValue },
            new object[] { "GetFloat", "SetFloat", typeof(float), float.Epsilon },
            new object[] { "GetDouble", "SetDouble", typeof(double), double.NaN },
            new object[] { "GetChar", "SetChar", typeof(char), 'A' },
            new object[] { "GetBoolean", "SetBoolean", typeof(bool), true },
            new object[] { "GetString", "SetString", typeof(string), "My String" },
            new object[] { "GetObject", "SetObject", typeof(object), new object() },
        };

        private Type classType;

        [SetUp]
        public void SetUp()
        {
            var assembly = typeof(CreatingSimpleClass2).Assembly;
            this.classType = assembly.GetType("UmlDesignBasics.SimpleClass4");
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
            Assert.AreEqual(16, this.classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).Length);
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

        [TestCase("GetInteger", typeof(int))]
        [TestCase("GetLong", typeof(long))]
        [TestCase("GetFloat", typeof(float))]
        [TestCase("GetDouble", typeof(double))]
        [TestCase("GetChar", typeof(char))]
        [TestCase("GetBoolean", typeof(bool))]
        [TestCase("GetString", typeof(string))]
        [TestCase("GetObject", typeof(object))]
        public void HasGetMethod(string methodName, Type expectedReturnType)
        {
            var methodInfo = this.classType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public);

            Assert.NotNull(methodInfo);
            Assert.AreEqual(expectedReturnType, methodInfo.ReturnType);
        }

        [TestCase("SetInteger", typeof(int))]
        [TestCase("SetLong", typeof(long))]
        [TestCase("SetFloat", typeof(float))]
        [TestCase("SetDouble", typeof(double))]
        [TestCase("SetChar", typeof(char))]
        [TestCase("SetBoolean", typeof(bool))]
        [TestCase("SetString", typeof(string))]
        [TestCase("SetObject", typeof(object))]
        public void HasSetMethod(string methodName, Type expectedArgumentType)
        {
            var methodInfo = this.classType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public);

            Assert.NotNull(methodInfo);
            Assert.AreEqual(typeof(void), methodInfo.ReturnParameter?.ParameterType);

            var parameters = methodInfo.GetParameters();
            Assert.AreEqual(1, parameters.Length);
            Assert.AreEqual(expectedArgumentType, parameters[0].ParameterType);
        }

        [TestCaseSource(nameof(Data))]
        public void SetGet(string getMethodName, string setMethodName, Type expectedType, object expectedValue)
        {
            var setMethodInfo = this.classType.GetMethod(setMethodName, BindingFlags.Instance | BindingFlags.Public);
            var getMethodInfo = this.classType.GetMethod(getMethodName, BindingFlags.Instance | BindingFlags.Public);

            Assert.NotNull(setMethodInfo);
            var setMethodParameters = setMethodInfo.GetParameters();
            Assert.AreEqual(1, setMethodParameters.Length);
            Assert.AreEqual(expectedType, setMethodParameters[0].ParameterType);
            Assert.NotNull(getMethodInfo);
            Assert.AreEqual(expectedType, getMethodInfo.ReturnType);

            var instance = Activator.CreateInstance(this.classType);
            setMethodInfo.Invoke(instance, new object[] { expectedValue });
            var result = getMethodInfo.Invoke(instance, Array.Empty<object>());

            Assert.NotNull(result);
            Assert.AreEqual(expectedValue, result);
        }
    }
}
