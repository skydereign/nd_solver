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

        public Solution()
        {
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
    }
}
