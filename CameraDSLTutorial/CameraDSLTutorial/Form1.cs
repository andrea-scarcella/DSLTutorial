using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Irony.Parsing;

namespace CameraDSLTutorial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string programText = textBox1.Text;
            CameraControlGrammar grammar = new CameraControlGrammar();
            Parser parser = new Parser(grammar);
            ParseTree program = parser.Parse(programText);
           
            //var ttt=program.ToXml();



            var cameraSizeNode = program.Root.ChildNodes[0];
            var widthNode = cameraSizeNode.ChildNodes[0];
            int width = (int)widthNode.Token.Value;
            var heightNode = cameraSizeNode.ChildNodes[1];
            int height = (int)heightNode.Token.Value;



            // loop through the movement commands
            foreach (ParseTreeNode commandNode in program.Root.ChildNodes[2].ChildNodes)
            {
                // get the number of pixels to move
                Token pixelsToken = commandNode.ChildNodes[0].Token;
                int pixelsToMove = (int)pixelsToken.Value;
                // get the direction
                Token directionToken =commandNode.ChildNodes[1].Token;
                string directionText = directionToken.Text.ToLower();
            }
            int u = 0;

          
        }
    }
}
