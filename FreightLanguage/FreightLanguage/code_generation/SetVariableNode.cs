using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.Interpreter.Ast;

namespace FreightLanguage.code_generation
{
    public class SetVariableNode : AstNode, IJavascriptGenerator
    {
        public void GenerateScript(StringBuilder builder)
        {
            //IJavascriptGenerator varNameNode = (IJavascriptGenerator)ChildNodes[1];
            IJavascriptGenerator varValueNode = (IJavascriptGenerator)ChildNodes[3];
            //varNameNode.GenerateScript(builder);
            builder.Append(ChildNodes[1].AsString);
            builder.Append(" = ");
            varValueNode.GenerateScript(builder);
            builder.Append(";");

        }
    }
}
