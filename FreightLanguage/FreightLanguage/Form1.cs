using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FreightLanguage.grammar;
using Irony.Parsing;

namespace FreightLanguage
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
            FreightGrammar grammar = new FreightGrammar();
            Parser parser = new Parser(grammar);
            ParseTree program = parser.Parse(programText);

            var ttt=program.ToXml();

            int u = 0;
        }
    }
}
