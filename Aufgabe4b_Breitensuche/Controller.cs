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

        public void automatisch()
        {
            
            /*while (!meinSpielfeld.getEnde())
            {
                meinComputerPlayer.breitenSuche();
            }*/
            Console.WriteLine("Alles gegessen°!°");
            meinComputerPlayer.breitenSuche();

        }
        public void start()
        {
            meinSpielfeld.setSpielfeldGanz(meineFunktionen.spielfeldEinlesen());

            //(int, int) neueKoords = meinSpielfeld.getSpielerInSpielfeld();
            (int, int) neueKoords = (meinSpielfeld.getBreite() / 2, meinSpielfeld.getHoehe() / 2);
            //(int, int) alteKoords = meinSpieler.getSpieler();

            meinSpieler.setSpieler(neueKoords.Item1, neueKoords.Item2);
            //Console.WriteLine(neueKoords.Item1 + "; " + neueKoords.Item2);
            // meineFunktionen.spielerSteuerung(neueKoords.Item1, neueKoords.Item2, 0);
            if (meinSpielfeld.getSpielfeld()[neueKoords.Item1, neueKoords.Item2] != '#')
            {
                meinSpielfeld.setSpielfeld(neueKoords.Item1, neueKoords.Item2);
            }


            Form1._Form1.ausgabe(meinSpielfeld.getSpielfeld());



            //Event für Tastendruck erzeugen und mit Methode verbinden
            Form1._Form1.KeyPreview = true;
            //.KeyPreview = true;
            Form1._Form1.KeyPress +=
                new KeyPressEventHandler(meinSpieler.bewegen);

        }
    }
}