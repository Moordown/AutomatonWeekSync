namespace Automaton
{
    public class E_Automaton : EAutomaton
    {
        public E_Automaton(int n) : base(n)
        {
            bTransition[0] = 2;
            aTransition[0] = 2;
        }
    }
}