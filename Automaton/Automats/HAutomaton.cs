namespace Automaton
{
    public class HAutomaton : TwoCharAutomaton

    {
        public HAutomaton(int n) : base(n)
        {
            for (int i = 0; i < n; ++i)
            {
                aTransition[i] = i;
                bTransition[i] = i + 1;
            }

            aTransition[0] = n - 1;
            aTransition[n - 1] = 0;

            bTransition[n - 2] = 0;
            bTransition[n - 1] = 2;
        }
    }
}