using System;
using System.IO;
using System.Net;
using System.Text;

namespace Automaton
{
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 10;
            var sb = new StringBuilder();
            for (var n = 4; n <= N; ++n)
            {
                sb.Append($"\nVertex count: {n}\n");
                foreach (var aut in new TwoCharAutomaton[]
                {
                    new DAutomaton(n),
                    new EAutomaton(n),
                    new CAutomaton(n),
                    new HAutomaton(n),
                    new GAutomaton(n),
                    new RAutomaton(n),
                    new VAutomaton(n),
                    new WAutomaton(n),
                })
                {
                    var automaton = aut.GetType().ToString().Split('.')[1];

                    var fullSyncWord = string.Join("", aut.Sync() ?? new C [] {});
                    sb.Append($"\n{automaton}: ({fullSyncWord.Length}){fullSyncWord}\n");                    
                    
                    for (var i = 0; i < n; ++i)
                    {
                        var syncResForA = aut.NullTransition(C.A, i).PartialSync();
                        var syncResForB = aut.NullTransition(C.B, i).PartialSync();
                        sb.Append($"{automaton} without A{i}: {syncResForA}\n");
                        sb.Append($"{automaton} without B{i}: {syncResForB}\n");
                    }
                }
            }
            File.WriteAllText("log.txt", sb.ToString());
            sb.Clear();
        }
    }
}