using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaturalDeduction.src
{
    class Solution
    {
        Statement problem;
        List<Rule> rules;
        List<Statement> proven;

        public Solution()
        {
            proven = new List<Statement>();

            problem = new Statement(this, 0);
            problem.Print();
        }

        public void Solve()
        {
            Console.Write("\nsolution solving ");
            problem.Print();
            Console.WriteLine("");
            problem.Solve();
        }

        public void AddProven(Statement statement)
        {
            proven.Add(statement);
        }

        public bool Solved(Statement statement)
        {
            return proven.Contains(statement);
        }
    }
}
