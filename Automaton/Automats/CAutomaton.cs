namespace Automaton
{
    public class CAutomaton : TwoCharAutomaton
    {
        public CAutomaton(int n) : base(n)
        {
            for (int i = 0; i < n - 1; ++i)
            {
                aTransition[i] = (byte) i;
                bTransition[i] = (byte) (i + 1);
            }

            aTransition[n - 1] = 0;
            bTransition[n - 1] = 0;
        }
    }
}