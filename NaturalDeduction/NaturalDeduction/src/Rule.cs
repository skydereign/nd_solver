using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaturalDeduction.src
{
    class Rule
    {
        Solution solution;
        Statement baseStatement;

        public Rule(Solution solution, Statement baseStatement)
        {
            this.solution = solution;
            this.baseStatement = baseStatement;
        }

        public virtual void Solve()
        {
            //
        }
    }
}
