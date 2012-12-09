using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.Parsing;

namespace CameraDSLTutorial
{
    public class CameraControlGrammar : Grammar
    {
        public CameraControlGrammar() :
            //#AS:2012/12/08: grammar is case-insensitive
            base(caseSensitive: false)
        {
            var program = new NonTerminal("program");
            var cameraSize = new NonTerminal("cameraSize");
            var cameraPosition = new NonTerminal("cameraPosition");
            var commandList = new NonTerminal("commandList");
            var command = new NonTerminal("command");
            var direction = new NonTerminal("direction");
            var number = new NumberLiteral("number");
            this.Root = program;
            //Grammar production rules in bnf form
            // <Program> ::= <CameraSize> <CameraPosition> <CommandList>
            program.Rule = cameraSize + cameraPosition + commandList;

            // <CameraSize> ::= "set" "camera" "size" ":" <number> "by" <number> "pixels" "."
            cameraSize.Rule = ToTerm("set") + "camera" + "size" + ":" +
                              number + "by" + number + "pixels" + ".";

            // <CameraPosition> ::= "set" "camera" "position" ":" <number> "," <number> "."
            cameraPosition.Rule = ToTerm("set") + "camera" + "position" +
                                  ":" + number + "," + number + ".";

            // <CommandList> ::= <Command>+
            commandList.Rule = MakePlusRule(commandList, null, command);

            // <Command> ::= "move" <number> "pixels" <Direction> "."
            command.Rule = ToTerm("move") + number + "pixels" + direction + ".";

            // <Direction> ::= "up" | "down" | "left" | "right"
            direction.Rule = ToTerm("up") | "down" | "left" | "right";

            //#AS:2012/12/08: these symbols are defined as puntuation, so they will not be included in the ast
            this.MarkPunctuation("set", ("camera"), "size", ":", "by", "pixels", ".", "position", ",", "move");

        }
    }
}
