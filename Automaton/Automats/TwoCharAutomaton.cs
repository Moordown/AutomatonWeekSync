using System;
using System.Collections.Generic;
using System.Linq;

namespace Automaton
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

        public C[] Letters = new[] {C.A, C.B};

        public IEnumerable<C> Sync()
        {
            var start = new Verticle(Enumerable.Range(0, N).Select(_ => true).ToArray());Enumerable.Range(0, N).Select(_ => true).ToArray();
            Verticle fin = null;
            var passed = new HashSet<Verticle> {start};
            var pred = new Dictionary<Verticle, Tuple<Verticle, C>>();
            var stack = new Stack<Verticle>();
            stack.Push(start);
            while (fin is null && stack.Count != 0)
            {
                var v = stack.Pop();
                foreach (var c in Letters)
                {
                    var u = PerformTransition(v, c);
                    if (passed.Contains(u))
                        continue;
                    pred[u] = Tuple.Create(v, c);
                    if (u.Count == 1)
                        fin = u;
                    passed.Add(u);
                    stack.Push(u);
                }
            }

            if (fin is null)
                return null;

            var res = new List<C>();
            while (fin != start)
            {
                var (v, c) = pred[fin];
                res.Add(c);
                fin = v;
            }
            res.Reverse();
            return res;
        }

        // private bool _Sync(bool[] from, out List<Character> syncList)
        // {
        //     syncList = null;
        //     var sum = from.Sum(i => i ? 1 : 0);
        //     if (sum == 0)
        //         return false;
        //     if (sum == 1)
        //     {
        //         syncList = new List<Character>();
        //         return true;
        //     }
        //
        //     if (_Sync(PerformTransition(from, Character.A), out syncList))
        //     {
        //         syncList.Add(Character.A);
        //         return true;
        //     }
        //
        //     if (_Sync(PerformTransition(@from, Character.B), out syncList))
        //     {
        //         syncList.Add(Character.B);
        //         return true;
        //     }
        //
        //     return false;
        // }

        private Verticle PerformTransition(Verticle from, C chr)
        {
            var res = new bool[N];
            var transition = aTransition;
            if (chr == C.B)
                transition = bTransition;
            transition
                .Where((s, i) => s != null && from.State[i])
                .Select(s => res[s.Value] = true)
                .Count();
            return new Verticle(res);
        }
    }
}