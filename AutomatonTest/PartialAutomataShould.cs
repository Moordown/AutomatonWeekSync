using System;
using System.Linq;
using Automata.Automaton;
using Automaton;
using FluentAssertions;
using NUnit.Framework;

namespace AutomataShould
{
    public class PartialAutomataShould
    {
        [TestCaseSource(nameof(WeekSyncAutomatonSource))]
        public void ShouldWeekSync(int n, C c, int from, C[] ans)
        {
            new WeekSync(n).NullTransition(c, from).PartialSync().Should().BeEquivalentTo(ans);
        }

        [Test]
        public void ShouldWeekSyncInSquareLength()
        {
            new PAutomaton(4).PartialSync().Should().BeEquivalentTo(new[] {C.A, C.A, C.B, C.A, C.B, C.A, C.A});
        }

        private static object[] WeekSyncAutomatonSource = new[]
        {
            new object[] {4, C.A, 0, null},
            new object[] {4, C.A, 1, null},
            new object[] {4, C.A, 2, null},
            new object[] {4, C.A, 3, null},

            new object[] {4, C.B, 0, new[] {C.A, C.A}},
            new object[] {4, C.B, 1, new[] {C.A, C.A}},
            new object[] {4, C.B, 2, new[] {C.A, C.A}},
            new object[] {4, C.B, 3, new[] {C.A, C.A}},
        };
    }
}