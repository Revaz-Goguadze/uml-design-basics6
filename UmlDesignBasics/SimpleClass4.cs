// ReSharper disable InconsistentNaming

#nullable enable
namespace UmlDesignBasics
{
    public class SimpleClass4
    {
        private int intField;
        private long longField;
        private float floatField;
        private double doubleField;
        private char charField;
        private bool booleanField;
        private string? stringField;
        private object? objectField;

        public int GetInteger() => this.intField;

        public void SetInteger(int arg) => this.intField = arg;

        public long GetLong() => this.longField;

        public void SetLong(long arg) => this.longField = arg;

        public float GetFloat() => this.floatField;

        public void SetFloat(float arg) => this.floatField = arg;

        public double GetDouble() => this.doubleField;

        public void SetDouble(double arg) => this.doubleField = arg;

        public char GetChar() => this.charField;

        public void SetChar(char arg) => this.charField = arg;

        public bool GetBoolean() => this.booleanField;

        public void SetBoolean(bool arg) => this.booleanField = arg;

        public string? GetString() => this.stringField;

        public void SetString(string arg) => this.stringField = arg;

        public object? GetObject() => this.objectField;

        public void SetObject(object arg) => this.objectField = arg;
    }
}
