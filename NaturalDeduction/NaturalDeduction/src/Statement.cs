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

        Solution solution;
        List<Statement> subStatements;
        List<Rules> connectors;
        Qualifier qualifier;
        Rule solver;
        char data = ' ';
        bool proven;

        public Statement(Solution solution, int type)
        {
            this.solution = solution;
            subStatements = new List<Statement>();
            connectors = new List<Rules>();

            Init(type);
        }

        public void Solve()
        {
            Print();
            if(connectors.Count > 0)
            {
                // create a rule
                Statement firstStatement = subStatements[0];
                Statement nextStatement = Split(1);
                Rule currentRule = null;


                switch(connectors[0])
                {
                    case Rules.Implies:
                        currentRule = new ImpliesRule(solution, firstStatement, nextStatement, this);
                        break;
                }

                // add rule to the solution
                currentRule.Solve(); // solve the rule
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        // should probably make this a constructor
        public Statement Split(int index)
        {
            if (subStatements.Count > 2)
            {
                List<Statement> statements = subStatements.GetRange(index, subStatements.Count - index);
                List<Rules> rules = connectors.GetRange(index, connectors.Count - index);
                Statement newStatement = new Statement(solution, 999);
                newStatement.Set(statements, rules);
                return newStatement;
            }
            else
            {
                return subStatements[1];
            }
        }

        public void Set (List<Statement> newStatements, List<Rules> rules)
        {
            subStatements = newStatements;
            connectors = rules;
        }

        public void Print()
        {
            int i = 0;
            if (subStatements.Count > 0) { Console.Write("( "); }
            foreach(Statement s in subStatements)
            {
                s.Print();

                if(i < connectors.Count)
                {
                    // need Qualifier printing forall/foreach/negation
                    Console.Write(connectors[i] + " ");
                    i++;
                }
            }
            if (subStatements.Count > 0) { Console.Write(") "); }
            
            if(data != ' ')
            {
                Console.Write(data + " ");
            }
        }

        public void Init(int type)
        {
            switch(type)
            {
                case 0: // (P->Q) -> P -> ~Q -> R
                    Statement temp = new Statement(solution, 5);
                    subStatements.Add(temp);
                    solution.AddProven(temp);
                    connectors.Add(Rules.Implies);

                    temp = new Statement(solution, 1);
                    subStatements.Add(temp);
                    solution.AddProven(temp);
                    connectors.Add(Rules.Implies);

                    temp = new Statement(solution, 3);
                    subStatements.Add(temp);
                    solution.AddProven(temp);
                    connectors.Add(Rules.Implies);

                    temp = new Statement(solution, 4);
                    subStatements.Add(temp);
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
                    subStatements.Add(new Statement(solution, 1));
                    connectors.Add(Rules.Implies);

                    subStatements.Add(new Statement(solution, 2));
                    break;
            }
        }
    }
}
