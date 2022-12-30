using System.Reflection;
using NUnit.Framework;

// ReSharper disable once PossibleNullReferenceException
namespace UmlDesignBasics.Tests
{
    [TestFixture]
    public class CreatingSimpleClass15Tests
    {
        [Test]
        public void CreateSimpleClass15WithDefaultValues_ReturnsNewObject()
        {
            object obj = CreatingSimpleClass15.CreateSimpleClass15WithDefaultValues();

            Assert.IsNotNull(obj);

            var flags = BindingFlags.Instance | BindingFlags.Public;

            var property = obj.GetType().GetProperty("IntValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(12354, property.GetValue(obj));

            property = obj.GetType().GetProperty("LongValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(-12134L, property.GetValue(obj));

            property = obj.GetType().GetProperty("FloatValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(-12846.973F, property.GetValue(obj));

            property = obj.GetType().GetProperty("DoubleValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(12923.6374, property.GetValue(obj));

            property = obj.GetType().GetProperty("CharValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual('j', property.GetValue(obj));

            property = obj.GetType().GetProperty("BooleanValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(true, property.GetValue(obj));

            property = obj.GetType().GetProperty("StringValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual("pqrmno", property.GetValue(obj));

            property = obj.GetType().GetProperty("ObjectValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(null, property.GetValue(obj));
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        public void CreateSimpleClass15_ReturnsNewObject(int intValue)
        {
            object obj = CreatingSimpleClass15.CreateSimpleClass15(intValue);

            Assert.IsNotNull(obj);

            var flags = BindingFlags.Instance | BindingFlags.Public;

            var property = obj.GetType().GetProperty("IntValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(intValue, property.GetValue(obj));

            property = obj.GetType().GetProperty("LongValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(-12134L, property.GetValue(obj));

            property = obj.GetType().GetProperty("FloatValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(-12846.973F, property.GetValue(obj));

            property = obj.GetType().GetProperty("DoubleValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(12923.6374, property.GetValue(obj));

            property = obj.GetType().GetProperty("CharValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual('j', property.GetValue(obj));

            property = obj.GetType().GetProperty("BooleanValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(true, property.GetValue(obj));

            property = obj.GetType().GetProperty("StringValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual("pqrmno", property.GetValue(obj));

            property = obj.GetType().GetProperty("ObjectValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(null, property.GetValue(obj));
        }

        [TestCase(0.0)]
        [TestCase(1.1)]
        [TestCase(-1.1)]
        public void CreateSimpleClass15_ReturnsNewObject(double doubleValue)
        {
            object obj = CreatingSimpleClass15.CreateSimpleClass15(doubleValue);

            Assert.IsNotNull(obj);

            var flags = BindingFlags.Instance | BindingFlags.Public;

            var property = obj.GetType().GetProperty("IntValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(12354, property.GetValue(obj));

            property = obj.GetType().GetProperty("LongValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(-12134L, property.GetValue(obj));

            property = obj.GetType().GetProperty("FloatValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(-12846.973F, property.GetValue(obj));

            property = obj.GetType().GetProperty("DoubleValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(doubleValue, property.GetValue(obj));

            property = obj.GetType().GetProperty("CharValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual('j', property.GetValue(obj));

            property = obj.GetType().GetProperty("BooleanValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(true, property.GetValue(obj));

            property = obj.GetType().GetProperty("StringValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual("pqrmno", property.GetValue(obj));

            property = obj.GetType().GetProperty("ObjectValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(null, property.GetValue(obj));
        }

        [TestCase(0L, 'a')]
        [TestCase(1L, 'b')]
        [TestCase(-1L, 'c')]
        public void CreateSimpleClass15_ReturnsNewObject(long longValue, char charValue)
        {
            object obj = CreatingSimpleClass15.CreateSimpleClass15(longValue, charValue);

            Assert.IsNotNull(obj);

            var flags = BindingFlags.Instance | BindingFlags.Public;

            var property = obj.GetType().GetProperty("IntValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(12354, property.GetValue(obj));

            property = obj.GetType().GetProperty("LongValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(longValue, property.GetValue(obj));

            property = obj.GetType().GetProperty("FloatValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(-12846.973F, property.GetValue(obj));

            property = obj.GetType().GetProperty("DoubleValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(12923.6374, property.GetValue(obj));

            property = obj.GetType().GetProperty("CharValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(charValue, property.GetValue(obj));

            property = obj.GetType().GetProperty("BooleanValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(true, property.GetValue(obj));

            property = obj.GetType().GetProperty("StringValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual("pqrmno", property.GetValue(obj));

            property = obj.GetType().GetProperty("ObjectValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(null, property.GetValue(obj));
        }

        [TestCase(0.0F, true, null)]
        [TestCase(1.1F, true, typeof(CreatingSimpleClass15))]
        [TestCase(-1.1F, true, typeof(CreatingSimpleClass15))]
        public void CreateSimpleClass15_ReturnsNewObject(float floatValue, bool boolValue, object objectValue)
        {
            object obj = CreatingSimpleClass15.CreateSimpleClass15(floatValue, boolValue, objectValue);

            Assert.IsNotNull(obj);

            var flags = BindingFlags.Instance | BindingFlags.Public;

            var property = obj.GetType().GetProperty("IntValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(12354, property.GetValue(obj));

            property = obj.GetType().GetProperty("LongValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(-12134L, property.GetValue(obj));

            property = obj.GetType().GetProperty("FloatValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(floatValue, property.GetValue(obj));

            property = obj.GetType().GetProperty("DoubleValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(12923.6374, property.GetValue(obj));

            property = obj.GetType().GetProperty("CharValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual('j', property.GetValue(obj));

            property = obj.GetType().GetProperty("BooleanValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(boolValue, property.GetValue(obj));

            property = obj.GetType().GetProperty("StringValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual("pqrmno", property.GetValue(obj));

            property = obj.GetType().GetProperty("ObjectValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(objectValue, property.GetValue(obj));
        }
    }
}
