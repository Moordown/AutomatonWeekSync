namespace Automaton
{
    public class WAutomaton : TwoCharAutomaton
    {
        public WAutomaton(int n) : base(n)
        {
            for (int i = 0; i < n - 1; ++i)
            {
                aTransition[i] = i + 1;
                bTransition[i] = i + 1;
            }

            aTransition[n - 1] = 0;
            bTransition[n - 1] = 1;
        }
    }
}