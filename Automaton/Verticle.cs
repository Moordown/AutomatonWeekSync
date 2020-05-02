using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automaton
{
    public class Verticle : IEquatable<Verticle>
    {
        public bool[] State { get; }
        public int Count { get; }

        public Verticle(bool[] state)
        {
            State = state;
            Count = State.Sum(s => s ? 1 : 0);
        }
        
        public override int GetHashCode()
        {
            return (State != null ? GetHashCodeFromState() : -1);
        }

        private int GetHashCodeFromState()
        {
            int res = 0;
            int mult = 1;
            foreach (var s in State)
            {
                if (s)
                    res += mult;
                mult *= 10;
            }

            return res;
        }

        public bool Equals(Verticle other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return GetHashCode().Equals(other.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Verticle) obj);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var (s, i) in State.Select((s, i) => (s, i)))
                if (s)
                    sb.Append($" {i}");

            return sb.ToString();
        }
    }
}