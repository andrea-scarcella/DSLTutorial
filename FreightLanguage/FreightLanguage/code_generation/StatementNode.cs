using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.Interpreter.Ast;

namespace FreightLanguage.code_generation
{
   public class StatementNode : AstNode, IJavascriptGenerator
    {
        public void GenerateScript(StringBuilder builder)
        {
            IJavascriptGenerator child = (IJavascriptGenerator)this.ChildNodes[0];
            child.GenerateScript(builder);

            if (child is ExpressionNode)
            {
                builder.Append(";");
            }
        }
    }
}
