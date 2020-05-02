using System;

namespace Automaton
{
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 10;

            for (var n = 4; n <= N; ++n)
            {
                Console.WriteLine($"\nVertex count: {n}");
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
                    Console.WriteLine($"\n{automaton}: ({fullSyncWord.Length}){fullSyncWord}");                    
                    
                    for (var i = 0; i < n; ++i)
                    {
                        var syncWordForA = string.Join("", aut.NullTransition(C.A, i).PartialSync() ?? new C[] { });
                        var syncWordForB = string.Join("", aut.NullTransition(C.B, i).PartialSync() ?? new C[] { });
                        if (syncWordForA.Length > 0)
                            Console.WriteLine($"{automaton} without A{i}: ({syncWordForA.Length}){syncWordForA}");
                        if (syncWordForB.Length > 0)
                            Console.WriteLine($"{automaton} without B{i}: ({syncWordForB.Length}){syncWordForB}");
                    }
                }
            }
        }
    }
}