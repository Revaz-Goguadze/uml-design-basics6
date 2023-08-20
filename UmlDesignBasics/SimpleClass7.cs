// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Local

#nullable enable
#pragma warning disable S2933 // Fields that are only assigned in the constructor should be "readonly"
#pragma warning disable S107 // Methods should not have too many parameters
#pragma warning disable IDE0044 // Add readonly modifier

namespace UmlDesignBasics
{
    public class SimpleClass7
    {
        private int intField;
        private long longField;
        private float floatField;
        private double doubleField;
        private char charField;
        private bool booleanField;
        private string? stringField;
        private object? objectField;

        public SimpleClass7(int intField, long longField, float floatField, double doubleField, char charField, bool booleanField, string? stringField, object? objectField)
        {
            this.intField = intField;
            this.longField = longField;
            this.floatField = floatField;
            this.doubleField = doubleField;
            this.charField = charField;
            this.booleanField = booleanField;
            this.stringField = stringField;
            this.objectField = objectField;
        }

        public int GetInteger() => this.intField;

        public long GetLong() => this.longField;

        public float GetFloat() => this.floatField;

        public double GetDouble() => this.doubleField;

        public char GetChar() => this.charField;

        public bool GetBoolean() => this.booleanField;

        public string? GetString() => this.stringField;

        public object? GetObject() => this.objectField;
    }
}
