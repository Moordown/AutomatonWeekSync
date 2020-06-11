using Automaton;

namespace Automaton
{
    public class WeekSync : TwoCharAutomaton
    {
        public WeekSync(int n) : base(n)
        {
            for(int i=0; i<n; ++i)
            {
                aTransition[i] = i + 1;
                bTransition[i] = i + 1;
            }

            aTransition[n - 2] = 0;
            aTransition[n - 1] = 0;
            bTransition[n - 1] = 0;
            aTransition[0] = 0;
        }
    }
}