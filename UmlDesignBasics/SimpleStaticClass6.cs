// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Global
#pragma warning disable CA1810
#pragma warning disable S3963 // "static" fields should be initialized inline

namespace UmlDesignBasics
{
    public static class SimpleStaticClass6
    {
        public static readonly object IntType;
        public static readonly object LongType;
        public static readonly object FloatType;
        public static readonly object DoubleType;
        public static readonly object CharType;
        public static readonly object BooleanType;
        public static readonly object StringType;

        static SimpleStaticClass6()
        {
            IntType = typeof(int);
            LongType = typeof(long);
            FloatType = typeof(float);
            DoubleType = typeof(double);
            CharType = typeof(char);
            BooleanType = typeof(bool);
            StringType = typeof(string);
        }
    }
}
