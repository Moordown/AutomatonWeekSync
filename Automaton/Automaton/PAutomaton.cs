using Automaton;

namespace Automata.Automaton
{
    public class PAutomaton : TwoCharAutomaton
    {
        public PAutomaton(int n) : base(n)
        {
            for (int i = 0; i < n; ++i)
            {
                aTransition[i] = i;
                bTransition[i] = i + 1;
            }

            aTransition[0] = 1;
            aTransition[1] = 2;
            
            bTransition[0] = null;
            bTransition[n-1] = 0;
        }
    }
}