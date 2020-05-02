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

        public C[] Sync()
        {
            var start = new Verticle(Enumerable.Range(0, N).Select(_ => true).ToArray());
            Verticle fin = null;
            var passed = new HashSet<Verticle> {start};
            var pred = new Dictionary<Verticle, Tuple<Verticle, C>>();
            var collection = new Queue<Verticle>();
            collection.Enqueue(start);
            while (fin is null && collection.Count != 0)
            {
                var v = collection.Dequeue();
                foreach (var c in _letters)
                {
                    var u = PerformTransition(v, c);
                    if (u is null || passed.Contains(u))
                        continue;
                    pred[u] = Tuple.Create(v, c);
                    if (u.Count == 1)
                        fin = u;
                    passed.Add(u);
                    collection.Enqueue(u);
                }
            }

            if (fin is null)
                return new C [] {};

            var res = new List<C>();
            while (!fin.Equals(start))
            {
                var (v, c) = pred[fin];
                res.Add(c);
                fin = v;
            }

            res.Reverse();
            return res.ToArray();
        }

        public SyncResult PartialSync()
        {
            // some checks
            return new SyncResult
            {
                Word = Sync(),
                Hint = "DFS"
            };
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
            foreach (var (t, i) in from.State.Select((t, i) => (t, i)))
                if (t && transition[i] is null) 
                    return null;
            var res = new bool[N];
            foreach (var (s, i) in from.State.Select((s, i) => (s, i)))
                if (s)
                    res[transition[i].Value] = true;
            return new Verticle(res);
        }
    }
}