using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LED_Cube_Code_Generator
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        /**** Global Variables *****/
        // Path to pattern.h
        string path = Environment.CurrentDirectory + "/code/inc/pattern.h";

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(path))
            {
                createPatternFile();
            }

            this.KeyPreview = true;
         
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void simulationToolStripMenuItem_Click(object sender, EventArgs e)
        {  

        }

        private void arduinoProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check/uncheck the modes
            darkToolStripMenuItem.Checked  = true;  
            lightToolStripMenuItem.Checked = false; 
        }

        private void lightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check/uncheck the modes 
            lightToolStripMenuItem.Checked = true;
            darkToolStripMenuItem.Checked  = false;
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            stopButton_Click.Enabled = false;
            playButton_Click.Enabled = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            playButton_Click.Enabled = false;
            stopButton_Click.Enabled = true;
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

      
        private void patternTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            // Make list of patterns
            if (File.Exists(path))
            {
                List<string> pattern = new List<string>();
                pattern = File.ReadAllLines(path).ToList();
                pattern.Remove("#endif");
                pattern.Remove("};");

                pattern.Add("    {0xFFFF, 0xFFFF, 0xFFFF, 0xFFFF, " + numericUpDown1.Value + "},");
                pattern.Add("};");
                pattern.Add("#endif");
                File.WriteAllLines(path, pattern);

                // Increment full memory progress bar
                toolStripProgressBar1.Value = pattern.Count - 15;
            }
            else 
                createPatternFile();
        }


        // Create the pattern.h file with blank template
        void createPatternFile()
        {
            // Create pattern.h
            File.Create(path).Dispose();

            // Fill with the blank template
            List<string> pattern = new List<string>();
            pattern = File.ReadAllLines(path).ToList();
            pattern.Add("#ifndef __PATTERN_H__");
            pattern.Add("#define __PATTERN_H__\n");
            pattern.Add("// Includes");
            pattern.Add("//---------------------------------");
            pattern.Add("#include <stdint.h>        // Use uint_t");
            pattern.Add("#include <avr/pgmspace.h>  // Store patterns in program memory\n");
            pattern.Add("// Pattern that LED cube will display");
            pattern.Add("//--------------------------------- ");
            pattern.Add("const PROGMEM uint16_t pattern_table[][5] = {\n");
            pattern.Add("};");
            pattern.Add("#endif");
            File.WriteAllLines(path, pattern);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
                generateButton.PerformClick();
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
                generateButton.PerformClick();
        }

        string toHex(int nr)
        {
            string hexValue = "0x" + nr.ToString("X4");
            return hexValue;
        }
        
        int toDecimal(int nr)
        {
            return 0; 
        }

        string toBinary(int nr)
        {
            string binValue = "0b" + Convert.ToString(nr, 2);
            return binValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(toHex((int)numericUpDown1.Value));
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
