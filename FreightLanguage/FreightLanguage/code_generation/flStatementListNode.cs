using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.Interpreter.Ast;

namespace FreightLanguage.code_generation
{
   public class flStatementListNode : AstNode, IJavascriptGenerator
    {
        public void GenerateScript(StringBuilder builder)
        {
           
           
            foreach (StatementNode statement in this.ChildNodes)
            {
                statement.GenerateScript(builder);
            }
          
        }
    }
}
