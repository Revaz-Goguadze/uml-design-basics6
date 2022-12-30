using System.Reflection;
using NUnit.Framework;

namespace UmlDesignBasics.Tests
{
    [TestFixture]
    public class SimpleStaticClass6Tests
    {
        private Type classType;

        [SetUp]
        public void SetUp()
        {
            var assembly = typeof(CreatingSimpleClass2).Assembly;
            this.classType = assembly.GetType("UmlDesignBasics.SimpleStaticClass6");
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

            Assert.AreEqual(1, this.classType.GetConstructors(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Length);
            Assert.AreEqual(0, this.classType.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Length);

            var flags = BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            Assert.AreEqual(0, this.classType.GetMethods(flags | BindingFlags.DeclaredOnly).Length);
            Assert.AreEqual(0, this.classType.GetProperties(flags).Length);
            Assert.AreEqual(0, this.classType.GetEvents(flags).Length);
        }

        [TestCase("IntType", ExpectedResult = typeof(int))]
        [TestCase("LongType", ExpectedResult = typeof(long))]
        [TestCase("FloatType", ExpectedResult = typeof(float))]
        [TestCase("DoubleType", ExpectedResult = typeof(double))]
        [TestCase("CharType", ExpectedResult = typeof(char))]
        [TestCase("BooleanType", ExpectedResult = typeof(bool))]
        [TestCase("StringType", ExpectedResult = typeof(string))]
        public object HasRequiredField(string fieldName)
        {
            // Act
            var fieldInfo = this.classType.GetField(fieldName, BindingFlags.Static | BindingFlags.Public);

            // Assert
            Assert.NotNull(fieldInfo);
            Assert.IsTrue(fieldInfo.IsInitOnly);
            Assert.AreEqual(typeof(object), fieldInfo.FieldType);

            var value = fieldInfo.GetValue(null);
            return value;
        }
    }
}
