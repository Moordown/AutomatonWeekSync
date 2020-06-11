using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Automaton
{
    class Program
    {
        const int N = 12;

        static void Main(string[] args)
        {
            // AutomatsTest("автоматы из статьи.log");
            BaseAutomata("тесты на поиcк базиса с во всеми переходами. 12 вершин.txt");
        }

        static void BaseAutomata(string fname)
        {
            var sb = new StringBuilder();
            var aut = new VKAutomaton(N);
            var results = new List<SyncInfo>();
            for (var roadCount = 1; roadCount < N; ++roadCount)
            {
                for (var start = 0; start < N - roadCount; start++)
                {
                    Console.WriteLine($"{roadCount} {start}");
                    foreach (var syncInfo in PartialSync(aut.MakeCopy(), start, roadCount - 1))
                    {
                        syncInfo.RoadStarts.Add(start);
                        syncInfo.RoadStarts.Reverse();

                        results.Add(syncInfo);

                        sb.Append($"{syncInfo}\n");
                    }
                }
            }

            sb.Append("-------------------------------------------------------------------------------\n");
            foreach (var syncInfo in results.Where(si => si.SyncResult.Length != 0)
                .OrderByDescending(si => si.SyncResult.Length))
            {
                sb.Append($"{syncInfo}\n");
            }

            File.WriteAllText(fname, sb.ToString());
            sb.Clear();
        }

        struct SyncInfo
        {
            public SyncResult SyncResult;
            public List<int> RoadStarts;

            public override string ToString()
            {
                var sb = new StringBuilder();
                foreach (var roadStart in RoadStarts)
                {
                    sb.Append($"({roadStart}-{roadStart + 1})\t");
                }

                sb.Append($"\t{SyncResult}");
                return sb.ToString();
            }
        }

        static IEnumerable<SyncInfo> PartialSync(TwoCharAutomaton automaton, int roadStart,
            int roadCount)
        {
            if (roadCount == 0)
            {
                if (roadStart + 1 - 1 < N)
                {
                    automaton.aTransition[roadStart] = automaton.bTransition[roadStart];
                    automaton.bTransition[roadStart] = null;
                    yield return new SyncInfo
                    {
                        SyncResult = automaton.PartialSync(),
                        RoadStarts = new List<int>(),
                    };
                }

                yield break;
            }

            for (int newRoad = roadStart + 1; newRoad < N - 1 * (roadCount - 1); newRoad++)
            {
                var aut = automaton.MakeCopy();

                aut.aTransition[newRoad] = newRoad + 1;
                if (newRoad + 1 == N)
                    aut.aTransition[newRoad] = 0;

                foreach (var syncInfo in PartialSync(aut, newRoad, roadCount - 1))
                {
                    syncInfo.RoadStarts.Add(newRoad);
                    yield return syncInfo;
                }
            }
        }

        static void AutomatsTest(string fname)
        {
            var sb = new StringBuilder();
            foreach (var taut in new[]
            {
                typeof(DAutomaton),
                typeof(EAutomaton),
                typeof(E_Automaton),
                typeof(CAutomaton),
                typeof(HAutomaton),
                typeof(GAutomaton),
                typeof(RAutomaton),
                typeof(VAutomaton),
                typeof(WAutomaton),
            })
            {
                Console.WriteLine(taut);
                for (var n = 4; n <= N; ++n)
                {
                    var aut = (TwoCharAutomaton) taut.GetConstructor(new[] {typeof(int)}).Invoke(new object[] {n});
                    sb.Append($"\nVertex count: {n}\n");

                    {
                        var automaton = aut.GetType().ToString().Split('.')[1];

                        var fullSyncWord = string.Join("", aut.Sync() ?? new C[] { });
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
            }

            File.WriteAllText(fname, sb.ToString());
            sb.Clear();
        }
    }
}