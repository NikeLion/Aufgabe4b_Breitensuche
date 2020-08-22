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

    public class Controller
    {
        //Funktionen meineFunktionen = new Funktionen();
        //Spieler meinSpieler = new Spieler();
        //Spielfeld meinSpielfeld = new Spielfeld();
        //public Form1 meinFenster= new Form1();

        public static readonly Funktionen meineFunktionen = new Funktionen();
        public static readonly Spieler meinSpieler = new Spieler();
        public static readonly Spielfeld meinSpielfeld = new Spielfeld();
        public static readonly ComputerPlayer meinComputerPlayer = new ComputerPlayer();

        private int secCounter = 0;
        private int startCountdown = 5;
        private bool started = false;

        public void counter(object sender, EventArgs e)
        {
            secCounter++;
            if (secCounter < 5)
            {
                Form1._Form1.labelAusgabe("" + (startCountdown - secCounter));
            }
            else
            {
                Form1._Form1.labelAusgabe("" + (secCounter - startCountdown));
                if (!started)
                {

                    started = true;

                    automatisch();
                    
                }   
            }

        }

        public async void automatisch()
        {

            while (!meinSpielfeld.getEnde())
            {
                meinComputerPlayer.breitenSuche();
                await Task.Delay(500);
            }
            Form1._Form1.t1.Stop();
            //MessageBoxButtons buttons = MessageBoxButtons.Yes;
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show("Alles gegessen°!°\nProgramm beenden?", "Finished in " + (secCounter-startCountdown) + " seconds.", buttons);
            if (result == DialogResult.OK)
            {
                Form1._Form1.Close();
            }
            //Console.WriteLine("Alles gegessen°!°");
            

        }
        public void start()
        {
            meinSpielfeld.setSpielfeldGanz(meineFunktionen.spielfeldEinlesen());
            (int, int) neueKoords = (meinSpielfeld.getBreite() / 2, meinSpielfeld.getHoehe() / 2);

            meinSpieler.setSpieler(neueKoords.Item1, neueKoords.Item2);
            if (meinSpielfeld.getSpielfeld()[neueKoords.Item1, neueKoords.Item2] != '#')
            {
                meinSpielfeld.setSpielfeld(neueKoords.Item1, neueKoords.Item2);
            }


            Form1._Form1.ausgabe(meinSpielfeld.getSpielfeld());



            //Event für Tastendruck erzeugen und mit Methode verbinden
            Form1._Form1.KeyPreview = true;
            Form1._Form1.KeyPress +=
                new KeyPressEventHandler(meinSpieler.bewegen);

        }
    }
}