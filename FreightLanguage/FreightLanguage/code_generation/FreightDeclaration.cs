using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.Interpreter.Ast;

namespace FreightLanguage.code_generation
{
 public   class FreightDeclaration : AstNode, IJavascriptGenerator
    {
        public void GenerateScript(StringBuilder builder)
        {
            IJavascriptGenerator child = (IJavascriptGenerator)this.ChildNodes[3];

            builder.Append(" return ");
            child.GenerateScript(builder);
            builder.AppendLine(";");
        }
    }
}
