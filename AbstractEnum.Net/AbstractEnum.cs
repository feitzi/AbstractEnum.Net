using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace AbstractEnumDotNet {
    [Serializable]
    [DataContract(Namespace = "https://github.com/feitzi/AbstractEnum.Net")]
    public abstract class AbstractEnum<TEnumeration> : AbstractEnum<TEnumeration, string>
        where TEnumeration : AbstractEnum<TEnumeration, string> {

        protected AbstractEnum(string value) : base(value) {
        }

    }


    [Serializable]
    [DebuggerDisplay("{" + nameof(Value) + "}")]
    [DataContract(Namespace = "https://github.com/feitzi/AbstractEnum.Net")]
    public abstract class AbstractEnum<TEnumeration, TValue> : IComparable<TEnumeration>, IEquatable<TEnumeration>
        where TEnumeration : AbstractEnum<TEnumeration, TValue>
        where TValue : IComparable {

        private static readonly Lazy<TEnumeration[]> Enumerations = new Lazy<TEnumeration[]>(GetEnumerations);

        [DataMember(Order = 0)]
        private readonly TValue value;

        protected AbstractEnum(TValue value) {
            if (value == null) throw new ArgumentNullException(nameof(value));

            this.value = value;
        }

        public TValue Value => value;

        public int CompareTo(TEnumeration other) {
            return Value.CompareTo(other == default(TEnumeration) ? default(TValue) : other.Value);
        }

        public bool Equals(TEnumeration other) {
            return other != null && ValueEquals(other.Value);
        }

        public sealed override string ToString() {
            return Value.ToString();
        }

        public static TEnumeration[] GetAll() {
            return Enumerations.Value;
        }

        private static TEnumeration[] GetEnumerations() {
            Type enumerationType = typeof(TEnumeration);
            return enumerationType
                  .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                  .Where(info => enumerationType.IsAssignableFrom(info.FieldType))
                  .Select(info => info.GetValue(null))
                  .Cast<TEnumeration>()
                  .ToArray();
        }

        public override bool Equals(object obj) {
            return Equals(obj as TEnumeration);
        }

        public override int GetHashCode() {
            return Value.GetHashCode();
        }

        public static bool operator ==(AbstractEnum<TEnumeration, TValue> left,
                                       AbstractEnum<TEnumeration, TValue> right) {
            return Equals(left, right);
        }

        public static bool operator !=(AbstractEnum<TEnumeration, TValue> left,
                                       AbstractEnum<TEnumeration, TValue> right) {
            return !Equals(left, right);
        }

        private static bool TryParse(Func<TEnumeration, bool> predicate, out TEnumeration result) {
            result = GetAll().FirstOrDefault(predicate);
            return result != null;
        }

        public static bool TryParse(TValue value, out TEnumeration result) {
            return TryParse(e => e.ValueEquals(value), out result);
        }

        public static TEnumeration Parse(TValue value) {
            bool parsingSuccessful = TryParse(e => e.ValueEquals(value), out TEnumeration result);
            if (parsingSuccessful) return result;

            throw new ArgumentOutOfRangeException($"Value {value} is not a valid type of {typeof(TValue).FullName}");
        }

        protected virtual bool ValueEquals(TValue value) {
            return Value.Equals(value);
        }

    }

}