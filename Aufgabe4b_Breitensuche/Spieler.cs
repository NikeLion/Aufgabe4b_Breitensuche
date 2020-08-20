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

    public class Spieler : Controller
    {
        private int spielerX;
        private int spielerY;
        //Tastatursteuerung
        public void bewegen(object sender, KeyPressEventArgs e)
        {
            if (!meinSpielfeld.getEnde())
            {
                switch (e.KeyChar)
                {
                    case 'w':
                        meineFunktionen.spielerSteuerung(spielerX - 1, spielerY, -((meinSpielfeld.getHoehe()) + 1));
                        break;
                    case 's':
                        meineFunktionen.spielerSteuerung(spielerX + 1, spielerY, +((meinSpielfeld.getHoehe()) + 1));
                        break;
                    case 'a':
                        meineFunktionen.spielerSteuerung(spielerX, spielerY - 1, -1);
                        break;
                    case 'd':
                        meineFunktionen.spielerSteuerung(spielerX, spielerY + 1, +1);
                        break;
                }
            }
            else
            {
                Application.Exit();
            }
        }

        public (int, int) getSpieler()
        {
            return (spielerX, spielerY);
        }

        public void setSpieler(int neuX, int neuY)
        {
            spielerX = neuX;
            spielerY = neuY;

        }

    }
}