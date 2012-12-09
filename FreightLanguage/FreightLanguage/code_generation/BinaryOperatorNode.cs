using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.Interpreter.Ast;

namespace FreightLanguage.code_generation
{
    class BinaryOperatorNode : AstNode, IJavascriptGenerator
    {
        public void GenerateScript(StringBuilder builder)
        {
            IJavascriptGenerator jsChild = (IJavascriptGenerator)this.ChildNodes[0];
            if ("is".Equals(ChildNodes[0].AsString ))
            {
                builder.Append("==");
            }
            else
            {
                builder.Append(ChildNodes[0].AsString);
            }
        }
    }
}
