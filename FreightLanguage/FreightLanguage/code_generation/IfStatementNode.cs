using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.Parsing;
using Irony.Interpreter.Ast;
using Irony.Ast; 

namespace FreightLanguage.code_generation
{
    public class IfStatementNode :AstNode,IJavascriptGenerator
   {


        private ExpressionNode Condition
        {
            get { return (ExpressionNode)ChildNodes[1]; }
        }

       private flStatementListNode StatementList
       {
           get { return (flStatementListNode)ChildNodes[2]; }
       }
       public void Init(AstContext context, ParseTreeNode parseNode)
       {
           throw new NotImplementedException();
       }

       public void GenerateScript(StringBuilder builder)
       {
           builder.Append("if (");
           Condition.GenerateScript(builder);
           builder.AppendLine(") {");
           StatementList.GenerateScript(builder);
           builder.AppendLine("}");
       }
   }
}
