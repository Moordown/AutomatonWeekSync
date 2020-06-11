namespace Automaton
{
    public class VKAutomaton : TwoCharAutomaton
    {
        public VKAutomaton(int n) : base(n)
        {
            for (var i = 0; i < n; i++)
            {
                aTransition[i] = i;
                bTransition[i] = i + 1;
            }

            bTransition[n - 1] = 0;
        }
    }
}