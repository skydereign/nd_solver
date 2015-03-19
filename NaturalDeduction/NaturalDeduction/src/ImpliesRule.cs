using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaturalDeduction.src
{
    class ImpliesRule : Rule
    {
        Statement firstStatement;
        Statement aboveStatement;

        public ImpliesRule(Solution solution, Statement firstStatement, Statement aboveStatement, Statement baseStatement) : base(solution, baseStatement)
        {
            this.firstStatement = firstStatement;
            this.aboveStatement = aboveStatement;
        }

        public override void Solve()
        {
            // check if solution has firstStatement (hopefully)
            Console.WriteLine("Implies!");
            aboveStatement.Solve();
        }
    }
}
