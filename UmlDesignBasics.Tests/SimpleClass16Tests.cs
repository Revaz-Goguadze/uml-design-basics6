using System.Reflection;
using NUnit.Framework;

// ReSharper disable PossibleNullReferenceException
// ReSharper disable InconsistentNaming
namespace UmlDesignBasics.Tests
{
    [TestFixture]
    public class SimpleClass16Tests
    {
        private static readonly object[][] ConstructorData =
        {
            new object[]
            {
                new[] { typeof(int), typeof(long), typeof(float), typeof(double), typeof(char), typeof(bool), typeof(string), typeof(object) },
                new object[] { 0, 0L, 0.0F, 0.0, 'a', true, string.Empty, null },
            },
        };

        private Type classType;

        [SetUp]
        public void SetUp()
        {
            var assembly = typeof(CreatingSimpleClass2).Assembly;
            this.classType = assembly.GetType("UmlDesignBasics.SimpleClass16");
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
            Assert.AreEqual(8, this.classType.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Length);
            Assert.AreEqual(0, this.classType.GetFields(BindingFlags.Instance | BindingFlags.Public).Length);
            Assert.AreEqual(8, this.classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Length);

            Assert.AreEqual(0, this.classType.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).Length);
            Assert.AreEqual(8, this.classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).Length);
            Assert.AreEqual(0, this.classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).Length);

            Assert.AreEqual(0, this.classType.GetConstructors(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Length);
            Assert.AreEqual(1, this.classType.GetConstructors(BindingFlags.Instance | BindingFlags.Public).Length);
            Assert.AreEqual(0, this.classType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).Length);

            Assert.AreEqual(0, this.classType.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Length);
            Assert.AreEqual(8, this.classType.GetProperties(BindingFlags.Instance | BindingFlags.Public).Length);
            Assert.AreEqual(0, this.classType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic).Length);

            var flags = BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            Assert.AreEqual(0, this.classType.GetEvents(flags).Length);
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

        [TestCaseSource(nameof(ConstructorData))]
        public void HasConstructor(Type[] parameterTypes, object[] constructorArguments)
        {
            var constructorInfo = this.classType.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, parameterTypes, null);
            Assert.NotNull(constructorInfo);

            var instance = constructorInfo.Invoke(constructorArguments);
            Assert.NotNull(instance);

            this.TestObjectProperty(instance, "IntValue", typeof(int), constructorArguments[0]);
            this.TestObjectProperty(instance, "LongValue", typeof(long), constructorArguments[1]);
            this.TestObjectProperty(instance, "FloatValue", typeof(float), constructorArguments[2]);
            this.TestObjectProperty(instance, "DoubleValue", typeof(double), constructorArguments[3]);
            this.TestObjectProperty(instance, "CharValue", typeof(char), constructorArguments[4]);
            this.TestObjectProperty(instance, "BooleanValue", typeof(bool), constructorArguments[5]);
            this.TestObjectProperty(instance, "StringValue", typeof(string), constructorArguments[6]);
            this.TestObjectProperty(instance, "ObjectValue", typeof(object), constructorArguments[7]);
        }

        [TestCase("IntValue", typeof(int), 0)]
        [TestCase("LongValue", typeof(long), 0L)]
        [TestCase("FloatValue", typeof(float), 0.0F)]
        [TestCase("DoubleValue", typeof(double), 0.0)]
        [TestCase("CharValue", typeof(char), 'a')]
        [TestCase("BooleanValue", typeof(bool), true)]
        [TestCase("StringValue", typeof(string), "")]
        [TestCase("ObjectValue", typeof(object), null)]
        public void HasProperty(string propertyName, Type expectedPropertyType, object expectedValue)
        {
            var propertyInfo = this.classType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);

            Assert.NotNull(propertyInfo);
            Assert.AreEqual(expectedPropertyType, propertyInfo.PropertyType);

            var instance = Activator.CreateInstance(this.classType, new object[] { 0, 0L, 0.0F, 0.0, 'a', true, string.Empty, null });
            var actualValue = propertyInfo.GetValue(instance);

            Assert.AreEqual(expectedValue, actualValue);
        }

        private void TestObjectProperty(object instance, string propertyName, Type propertyType, object expectedValue)
        {
            var propertyInfo = this.classType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
            Assert.NotNull(propertyInfo);
            Assert.AreEqual(propertyType, propertyInfo.PropertyType);
            Assert.IsTrue(propertyInfo.GetMethod.IsPublic);

            var actualValue = propertyInfo.GetValue(instance);
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
