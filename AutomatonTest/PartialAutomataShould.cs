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
        public void ShouldNotSync()
        {
            foreach (var aut in new TwoCharAutomaton[]
            {
                new CAutomaton(10), new DAutomaton(10), new EAutomaton(10), new GAutomaton(10),
                new HAutomaton(10), new RAutomaton(10), new VAutomaton(10), new WAutomaton(10),    
            })
            {
                for (var i = 0; i < 10; ++i)
                {
                    aut.NullTransition(C.A, i).PartialSync().Should().BeNull();
                    aut.NullTransition(C.B, i).PartialSync().Should().BeNull();
                }
            }
        }

        private static object[] WeekSyncAutomatonSource = new[]
        {
            new object[] {4, C.A, 0, null},
            new object[] {4, C.A, 1, null},
            new object[] {4, C.A, 2, null},
            new object[] {4, C.A, 3, null},
            
            new object[] {4, C.B, 0, new [] {C.A, C.A}},
            new object[] {4, C.B, 1, new [] {C.A, C.A}},
            new object[] {4, C.B, 2, new [] {C.A, C.A}},
            new object[] {4, C.B, 3, new [] {C.A, C.A}},
        };
    }
}