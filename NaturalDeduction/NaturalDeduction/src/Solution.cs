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
        List<Statement> subSolutions;

        public Solution()
        {
            proven = new List<Statement>();
            subSolutions = new List<Statement>();

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

        public void AddOther(Statement statement)
        {
            subSolutions.Add(statement);
        }

        public bool Solved(Statement statement)
        {
            return proven.Contains(statement);
        }

        public Statement GetReverse (Statement goal)
        {
            Console.WriteLine("\n\nGetReverse");
            foreach(Statement s in proven)
            {
                s.Print();
                Console.WriteLine(" statement " + s.GetLast().data + ", goal = " + goal.data);
                if(s.GetLast().data == goal.data)
                {
                    return s;
                }
            }
            Console.WriteLine("\nsubsolutions");

            foreach (Statement s in subSolutions)
            {
                s.Print();
                Console.WriteLine(" statement " + s.GetLast().data + ", goal = " + goal.data);
                if (s.GetLast().data == goal.data)
                {
                    return s;
                }
            }
            return null;
        }
    }
}
