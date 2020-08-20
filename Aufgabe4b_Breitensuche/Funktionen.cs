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

    public class Funktionen : Controller
    {

        //Konvertierung von Text zu Spielfeld
        public char[,] spielfeldbauen(string[] spielfeldTextfeld, int zeilenlänge, int spaltenlänge)
        {
            char[,] spielfeld = new char[zeilenlänge, spaltenlänge];
            int zeilenzähler = 0;
            foreach (string zeile in spielfeldTextfeld)
            {
                for (int zeichenzähler = 0; zeichenzähler < zeile.Length; zeichenzähler++)
                {

                    spielfeld[zeichenzähler, zeilenzähler] = zeile[zeichenzähler];
                }
                zeilenzähler++;
            }

            return spielfeld;
        }


        public char[,] spielfeldEinlesen()
        {
            int spaltenlänge = Int32.Parse(Console.ReadLine());
            int zeilenlänge = Int32.Parse(Console.ReadLine());

            char[,] spielfeld = new char[spaltenlänge, zeilenlänge * 2];

            meinSpielfeld.setBreite(zeilenlänge);
            meinSpielfeld.setHoehe(spaltenlänge);

            string zeile;
            bool run = true;
            int itemZaehler = 0;

            int zeilenzähler = 0;
            while (run)

            {
                zeile = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(zeile))
                {
                    Console.WriteLine(zeile);
                    for (int zeichenzähler = 0; zeichenzähler < zeile.Length; zeichenzähler++)
                    {
                        spielfeld[zeilenzähler, zeichenzähler] = zeile[zeichenzähler];
                        if (zeile[zeichenzähler] == '.')
                        {
                            itemZaehler++;
                        }
                    }
                    zeilenzähler++;
                }
                else
                {
                    run = false;
                }
                meinSpielfeld.setItemsUebrig(itemZaehler);
            }
            return spielfeld;
        }

        //übergabe Matrix und veränderung der Werte
        public void spielerSteuerung(int neuX, int neuY, int delta)
        {
            if (meinSpielfeld.getSpielfeld()[neuX, neuY] != '#')
            {
                if (meinSpielfeld.getSpielfeld()[neuX, neuY] == '.')
                {
                    meinSpielfeld.setItemsUebrig(meinSpielfeld.getItemsUebrig() - 1);
                }
                meinSpielfeld.setSpielfeld(neuX, neuY);
                Console.WriteLine("Spieler bei: " + neuX + " " + neuY);
                //Console.WriteLine(delta);
                Form1._Form1.ausgabeSteuerung(delta);
            }


        }

    }

}