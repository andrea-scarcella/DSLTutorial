using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.Interpreter.Ast;

namespace FreightLanguage.code_generation
{
    public class OrderLoopNode : AstNode, IJavascriptGenerator
    {
        public void GenerateScript(StringBuilder builder)
        {
            builder.AppendLine("for (var __i = 0; __i < items.length; __i++) {");
            builder.AppendLine("var weight = items[__i].weight;");
            builder.AppendLine("var quantity = items[__i].quantity;");
            //flStatementList.GenerateScript(builder);
            ((IJavascriptGenerator)ChildNodes[3]).GenerateScript(builder);
            builder.AppendLine("}");
        }
    }
}
