namespace Automaton
{
    public class VAutomaton: TwoCharAutomaton
    {
        public VAutomaton(int n) : base(n)
        {
            for (int i = 0; i < n; ++i)
            {
                aTransition[i] = i;
                bTransition[i] = i + 1;
            }

            aTransition[n - 1] = 1;
            bTransition[n - 1] = 0;
        }
    }
}