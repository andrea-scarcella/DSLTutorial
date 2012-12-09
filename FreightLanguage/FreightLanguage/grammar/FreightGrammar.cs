using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.Parsing;

namespace FreightLanguage.grammar
{
    public class FreightGrammar : Grammar
    {
        public FreightGrammar()
            : base(caseSensitive: false)
        {
            // define all the non-terminals
            var program = new NonTerminal("program");
            var statementList = new NonTerminal("statementList");
            var statement = new NonTerminal("statement");
            var ifStatement = new NonTerminal("ifStatement",typeof(FreightLanguage.code_generation.IfStatementNode));
            var freightDeclaration = new NonTerminal("freightDeclaration");
            var setVariable = new NonTerminal("setVariable");
            var orderLoop = new NonTerminal("orderLoop");
            var expression = new NonTerminal("expression",typeof(FreightLanguage.code_generation.ExpressionNode));
            var variable = new IdentifierTerminal("variable");
            //variable.AddKeywords("set", "to", "if", "freight", "cost", "is", "loop", "through", "order");

            var binaryOperator = new NonTerminal("binaryOperator");
            // define the grammar
            //<BinaryOperator> ::= "+" | "-" | "*" | "/" | "<" | ">" | "<=" | ">=" | "is"
            
            binaryOperator.Rule = ToTerm("+") | "-" | "*" | "/" | "<" | ">" | "<=" | ">=" | "is";
            //<Program> ::= <StatementList> <FreightDeclaration>
            program.Rule = statementList + freightDeclaration;
            //<StatementList> ::= <Statement>*
            statementList.Rule = MakeStarRule(statementList, null, statement);
            //<Statement> ::= <SetVariable> ";" | <IfStatement> | <OrderLoop> | <Expression> ";"
            statement.Rule = setVariable + ";" | ifStatement | orderLoop | expression + ";";
            //<SetVariable> ::= "set" <variable> "to" <Expression>
            setVariable.Rule = ToTerm("set") + variable + "to" + expression;
            //<IfStatement> ::= "if" <Expression> "[" <StatementList> "]"
            ifStatement.Rule = ToTerm("if") + expression + "[" + statementList + "]";
            //<OrderLoop> ::= "loop" "through" "order" "[" <StatementList> "]"
            orderLoop.Rule = ToTerm("loop") + "through" + "order" + "[" + statementList + "]";
            //<FreightDeclaration> ::= "freight" "cost" "is" <Expression> ";"
            freightDeclaration.Rule = ToTerm("freight") + "cost" + "is" + expression + ";";
            //<Expression> ::= <number> | <variable> | <string> |<Expression> <BinaryOperator> <Expression> | "(" <Expression> ")"
            var number = new NumberLiteral("number");
            //TEST
            number.DefaultIntTypes = number.DefaultIntTypes = new TypeCode[] { TypeCode.Int32, TypeCode.Int64, NumberLiteral.TypeCodeBigInt };
            var stringLiteral = new StringLiteral("stringType", "\"");
            expression.Rule = number | variable | stringLiteral | expression + binaryOperator + expression | "(" + expression + ")";
            this.Root = program;
            MarkPunctuation("[", "]", ";");
        }
    }
}
