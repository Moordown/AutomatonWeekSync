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


        static object[] CAutomatonSource =
        {
            new object[] {2, new [] {C.A}},
            new object[] {3, new [] {C.A, C.B, C.B, C.A}},
            new object[] {4, new [] {C.A, C.B, C.B, C.B, C.A, C.B, C.B, C.B, C.A}},
        };

        private static object[] WAutomatonSource =
        {
            new object[] {2, new [] {C.B}},
            new object[] {3, new [] {C.B, C.A, C.B}},
            new object[] {4, new [] {C.B, C.A, C.B, C.B, C.A, C.A, C.B}},
        };
    }
}