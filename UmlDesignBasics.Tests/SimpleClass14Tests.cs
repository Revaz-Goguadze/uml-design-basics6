using System.Reflection;
using NUnit.Framework;

// ReSharper disable PossibleNullReferenceException
// ReSharper disable InconsistentNaming
namespace UmlDesignBasics.Tests
{
    [TestFixture]
    public class SimpleClass14Tests
    {
        private static readonly object[][] CreateMethodData =
        {
            new object[]
            {
                Array.Empty<Type>(),
                Array.Empty<object>(),
                new object[] { -1132, -11537L, 11369.321F, 11867.3854, 'i', true, "pqr", null },
            },
            new object[]
            {
                new[] { typeof(int) },
                new object[] { 0 },
                new object[] { 0, -11537L, 11369.321F, 11867.3854, 'i', true, "pqr", null },
            },
            new object[]
            {
                new[] { typeof(int) },
                new object[] { -1 },
                new object[] { -1, -11537L, 11369.321F, 11867.3854, 'i', true, "pqr", null },
            },
            new object[]
            {
                new[] { typeof(int) },
                new object[] { 1 },
                new object[] { 1, -11537L, 11369.321F, 11867.3854, 'i', true, "pqr", null },
            },
            new object[]
            {
                new[] { typeof(int), typeof(long) },
                new object[] { 0, 0L },
                new object[] { 0, 0L, 11369.321F, 11867.3854, 'i', true, "pqr", null },
            },
            new object[]
            {
                new[] { typeof(int), typeof(long) },
                new object[] { 0, -1L },
                new object[] { 0, -1L, 11369.321F, 11867.3854, 'i', true, "pqr", null },
            },
            new object[]
            {
                new[] { typeof(int), typeof(long) },
                new object[] { 0, 1L },
                new object[] { 0, 1L, 11369.321F, 11867.3854, 'i', true, "pqr", null },
            },
            new object[]
            {
                new[] { typeof(int), typeof(long), typeof(float) },
                new object[] { 0, 0L, 0.0F },
                new object[] { 0, 0L, 0.0F, 11867.3854, 'i', true, "pqr", null },
            },
            new object[]
            {
                new[] { typeof(int), typeof(long), typeof(float) },
                new object[] { 0, 0L, 1.1F },
                new object[] { 0, 0L, 1.1F, 11867.3854, 'i', true, "pqr", null },
            },
            new object[]
            {
                new[] { typeof(int), typeof(long), typeof(float) },
                new object[] { 0, 0L, -1.1F },
                new object[] { 0, 0L, -1.1F, 11867.3854, 'i', true, "pqr", null },
            },
            new object[]
            {
                new[] { typeof(int), typeof(long), typeof(float), typeof(double) },
                new object[] { 0, 0L, 0.0F, 0.0 },
                new object[] { 0, 0L, 0.0F, 0.0, 'i', true, "pqr", null },
            },
            new object[]
            {
                new[] { typeof(int), typeof(long), typeof(float), typeof(double) },
                new object[] { 0, 0L, 0.0F, -1.1 },
                new object[] { 0, 0L, 0.0F, -1.1, 'i', true, "pqr", null },
            },
            new object[]
            {
                new[] { typeof(int), typeof(long), typeof(float), typeof(double) },
                new object[] { 0, 0L, 0.0F, 1.1 },
                new object[] { 0, 0L, 0.0F, 1.1, 'i', true, "pqr", null },
            },
            new object[]
            {
                new[] { typeof(int), typeof(long), typeof(float), typeof(double), typeof(char) },
                new object[] { 0, 0L, 0.0F, 0.0, 'a' },
                new object[] { 0, 0L, 0.0F, 0.0, 'a', true, "pqr", null },
            },
            new object[]
            {
                new[] { typeof(int), typeof(long), typeof(float), typeof(double), typeof(char) },
                new object[] { 0, 0L, 0.0F, 0.0, 'b' },
                new object[] { 0, 0L, 0.0F, 0.0, 'b', true, "pqr", null },
            },
            new object[]
            {
                new[] { typeof(int), typeof(long), typeof(float), typeof(double), typeof(char), typeof(bool) },
                new object[] { 0, 0L, 0.0F, 0.0, 'a', false },
                new object[] { 0, 0L, 0.0F, 0.0, 'a', false, "pqr", null },
            },
            new object[]
            {
                new[] { typeof(int), typeof(long), typeof(float), typeof(double), typeof(char), typeof(bool) },
                new object[] { 0, 0L, 0.0F, 0.0, 'a', true },
                new object[] { 0, 0L, 0.0F, 0.0, 'a', true, "pqr", null },
            },
            new object[]
            {
                new[] { typeof(int), typeof(long), typeof(float), typeof(double), typeof(char), typeof(bool), typeof(string) },
                new object[] { 0, 0L, 0.0F, 0.0, 'a', true, string.Empty },
                new object[] { 0, 0L, 0.0F, 0.0, 'a', true, string.Empty, null },
            },
            new object[]
            {
                new[] { typeof(int), typeof(long), typeof(float), typeof(double), typeof(char), typeof(bool), typeof(string) },
                new object[] { 0, 0L, 0.0F, 0.0, 'a', true, "abc" },
                new object[] { 0, 0L, 0.0F, 0.0, 'a', true, "abc", null },
            },
        };

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
            this.classType = assembly.GetType("UmlDesignBasics.SimpleClass14");
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

            Assert.AreEqual(9, this.classType.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).Length);
            Assert.AreEqual(8, this.classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).Length);
            Assert.AreEqual(8, this.classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).Length);

            Assert.AreEqual(0, this.classType.GetConstructors(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Length);
            Assert.AreEqual(0, this.classType.GetConstructors(BindingFlags.Instance | BindingFlags.Public).Length);
            Assert.AreEqual(1, this.classType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).Length);

            Assert.AreEqual(0, this.classType.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Length);
            Assert.AreEqual(8, this.classType.GetProperties(BindingFlags.Instance | BindingFlags.Public).Length);
            Assert.AreEqual(0, this.classType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic).Length);

            Assert.AreEqual(0, this.classType.GetEvents(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Length);
        }

        [TestCaseSource(nameof(CreateMethodData))]
        public void HasCreateMethod(Type[] parameterTypes, object[] methodArguments, object[] propertyValues)
        {
            var methodInfo = this.classType.GetMethod("Create", BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly, null, parameterTypes, null);
            Assert.NotNull(methodInfo);

            var instance = methodInfo.Invoke(null, methodArguments);
            Assert.NotNull(instance);

            this.TestObjectProperty(instance, "IntValue", typeof(int), propertyValues[0]);
            this.TestObjectProperty(instance, "LongValue", typeof(long), propertyValues[1]);
            this.TestObjectProperty(instance, "FloatValue", typeof(float), propertyValues[2]);
            this.TestObjectProperty(instance, "DoubleValue", typeof(double), propertyValues[3]);
            this.TestObjectProperty(instance, "CharValue", typeof(char), propertyValues[4]);
            this.TestObjectProperty(instance, "BooleanValue", typeof(bool), propertyValues[5]);
            this.TestObjectProperty(instance, "StringValue", typeof(string), propertyValues[6]);
            this.TestObjectProperty(instance, "ObjectValue", typeof(object), propertyValues[7]);
        }

        [TestCaseSource(nameof(ConstructorData))]
        public void HasConstructor(Type[] parameterTypes, object[] constructorArguments)
        {
            var constructorInfo = this.classType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, parameterTypes, null);
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

        private void TestObjectProperty(object instance, string propertyName, Type propertyType, object expectedValue)
        {
            var propertyInfo = this.classType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
            Assert.NotNull(propertyInfo);
            Assert.AreEqual(propertyType, propertyInfo.PropertyType);
            Assert.IsTrue(propertyInfo.GetMethod.IsPublic);
            Assert.IsTrue(propertyInfo.SetMethod.IsPrivate);

            var actualValue = propertyInfo.GetValue(instance);
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
