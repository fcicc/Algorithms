using System;
using System.Diagnostics.CodeAnalysis;

namespace Algorithms.FractionalKnapsack
{
    public struct Item : IEquatable<Item>, IComparable<Item>
    {
        public double Value { get; set; }
        public double Weight { get; set; }
        public bool IsFraction { get; set; }

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
                   Weight == other.Weight &&
                   IsFraction == other.IsFraction;
        }

        public int CompareTo([AllowNull] Item other)
        {
            var r1 = Value / Weight;
            var r2 = other.Value / other.Weight;
            return r1.CompareTo(r2);
        }

        public override int GetHashCode()
        {
            return (Value.GetHashCode() << 16) ^
                   (Weight.GetHashCode() << 8) ^
                   IsFraction.GetHashCode();
        }

        public override string ToString()
        {
            return $"{nameof(Value)} = {Value}, {nameof(Weight)} = {Weight}, {nameof(IsFraction)} = {IsFraction}";
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
