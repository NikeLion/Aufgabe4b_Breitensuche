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

    public class Spielfeld : Controller
    {

        private char[,] spielfeld;
        private int breite;
        private int hoehe;
        private int itemsUebrig;

        public char[,] getSpielfeld()
        {
            return spielfeld;
        }

        public bool search(char c)
        {
            for (int col = 0; col < spielfeld.GetLength(0); col++)
            {
                for (int row = 0; row < spielfeld.GetLength(1); row++)
                {
                    if (spielfeld[col, row] == c)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void setSpielfeld(int neuX, int neuY)
        {
            (int altX, int altY) = meinSpieler.getSpieler();

            meinSpieler.setSpieler(neuX, neuY);

            //alte Position und Punkte "löschen" und mit leerem Zeichen überschreiben
            spielfeld[altX, altY] = ' ';
            //neue Position @
            spielfeld[neuX, neuY] = '@';
        }
        #region GET-SET Methoden
        public void setSpielfeldGanz(char[,] tempSpielfeld)
        {
            spielfeld = tempSpielfeld;
        }

        public void setBreite(int nBreite)
        {
            breite = nBreite;
        }

        public int getBreite()
        {
            return breite;
        }
        public void setHoehe(int nHoehe)
        {
            hoehe = nHoehe;
        }

        public int getHoehe()
        {
            return hoehe;
        }

        public void setItemsUebrig(int itemAnzahl)
        {
            itemsUebrig = itemAnzahl;
        }
        public int getItemsUebrig()
        {
            return itemsUebrig;
        }
        public bool getEnde()
        {
            return (itemsUebrig == 0);
            //return (!search('.')) ;
        }


        #endregion
    }

}