using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaturalDeduction.src
{
    class Statement
    {
        public enum Qualifier {None, Contradiction, Negation, Forall, Foreach};
        public enum Rules {And, Or, Implies};

        List<Statement> subStatements;
        List<Rules> connectors;
        Qualifier qualifier;
        char data;

        public Statement(int type)
        {
            subStatements = new List<Statement>();
            connectors = new List<Rules>();

            Init(type);
        }

        public void Init(int type)
        {
            switch(type)
            {
                case 0: // (P->Q) -> P -> ~Q -> R
                    subStatements.Add(new Statement(5));
                    connectors.Add(Rules.Implies);
                    
                    subStatements.Add(new Statement(1));
                    connectors.Add(Rules.Implies);
                    
                    subStatements.Add(new Statement(3));
                    connectors.Add(Rules.Implies);
                    
                    subStatements.Add(new Statement(4));
                    break;

                case 1: // P
                    data = 'P';
                    break;

                case 2: // Q
                    data = 'Q';
                    break;

                case 3: // ~Q
                    qualifier = Qualifier.Negation;
                    data = 'Q';
                    break;

                case 4: // R
                    data = 'R';
                    break;

                case 5: // (P->Q)
                    subStatements.Add(new Statement(1));
                    connectors.Add(Rules.Implies);

                    subStatements.Add(new Statement(2));
                    break;
            }
        }
    }
}
