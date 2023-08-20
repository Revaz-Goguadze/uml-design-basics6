// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable InconsistentNaming
#pragma warning disable IDE0044 // Add readonly modifier

namespace UmlDesignBasics
{
    public static class SimpleStaticClass4
    {
        private static int intField = 212;
        private static long longField = -232;
        private static float floatField = 2.12f;
        private static double doubleField = 2.121;
        private static char charField = 'b';
        private static bool booleanField = true;
        private static string stringField = "def";
        private static object objectField = typeof(SimpleStaticClass4);

        public static int GetInteger()
        {
            return intField;
        }

        public static long GetLongInteger()
        {
            return longField;
        }

        public static float GetFloat()
        {
            return floatField;
        }

        public static double GetDouble()
        {
            return doubleField;
        }

        public static char GetChar()
        {
            return charField;
        }

        public static bool GetBoolean()
        {
            return booleanField;
        }

        public static string GetString()
        {
            return stringField;
        }

        public static object GetObject()
        {
            return objectField;
        }
    }
}
