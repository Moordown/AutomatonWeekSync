using Automaton;
using FluentAssertions;
using NUnit.Framework;

namespace AutomatonShould
{
    public class Tests
    {
        [TestCaseSource(nameof(CAutomatonSource))]
        public void TestC(int n, C[] ans)
        {
            new CAutomaton(n).Sync().Should().BeEquivalentTo(ans);
        }

        [TestCaseSource(nameof(WAutomatonSource))]
        public void TestW(int n, C[] ans)
        {
            new WAutomaton(n).Sync().Should().BeEquivalentTo(ans);
        }

        [TestCaseSource(nameof(EAutomatonSource))]
        public void TestE(int n, C[] ans)
        {
            new EAutomaton(n).Sync().Should().BeEquivalentTo(ans);
        }

        [TestCaseSource(nameof(HAutomatonSource))]
        public void TestH(int n, C[] ans)
        {
            new HAutomaton(n).Sync().Should().BeEquivalentTo(ans);
        }


        [TestCaseSource(nameof(DAutomatonSource))]
        public void TestD(int n, C[] ans)
        {
            new DAutomaton(n).Sync().Should().BeEquivalentTo(ans);
        }

        [TestCaseSource(nameof(RAutomatonSource))]
        public void TestR(int n, C[] ans)
        {
            new RAutomaton(n).Sync().Should().BeEquivalentTo(ans);
        }

        [TestCaseSource(nameof(VAutomatonSource))]
        public void TestV(int n, C[] ans)
        {
            new VAutomaton(n).Sync().Should().BeEquivalentTo(ans);
        }

        [TestCaseSource(nameof(GAutomatonSource))]
        public void TestG(int n, C[] ans)
        {
            new GAutomaton(n).Sync().Should().BeEquivalentTo(ans);
        }


        static object[] CAutomatonSource =
        {
            new object[] {2, new[] {C.A}},
            new object[] {3, new[] {C.A, C.B, C.B, C.A}},
            new object[] {4, new[] {C.A, C.B, C.B, C.B, C.A, C.B, C.B, C.B, C.A}},
        };

        private static object[] WAutomatonSource =
        {
            new object[] {2, new[] {C.B}},
            new object[] {3, new[] {C.B, C.A, C.B}},
            new object[] {4, new[] {C.B, C.A, C.B, C.B, C.A, C.A, C.B}},
        };

        private static object[] EAutomatonSource =
        {
            new object[] {3, new[] {C.A, C.A}},
            new object[] {4, new[] {C.A, C.B, C.B, C.B, C.A, C.A}},
            new object[] {5, new[] {C.A, C.B, C.B, C.B, C.B, C.A, C.A, C.B, C.B, C.B, C.A, C.A}},
        };

        private static object[] HAutomatonSource =
        {
            new object[] {3, null},
            new object[] {4, new[] {C.B, C.A, C.B, C.B, C.A, C.B}},
            new object[] {5, new[] {C.B, C.A, C.B, C.B, C.B, C.A, C.B, C.B, C.B, C.A, C.B}},
        };

        private static object[] RAutomatonSource =
        {
            new object[] {3, new[] {C.A, C.B, C.B, C.A}},
            new object[] {4, new[] {C.A, C.B, C.B, C.B, C.A, C.B, C.B, C.A}},
            new object[] {5, new[] {C.A, C.B, C.B, C.B, C.B, C.A, C.B, C.B, C.B, C.A, C.A, C.B, C.B, C.A}},
        };

        private static object[] DAutomatonSource =
        {
            new object[] {3, new[] {C.B, C.A}},
            new object[] {4, new[] {C.B, C.A, C.B, C.B, C.B, C.A}},
            new object[] {5, new[] {C.B, C.A, C.B, C.B, C.B, C.B, C.A, C.B, C.B, C.A, C.B, C.A}},
        };

        private static object[] VAutomatonSource =
        {
            new object[] {3, new[] {C.A, C.B, C.A}},
            new object[] {4, null},
            new object[] {5, new[] {C.A, C.B, C.B, C.B, C.A, C.B, C.B, C.B, C.A, C.B, C.B, C.B, C.A}},
        };

        private static object[] GAutomatonSource =
        {
            new object[] {4, new[] {C.A, C.B, C.B, C.B, C.A, C.A}},
            new object[] {5, new[] {C.B, C.B, C.B, C.A, C.A, C.A}},
        };
    }
}