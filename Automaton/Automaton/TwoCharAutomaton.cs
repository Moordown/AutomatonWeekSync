using System;
using System.Collections.Generic;
using System.Linq;

namespace Automaton
{
    public class TwoCharAutomaton
    {
        protected int?[] aTransition;
        protected int?[] bTransition;
        public int N { get; }

        protected TwoCharAutomaton(int n)
        {
            N = n;
            aTransition = new int?[n];
            bTransition = new int?[n];
        }

        private readonly C[] _letters = {C.A, C.B};

        public IEnumerable<C> Sync()
        {
            var start = new Verticle(Enumerable.Range(0, N).Select(_ => true).ToArray());
            Verticle fin = null;
            var passed = new HashSet<Verticle> {start};
            var pred = new Dictionary<Verticle, Tuple<Verticle, C>>();
            var stack = new Stack<Verticle>();
            stack.Push(start);
            while (fin is null && stack.Count != 0)
            {
                var v = stack.Pop();
                foreach (var c in _letters)
                {
                    var u = PerformTransition(v, c);
                    if (u is null || passed.Contains(u))
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
            while (!fin.Equals(start))
            {
                var (v, c) = pred[fin];
                res.Add(c);
                fin = v;
            }

            res.Reverse();
            return res;
        }

        public IEnumerable<C> PartialSync()
        {
            // some checks
            return Sync();
        }

        public TwoCharAutomaton Copy()
        {
            return new TwoCharAutomaton(N)
            {
                aTransition = aTransition.ToArray(),
                bTransition = bTransition.ToArray()
            };
        }

        public TwoCharAutomaton NullTransition(C c, int from)
        {
            var a = Copy();
            var arr = c == C.A ? a.aTransition : a.bTransition;
            arr[from] = null;
            return a;
        }



        private Verticle PerformTransition(Verticle from, C chr)
        {
            var transition = aTransition;
            if (chr == C.B)
                transition = bTransition;
            if (transition.Any(s => s is null))
                return null;
            var res = new bool[N];
            transition
                .Where((s, i) => s != null && from.State[i])
                .Select(s => res[s.Value] = true)
                .Count();
            return new Verticle(res);
        }
    }
}