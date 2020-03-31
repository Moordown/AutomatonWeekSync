using System.Collections.Generic;
using System.Linq;

namespace Automata
{
    public class TwoCharAutomaton
    {
        protected byte?[] aTransition;
        protected byte?[] bTransition;
        public int N { get; }

        public TwoCharAutomaton(int n)
        {
            N = n;
            aTransition = new byte?[n];
            bTransition = new byte?[n];
        }

        public void Syncronize(out byte[] syncWord)
        {
            var mask = Enumerable.Range(0, N).Select(_ => true).ToArray();
            _Syncronize(mask, out var syncList);
            syncList.Reverse();
            syncWord = syncList.Select(s => s == Character.A ? (byte)0 : (byte)1).ToArray();
        }

        private bool _Syncronize(bool[] from, out List<Character> syncList)
        {
            syncList = null;
            var sum = from.Sum(i => i ? 1 : 0);
            if (sum == 0)
                return false;
            if (sum == 1)
            {
                syncList = new List<Character>();
                return true;
            }

            if (_Syncronize(PerformTransition(from, Character.A), out syncList))
            {
                syncList.Add(Character.A);
                return true;
            }

            if (_Syncronize(PerformTransition(@from, Character.B), out syncList))
            {
                syncList.Add(Character.B);
                return true;
            }
            return false;
        }

        private bool[] PerformTransition(bool[] from, Character chr)
        {
            var res = new bool[N];
            var transition = aTransition;
            if (chr == Character.B)
                transition = bTransition;
            transition
                .Where((s, i) => s != null && from[i])
                .Select(s => res[s.Value] = true)
                .Count();
            return res;
        }
    }
}