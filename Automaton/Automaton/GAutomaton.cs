namespace Automaton
{
    public class GAutomaton: VAutomaton
    {
        public GAutomaton(int n) : base(n)
        {
            aTransition[n - 3] = 0;
        }
    }
}