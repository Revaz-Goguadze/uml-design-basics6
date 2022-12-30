using System.Reflection;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace UmlDesignBasics.Tests
{
    [TestFixture]
    public class CreatingSimpleClass2Tests
    {
        [Test]
        public void CreateSimpleClass2_ReturnsNewObject()
        {
            var simpleClass = CreatingSimpleClass2.CreateSimpleClass2();

            Assert.IsNotNull(simpleClass);

            var field = simpleClass.GetType().GetField("IntField", BindingFlags.Instance | BindingFlags.Public);
            Assert.IsNotNull(field);
            Assert.AreEqual(-331, field.GetValue(simpleClass));

            field = simpleClass.GetType().GetField("FloatField", BindingFlags.Instance | BindingFlags.Public);
            Assert.IsNotNull(field);
            Assert.AreEqual(13.13F, field.GetValue(simpleClass));

            field = simpleClass.GetType().GetField("DoubleField", BindingFlags.Instance | BindingFlags.Public);
            Assert.IsNotNull(field);
            Assert.AreEqual(-31.31, field.GetValue(simpleClass));

            field = simpleClass.GetType().GetField("BooleanField", BindingFlags.Instance | BindingFlags.Public);
            Assert.IsNotNull(field);
            Assert.AreEqual(true, field.GetValue(simpleClass));

            field = simpleClass.GetType().GetField("longField", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsNotNull(field);
            Assert.AreEqual(default(long), field.GetValue(simpleClass));

            field = simpleClass.GetType().GetField("charField", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsNotNull(field);
            Assert.AreEqual(default(char), field.GetValue(simpleClass));

            field = simpleClass.GetType().GetField("stringField", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsNotNull(field);
            Assert.AreEqual(default(string), field.GetValue(simpleClass));

            field = simpleClass.GetType().GetField("objectField", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsNotNull(field);
            Assert.AreEqual(default(object), field.GetValue(simpleClass));
        }

        [Test]
        public void CreateSimpleClass2ObjectInitializer_ReturnsNewObject()
        {
            var simpleClass = CreatingSimpleClass2.CreateSimpleClass2ObjectInitializer();

            Assert.IsNotNull(simpleClass);

            var field = simpleClass.GetType().GetField("IntField", BindingFlags.Instance | BindingFlags.Public);
            Assert.IsNotNull(field);
            Assert.AreEqual(432, field.GetValue(simpleClass));

            field = simpleClass.GetType().GetField("FloatField", BindingFlags.Instance | BindingFlags.Public);
            Assert.IsNotNull(field);
            Assert.AreEqual(-42.31F, field.GetValue(simpleClass));

            field = simpleClass.GetType().GetField("DoubleField", BindingFlags.Instance | BindingFlags.Public);
            Assert.IsNotNull(field);
            Assert.AreEqual(43.12, field.GetValue(simpleClass));

            field = simpleClass.GetType().GetField("BooleanField", BindingFlags.Instance | BindingFlags.Public);
            Assert.IsNotNull(field);
            Assert.AreEqual(false, field.GetValue(simpleClass));

            field = simpleClass.GetType().GetField("longField", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsNotNull(field);
            Assert.AreEqual(default(long), field.GetValue(simpleClass));

            field = simpleClass.GetType().GetField("charField", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsNotNull(field);
            Assert.AreEqual(default(char), field.GetValue(simpleClass));

            field = simpleClass.GetType().GetField("stringField", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsNotNull(field);
            Assert.AreEqual(default(string), field.GetValue(simpleClass));

            field = simpleClass.GetType().GetField("objectField", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsNotNull(field);
            Assert.AreEqual(default(object), field.GetValue(simpleClass));
        }
    }
}
