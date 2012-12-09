using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.Interpreter.Ast;

namespace FreightLanguage.code_generation
{
 public   class ProgramNode : AstNode, IJavascriptGenerator
    {
        public void GenerateScript(StringBuilder builder)
        {
            IJavascriptGenerator jsStatementList = (IJavascriptGenerator )ChildNodes[0];
            IJavascriptGenerator jsFreightDeclaration = (IJavascriptGenerator)ChildNodes[1];
            builder.AppendLine("function getFreightCost(customer, region, items) {");
            var variables = GetAll().OfType<SetVariableNode>().Select(node => node.Variable.Text).Distinct();
            jsStatementList.GenerateScript(builder);
            jsFreightDeclaration.GenerateScript(builder);
            builder.AppendLine("}");
        }
    }
}
