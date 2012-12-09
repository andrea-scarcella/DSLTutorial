using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.Parsing;
using Irony.Interpreter.Ast;
using Irony.Ast; 

namespace FreightLanguage.code_generation
{
    public class IfStatementNode :AstNode
   {


       //private ExpressionNode Condition
       //{
       //    get { return (ExpressionNode)ChildNodes[1]; }
       //}

       private StatementListNode StatementList
       {
           get { return (StatementListNode)ChildNodes[2]; }
       }
       public void Init(AstContext context, ParseTreeNode parseNode)
       {
           throw new NotImplementedException();
       }
   }
}
