using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.Interpreter.Ast;
using Irony.Parsing;

namespace FreightLanguage.code_generation
{
  public  class ExpressionNode : AstNode, IJavascriptGenerator
    {
       

        public void GenerateScript(StringBuilder builder)
        {
            foreach (var child in this.ChildNodes)
            {
                IJavascriptGenerator jsChild = child as IJavascriptGenerator;
                if (jsChild!=null)
                {
                    jsChild.GenerateScript(builder);
                }
                else
                {
                    string expressionAsJavaScript = child.AsString;

                    if (child.Term is StringLiteral)
                    {
                        expressionAsJavaScript = expressionAsJavaScript.ToLower();
                    }
                    else
                    {
                        throw new InvalidOperationException("Was not expected a child of type " + child.GetType().FullName);
                    }

                }
            }
        }
    }
}
