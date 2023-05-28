using FruitsShop;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FruitsShop
{
    class Frukt
    {
        //setter och getter
        public string Namn { get; private set; }
        public string Farg { get; private set; }
        public double Kcal { get; private set; }
        public double Pris { get; private set; }
        public bool AtbarVarde { get; private set; }
        public bool SkalVarde { get; private set; }

        private static List<string> FrukterList = new List<String>();//bara behöver i klassen =private static Listan

        public Frukt() { }// Standard konstruktor     

        // En sortera av Polymorfism konstruktor med standard belopper som "----" och 00.00
        public Frukt(string aNamn = "?????", string aFarg = "?????", double aKcal = 00.00, double aPris = 00.00, bool aAtbarVarde = false, bool aSkalVarde = false)
        {
            Namn = aNamn;
            Farg = aFarg;
            Kcal = aKcal;
            Pris = aPris;
            AtbarVarde = aAtbarVarde;
            SkalVarde = aSkalVarde;

        }
        public Frukt(List<string> aFrukterList)// Overloaded konstruktor   
        {
            FrukterList = aFrukterList;
        }

        ////////////////////////////////////Public klasser ///////////////////////////////////////

        public string FruktText()
        {
            return FruktInfo();
        }
        public void FruktTavlanPublic()//Visa rubriken och Addera och skriva ut två exempeler av frukter till FrukterList
        {
            FruktFabrikenRubrik(); //Visa rubriken
            AdderaFrukterExempeler();//Addera och skriva ut två exempeler av frukter till FrukterList metoden
        }
        public void FruktFabrikenRubrikPublic()//Visa rubriken
        {
            FruktFabrikenRubrik();
        }
        public void AdderaFrukterExempelerPublic()//Addera och skriva ut två exempeler av frukter till FrukterList
        {
            AdderaFrukterExempeler();
        }
        public void FrogaFruktFrogorPublic(int indexNnm)//visa frogor från frukter array med få index av array i ordning
        {
            FrogaFruktFrogor(indexNnm);
        }
        public void PrintFrukterListPublic()//Skriva ut allt Mejeriprodukter listan Infomationer (private)
        {
            PrintFrukterList();
        }
        public void AdderaNyaFruktPublic()//Addera två exempeler av Mejeriprodukter till HuvudMejeriproduktList
        {
            AdderaNyaFrukt();
        }

        ////////////////////////////////////privat klasser ///////////////////////////////////////

        private void FruktFabrikenRubrik()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            string minText = "\n\t_____________________________| Välkommen till frukt fabriken! |________________________________________";
            Console.WriteLine(minText);
            Console.ResetColor();
        }
        private string FruktInfo()
        {
            return "Fruktnamn: " + Namn + " | färg: " + Farg + " | Kcal: " + Kcal + " | Frukt pris " + Pris + "kr. | har ätbar: " + AtbarVarde + " | har Skal: " + SkalVarde;

        }
        private void AdderaFrukterExempeler()//Addera två exempeler av Mejeriprodukter till HuvudMejeriproduktList
        {
            switch (Frukt.FrukterList.Count)//count=o betyder vi har sjrivit nånting på listan före(det ät första gång)
            {
                case 0:

                    //Addera exempel nummer 1 (päron)
                    var paron = new Frukt("  päron  ", "gul", 12.5, 150.50, false, true);

                    Frukt.FrukterList.Add(paron.FruktInfo());//Addera till listan 

                    //Addera exempel nummer 1 (jordgubbe)
                    var jordgubbe = new Frukt("jordgubbe", "röd", 15.5, 120.50, false, false);

                    Frukt.FrukterList.Add(jordgubbe.FruktInfo());//Addera till listan 
                    break;
            }
        }
        private void AdderaNyaFrukt()//Addera två exempeler av Mejeriprodukter till HuvudMejeriproduktList
        {
            var programManager = new ProgramManager();

            FrogaFruktFrogor(0); //kalla på froga nummer 1 från metoden
            string aNamn = programManager.UserInputStringPublic();//få  namn från användaren

            FrogaFruktFrogor(1);//kalla på froga nummer 2 från metoden
            string aFarg = programManager.UserInputStringPublic(); //få färg från användaren


            FrogaFruktFrogor(2);//kalla på froga nummer 3 från metoden| TaInmatning metoden =Console.ReadLine
            double aKcal = programManager.UserInputDoublePublic(programManager.TaInmatning());//få  längd från användaren


            FrogaFruktFrogor(3);//kalla på froga nummer 4 från metoden
            double aPris = programManager.UserInputDoublePublic(programManager.TaInmatning());//få  längd från användaren

            FrogaFruktFrogor(4);//kalla på froga nummer 5 från metoden
            bool aAtbarVarde = programManager.UserInputBoolPublic(programManager.TaInmatning());//få  vikt från användaren


            FrogaFruktFrogor(5);//kalla på froga nummer 6 från metoden
            bool aSkalVarde = programManager.UserInputBoolPublic(programManager.TaInmatning());//få  vikt från användaren

            //kalla på klassen med konstruktor och Addera en nya frukt
            var frukt3 = new Frukt(aNamn, aFarg, aKcal, aPris, aAtbarVarde, aSkalVarde);//kalla på klassen med konstruktor 

            Frukt.FrukterList.Add(frukt3.FruktInfo());// Addera en nya frukt till huvud listan

        }
        private void PrintFrukterList()//Skriva ut allt Mejeriprodukter listan Infomationer (private)
        {
            Console.WriteLine("Antal listan: " + FrukterList.Count);

            int counter = 1;//att skriva listan elementer nummer räkna från sista elementer tal +1
            foreach (var item in Frukt.FrukterList)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("*" + (counter));
                Console.ResetColor();
                Console.Write(" " + item);//skriva ut item
                Console.WriteLine();

                counter++;
            }
        }
        private void FrogaFruktFrogor(int indexNum)//visa frogor från frukter array med få index av array i ordning
        {
            string[] fruktFrogor = { "Fruktnamn:", "Färg:", "Hur mycket energi den har(Kcal)?  ", "Frukt pris:  ", "Har ätbar? (true eller false) ", "Har Skal?  (true eller false)  " };

            Console.WriteLine(fruktFrogor[indexNum]);
        }
        ////private string SorteraInputNamn(string namn)
        ////{
        ////    string namnDelade="";
        ////    switch (namn.Length>10)
        ////    {
        ////        case true:
        ////            namnDelade= namn.Substring(10);
        ////            break;

        ////        case false:
        ////            namnDelade = namn;
        ////            break;
        ////    }
        ////    return namnDelade;
        ////}
    }
}




