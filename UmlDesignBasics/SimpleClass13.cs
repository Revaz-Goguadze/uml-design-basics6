// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable IntroduceOptionalParameters.Global
#pragma warning disable S107 // Methods should not have too many parameters

namespace UmlDesignBasics
{
    public class SimpleClass13
    {
        public SimpleClass13()
        : this(1087)
        {
        }

        public SimpleClass13(int intValue)
            : this(intValue, 10482L)
        {
        }

        public SimpleClass13(int intValue, long longValue)
            : this(intValue, longValue, -10387.05832f)
        {
        }

        public SimpleClass13(int intValue, long longValue, float floatValue)
            : this(intValue, longValue, floatValue, -10382.73521)
        {
        }

        public SimpleClass13(int intValue, long longValue, float floatValue, double doubleValue)
                    : this(intValue, longValue, floatValue, doubleValue, 'h')
        {
        }

        public SimpleClass13(int intValue, long longValue, float floatValue, double doubleValue, char charValue)
            : this(intValue, longValue, floatValue, doubleValue, charValue, false)
        {
        }

        public SimpleClass13(int intValue, long longValue, float floatValue, double doubleValue, char charValue, bool booleanValue)
            : this(intValue, longValue, floatValue, doubleValue, charValue, booleanValue, "ghimnojkl")
        {
        }

        public SimpleClass13(int intValue, long longValue, float floatValue, double doubleValue, char charValue, bool booleanValue, string stringValue)
            : this(intValue, longValue, floatValue, doubleValue, charValue, booleanValue, stringValue, null)
        {
        }

        public SimpleClass13(int intValue, long longValue, float floatValue, double doubleValue, char charValue, bool booleanValue, string stringValue, object? objectValue)
        {
            this.IntValue = intValue;
            this.LongValue = longValue;
            this.FloatValue = floatValue;
            this.DoubleValue = doubleValue;
            this.CharValue = charValue;
            this.BooleanValue = booleanValue;
            this.StringValue = stringValue;
            this.ObjectValue = objectValue;
        }

        public int IntValue { get; private set; }

        public long LongValue { get; private set; }

        public float FloatValue { get; private set; }

        public double DoubleValue { get; private set; }

        public char CharValue { get; private set; }

        public bool BooleanValue { get; private set; }

        public string? StringValue { get; private set; }

        public object? ObjectValue { get; private set; }
    }
}
