using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Threading;

namespace Aufgabe4b_Breitensuche
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _Form1 = this;
            //richTextBox1.Visible = false;
        }
        public static Form1 _Form1;


        public void ausgabe(char[,] spielfeld)
        {
            richTextBox1.Enabled = false;
            richTextBox1.Text = "";

            for (int zeilen = 0; zeilen < spielfeld.GetLength(0); zeilen++)
            {
                for (int zeichen = 0; zeichen < spielfeld.GetLength(1); zeichen++)
                {
                    switch (spielfeld[zeilen, zeichen])
                    {
                        case '#':
                            richTextBox1.SelectionColor = Color.Green;
                            break;
                        case '.':
                            richTextBox1.SelectionColor = Color.Blue;
                            break;
                        case '@':
                            richTextBox1.SelectionColor = Color.Red;
                            break;
                        default:
                            richTextBox1.SelectionColor = Color.Blue;
                            break;
                    }
                    if (spielfeld[zeilen, zeichen] == '.')
                    {
                        richTextBox1.AppendText('•' + "");
                    }
                    else
                    {
                        richTextBox1.AppendText(spielfeld[zeilen, zeichen] + "");
                    }

                }

                richTextBox1.AppendText("\n");

                Form mainFormHandler = Application.OpenForms[0];
                mainFormHandler.Size = new Size(richTextBox1.Width + 18, richTextBox1.Height);// + 35);

            }
        }
        public void ausgabeSteuerung(int delta)
        {
            if (delta != 0)
            {

                //Console.WriteLine("Spielerposition Dargestellt");
                int alteposition = richTextBox1.Find("@");
                richTextBox1.SelectedText = " ";
                richTextBox1.Select(alteposition + delta, 1);
                richTextBox1.SelectionColor = Color.Red;
                richTextBox1.SelectedText = "@";
            }

        }

        //automatische Größe von der Richtextbox
        private void automatischesRTB(object sender, ContentsResizedEventArgs e)
        {
            ((RichTextBox)sender).Height = (e.NewRectangle.Height + 5);
            ((RichTextBox)sender).Width = (e.NewRectangle.Width + 5);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Controller maze = new Controller();
            maze.start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controller maze = new Controller();

            maze.automatisch();

        }
    }

}