using Automaton;
using FluentAssertions;
using NUnit.Framework;

namespace AutomatonShould
{
    public class Tests
    {
        private CAutomaton _automaton;
        [SetUp]
        public void Setup()
        {
        }

        [TestCaseSource(nameof(CAutomatonSource))]
        public void TestLen2(int n, C[] ans)
        {
            _automaton = new CAutomaton(n);
            
            _automaton.Sync().Should().BeEquivalentTo(ans);
        }

        static object[] CAutomatonSource =
        {
            new object[] {2, new [] {C.A}},
            new object[] {3, new [] {C.A, C.B, C.B, C.A}},
            new object[] {4, new [] {C.A, C.B, C.B, C.B, C.A, C.B, C.B, C.B, C.A}},
        };
    }
}