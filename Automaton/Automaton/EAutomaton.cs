namespace Automaton
{
    public class EAutomaton : TwoCharAutomaton
    {
        public EAutomaton(int n) : base(n)
        {
            for (int i = 0; i < n; ++i)
            {
                if (i == 0)
                    aTransition[i] = 1;
                else if (i == 1)
                    aTransition[i] = 2;
                else
                    aTransition[i] = i;
                bTransition[i] = i + 1;
            }
            bTransition[n - 1] = 0;
        }
    }
}