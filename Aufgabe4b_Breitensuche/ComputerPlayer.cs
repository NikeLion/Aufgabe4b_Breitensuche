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

    public class ComputerPlayer : Controller
    {
        Queue warteschlange = new Queue();
        Hashtable hashtable = new Hashtable();
        public void breitenSuche()
        {   //erste Position in Warteschlage schieben

            (int, int) koords = meinSpieler.getSpieler();
            Console.WriteLine("spieler bei: " + koords);
            Point p = new Point();
            Point check = new Point();
            Point checkTemp = new Point();
            check.X = koords.Item1;
            check.Y = koords.Item2;

            warteschlange.Enqueue(check);

            while (warteschlange.Count != 0)
            {

                check = (Point)warteschlange.Dequeue();
                Console.Write(check.X + "; " + check.Y + "ist punkt: ");
                Console.WriteLine(meinSpielfeld.getSpielfeld()[check.X, check.Y] == '.');

                if (meinSpielfeld.getSpielfeld()[check.X, check.Y] != '.')
                {
                    #region Nachbarn in Schlange hinzufügen
                    #region Check Oben
                    checkTemp.X = check.X + 1;
                    checkTemp.Y = check.Y;
                    if (meinSpielfeld.getSpielfeld()[checkTemp.X, checkTemp.Y] != '#' && !hashtable.ContainsKey(checkTemp))
                    {
                        p.X = check.X + 1;
                        p.Y = check.Y;

                        warteschlange.Enqueue(p);

                        hashtable.Add(p, check);
                        Console.WriteLine("to hashtable: " + p.ToString() + check);
                    }
                    #endregion
                    #region Check Unten
                    checkTemp.X = check.X - 1;
                    checkTemp.Y = check.Y;
                    if (meinSpielfeld.getSpielfeld()[checkTemp.X, checkTemp.Y] != '#' && !hashtable.ContainsKey(checkTemp))
                    {
                        p.X = check.X - 1;
                        p.Y = check.Y;

                        warteschlange.Enqueue(p);

                        hashtable.Add(p, check);
                    }
                    #endregion
                    #region Check Links
                    checkTemp.X = check.X;
                    checkTemp.Y = check.Y - 1;
                    if (meinSpielfeld.getSpielfeld()[checkTemp.X, checkTemp.Y] != '#' && !hashtable.ContainsKey(checkTemp))
                    {
                        p.X = check.X;
                        p.Y = check.Y - 1;

                        warteschlange.Enqueue(p);

                        hashtable.Add(p, check);
                    }
                    #endregion
                    #region Check Rechts
                    checkTemp.X = check.X;
                    checkTemp.Y = check.Y + 1;
                    if (meinSpielfeld.getSpielfeld()[checkTemp.X, checkTemp.Y] != '#' && !hashtable.ContainsKey(checkTemp))
                    {
                        p.X = check.X;
                        p.Y = check.Y + 1;

                        warteschlange.Enqueue(p);

                        hashtable.Add(p, check);
                    }
                    #endregion
                    #endregion
                }
                else
                {
                    wegfinden(check);
                    break;
                }

                /*if ((spielerX, spielerY] != '#' && !hashtable.ContainsKey(spielerX, spielerY)
 
               {
                    //Nachbarn in die Warteschlagen laden
                    warteschlange.Enqueue(spielerX, spielerY);
                    warteschlange.Enqueue(spielerX - 1, spielerY);
                    warteschlange.Enqueue(spielerX - 1, spielerY - 1);
                    warteschlange.Enqueue(spielerX, spielerY + 1);
                    warteschlange.Enqueue(spielerX + 1, spielerY + 1);


                }*/
            }
        }
        public void wegfinden(Point ziel)
        {
            Stack myStack = new Stack(hashtable.Count);

            myStack.Push(ziel);
            foreach (Point htValues in hashtable.Values)
            {
                myStack.Push(htValues);

                /*
                if (!myStack.Contains(htValues))
                {
                    myStack.Push(htValues);
                }*/
                //Console.WriteLine(c + ". Step: " + htValues.ToString());
            }

            wegLaufen(myStack);
        }
        public void wegLaufen(Stack myStack)
        {
            //Stack myStack = new Stack(hashtable.Count);
            Point step = new Point();
            (int, int) koords;

            int c = 0;
            while (myStack.Count != 0)
            {
                step = (Point)myStack.Pop();
                koords = meinSpieler.getSpieler();
                //int xDelta, yDelta;
                c++;
                Console.WriteLine(c + ". Step: " + step.ToString());
                if (!meinSpielfeld.getEnde())
                {

                    switch (step.X - koords.Item1)
                    {
                        case -1:
                            meineFunktionen.spielerSteuerung(step.X, step.Y, -((meinSpielfeld.getHoehe()) + 1));
                            break;
                        case +1:
                            meineFunktionen.spielerSteuerung(step.X, step.Y, +((meinSpielfeld.getHoehe()) + 1));
                            break;
                    }
                    switch (step.Y - koords.Item2)
                    {
                        case -1:
                            meineFunktionen.spielerSteuerung(step.X, step.Y, -1);
                            break;
                        case +1:
                            meineFunktionen.spielerSteuerung(step.X, step.Y, +1);
                            break;
                    }/*
                else
                {
                    Application.Exit();
                }*/

                    //Console.WriteLine(htValues.ToString());
                }
            }
        }
    }
}