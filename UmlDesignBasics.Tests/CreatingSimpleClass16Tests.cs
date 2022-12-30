using System.Reflection;
using NUnit.Framework;

// ReSharper disable once PossibleNullReferenceException
namespace UmlDesignBasics.Tests
{
    [TestFixture]
    public class CreatingSimpleClass16Tests
    {
        [Test]
        public void CreateSimpleClass16WithDefaultValues_ReturnsNewObject()
        {
            object obj = CreatingSimpleClass16.CreateSimpleClass16WithDefaultValues();

            Assert.IsNotNull(obj);

            var flags = BindingFlags.Instance | BindingFlags.Public;

            var property = obj.GetType().GetProperty("IntValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(-135914, property.GetValue(obj));

            property = obj.GetType().GetProperty("LongValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(138672L, property.GetValue(obj));

            property = obj.GetType().GetProperty("FloatValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(130124.58123F, property.GetValue(obj));

            property = obj.GetType().GetProperty("DoubleValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(-130521.71531, property.GetValue(obj));

            property = obj.GetType().GetProperty("CharValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual('k', property.GetValue(obj));

            property = obj.GetType().GetProperty("BooleanValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(false, property.GetValue(obj));

            property = obj.GetType().GetProperty("StringValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual("stuvwx", property.GetValue(obj));

            property = obj.GetType().GetProperty("ObjectValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(null, property.GetValue(obj));
        }

        [TestCase(0L)]
        [TestCase(1L)]
        [TestCase(-1L)]
        public void CreateSimpleClass16_ReturnsNewObject(long longValue)
        {
            object obj = CreatingSimpleClass16.CreateSimpleClass16(longValue);

            Assert.IsNotNull(obj);

            var flags = BindingFlags.Instance | BindingFlags.Public;

            var property = obj.GetType().GetProperty("IntValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(-135914, property.GetValue(obj));

            property = obj.GetType().GetProperty("LongValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(longValue, property.GetValue(obj));

            property = obj.GetType().GetProperty("FloatValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(130124.58123F, property.GetValue(obj));

            property = obj.GetType().GetProperty("DoubleValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(-130521.71531, property.GetValue(obj));

            property = obj.GetType().GetProperty("CharValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual('k', property.GetValue(obj));

            property = obj.GetType().GetProperty("BooleanValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(false, property.GetValue(obj));

            property = obj.GetType().GetProperty("StringValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual("stuvwx", property.GetValue(obj));

            property = obj.GetType().GetProperty("ObjectValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(null, property.GetValue(obj));
        }

        [TestCase(0.0F)]
        [TestCase(1.1F)]
        [TestCase(-1.1F)]
        public void CreateSimpleClass16_ReturnsNewObject(float floatValue)
        {
            object obj = CreatingSimpleClass16.CreateSimpleClass16(floatValue);

            Assert.IsNotNull(obj);

            var flags = BindingFlags.Instance | BindingFlags.Public;

            var property = obj.GetType().GetProperty("IntValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(-135914, property.GetValue(obj));

            property = obj.GetType().GetProperty("LongValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(138672L, property.GetValue(obj));

            property = obj.GetType().GetProperty("FloatValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(floatValue, property.GetValue(obj));

            property = obj.GetType().GetProperty("DoubleValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(-130521.71531, property.GetValue(obj));

            property = obj.GetType().GetProperty("CharValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual('k', property.GetValue(obj));

            property = obj.GetType().GetProperty("BooleanValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(false, property.GetValue(obj));

            property = obj.GetType().GetProperty("StringValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual("stuvwx", property.GetValue(obj));

            property = obj.GetType().GetProperty("ObjectValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(null, property.GetValue(obj));
        }

        [TestCase(0, true)]
        [TestCase(1, true)]
        [TestCase(-1, true)]
        public void CreateSimpleClass16_ReturnsNewObject(int intValue, bool boolValue)
        {
            object obj = CreatingSimpleClass16.CreateSimpleClass16(intValue, boolValue);

            Assert.IsNotNull(obj);

            var flags = BindingFlags.Instance | BindingFlags.Public;

            var property = obj.GetType().GetProperty("IntValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(intValue, property.GetValue(obj));

            property = obj.GetType().GetProperty("LongValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(138672L, property.GetValue(obj));

            property = obj.GetType().GetProperty("FloatValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(130124.58123F, property.GetValue(obj));

            property = obj.GetType().GetProperty("DoubleValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(-130521.71531, property.GetValue(obj));

            property = obj.GetType().GetProperty("CharValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual('k', property.GetValue(obj));

            property = obj.GetType().GetProperty("BooleanValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(boolValue, property.GetValue(obj));

            property = obj.GetType().GetProperty("StringValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual("stuvwx", property.GetValue(obj));

            property = obj.GetType().GetProperty("ObjectValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(null, property.GetValue(obj));
        }

        [TestCase(0.0, 'a', "")]
        [TestCase(1.1, 'b', "abc")]
        [TestCase(-1.1, 'c', "abcdef")]
        public void CreateSimpleClass16_ReturnsNewObject(double doubleValue, char charValue, string stringValue)
        {
            object obj = CreatingSimpleClass16.CreateSimpleClass16(doubleValue, charValue, stringValue);

            Assert.IsNotNull(obj);

            var flags = BindingFlags.Instance | BindingFlags.Public;

            var property = obj.GetType().GetProperty("IntValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(-135914, property.GetValue(obj));

            property = obj.GetType().GetProperty("LongValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(138672L, property.GetValue(obj));

            property = obj.GetType().GetProperty("FloatValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(130124.58123F, property.GetValue(obj));

            property = obj.GetType().GetProperty("DoubleValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(doubleValue, property.GetValue(obj));

            property = obj.GetType().GetProperty("CharValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(charValue, property.GetValue(obj));

            property = obj.GetType().GetProperty("BooleanValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(false, property.GetValue(obj));

            property = obj.GetType().GetProperty("StringValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(stringValue, property.GetValue(obj));

            property = obj.GetType().GetProperty("ObjectValue", flags);
            Assert.IsNotNull(property);
            Assert.AreEqual(null, property.GetValue(obj));
        }
    }
}
