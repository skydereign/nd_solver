using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaturalDeduction.src
{
    class ImpliesIntroRule : Rule
    {
        Statement firstStatement;
        Statement aboveStatement;

        public ImpliesIntroRule(Solution solution, Statement firstStatement, Statement aboveStatement, Statement baseStatement) : base(solution, baseStatement)
        {
            this.firstStatement = firstStatement;
            this.aboveStatement = aboveStatement;
        }

        public override void Solve()
        {
            // need to check firstStatement is already in proven, if not solve
            // need to check aboveStatement to solve
            Console.WriteLine("Implies Introduction!");

            if (!solution.Solved(firstStatement))
            {
                firstStatement.Solve();
            }
            else
            {
                Console.Write("first --- Solved ---");
                firstStatement.Print();
                Console.WriteLine("");
            }

            if(!solution.Solved(aboveStatement))
            {
                aboveStatement.Solve();
            }
            else
            {
                Console.Write("above --- Solved ---");
                aboveStatement.Print();
                Console.WriteLine("");
            }

            // check if this needs to be solved?
        }
    }
}
