using System.Collections.Generic;
using System.Linq;

namespace Automaton
{
    public class SyncResult
    {
        public C[] Word { get; set; }

        public int Length => Word.Count();
        public string Hint { get; set; }

        public override string ToString()
        {
            var word = string.Join("", Word);
            return $"use {Hint} = ({word.Length}){word}";
        }
    }
}