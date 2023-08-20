// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Local
#pragma warning disable S2933 // Fields that are only assigned in the constructor should be "readonly"
#pragma warning disable IDE0044 // Add readonly modifier

namespace UmlDesignBasics
{
    public class SimpleClass5
    {
        private int intField = -216;
        private long longField = -621;
        private float floatField = -54.62f;
        private double doubleField = -62.054;
        private char charField = 'd';
        private bool booleanField = true;
        private string stringField = "defabc";
        private object objectField = typeof(int);

        public int GetInteger() => this.intField;

        public long GetLong() => this.longField;

        public float GetFloat() => this.floatField;

        public double GetDouble() => this.doubleField;

        public char GetChar() => this.charField;

        public bool GetBoolean() => this.booleanField;

        public string GetString() => this.stringField;

        public object GetObject() => this.objectField;
    }
}
