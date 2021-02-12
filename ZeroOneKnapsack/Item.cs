using System;
using System.Diagnostics.CodeAnalysis;

namespace Algorithms.ZeroOneKnapsack
{
    public struct Item : IEquatable<Item>
    {
        public int Value { get; set; }
        public int Weight { get; set; }

        public override bool Equals(object obj)
        {
            if (obj?.GetType() != typeof(Item))
            {
                return false;
            }

            return Equals((Item)obj);
        }

        public bool Equals([AllowNull] Item other)
        {
            return Value == other.Value &&
                   Weight == other.Weight;
        }

        public override int GetHashCode()
        {
            return (Value.GetHashCode() << 8) ^
                   Weight.GetHashCode();
        }

        public override string ToString()
        {
            return $"{nameof(Value)} = {Value}, {nameof(Weight)} = {Weight}";
        }

        public static bool operator ==(Item x, Item y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(Item x, Item y)
        {
            return !x.Equals(y);
        }
    }
}
