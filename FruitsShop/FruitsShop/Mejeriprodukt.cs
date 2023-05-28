using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FruitsShop
{
    class Mejeriprodukt
    {

             

        //setter och getter
        public string Namn { get; private set; }
        public string Form { get; private set; }
        public int Utgång { get; private set; }
        public double ProcentenFett { get; private set; }
        public bool LaktozfriVarde { get; private set; }
        public bool Organisk { get; private set; }

        private static List<string> MejeriproduktList = new List<String>();//bara behöver i klassen =private static Listan

        public Mejeriprodukt() { }// Standard konstruktor   


        // En sortera av Polymorfism konstruktor med standard belopper som "----" och 00.00
        public Mejeriprodukt(string aNamn = "?????", string aForm = "?????", int aUtgång = 0000, double aProcentenFett = 00.00, bool aLaktozfriVarde = false, bool aOrganisk = true)
        {
            Namn = aNamn;
            Form = aForm;
            Utgång = aUtgång;
            ProcentenFett = aProcentenFett;
            LaktozfriVarde = aLaktozfriVarde;
            Organisk = aOrganisk;

        }
        public Mejeriprodukt(List<string> aMejeriproduktList)// Overloaded konstruktor   
        {
            MejeriproduktList = aMejeriproduktList;
        }

        ///////////////////////////////Public klasser///////////////////////////////

        public string MejeriproduktText()//return MejeriproduktInfo() som skrev ut info av ett Mejeriproduk
        {
            return MejeriproduktInfo();
        }
        public void MejeriproduktTavlanPublic()
        {
            MejeriFabrikenRubrik();
            AdderaMejeriprodukterExempeler();
        }
        public void MejeriFabrikenRubrikPublic()//Rubriken och Addera och skriva ut två exempeler av Mejeriprodukter till MejeriproduktList
        {
            MejeriFabrikenRubrik(); //Rubriken av Mejeriprodukt(Välkommen till mejeriprodukt fabriken!)
            AdderaMejeriprodukterExempeler();//Addera och skriva ut två exempeler av Mejeriprodukter till MejeriproduktList
        }
        public void AdderaMejeriprodukterExempelerPublic()//Addera och skriva ut två exempeler av Mejeriprodukter till MejeriproduktList
        {
            AdderaMejeriprodukterExempeler();
        }
        public void FrogaMejeriproduktFrogorPublic(int indexNnm)//visa frogor från frukter array med få index av array i ordning
        {
            FrogaMejeriproduktFrogor(indexNnm);
        }
        public void PrintMejeriproduktListPublic()//Skriva ut allt Mejeriprodukter listan Infomationer (private)
        {
            PrintMejeriproduktList();
        }
        public void AdderaNyaMejeriproduktPublic()//Addera två exempeler av Mejeriprodukter till HuvudMejeriproduktList
        {
            AdderaNyaMejeriprodukt();
        }


        ////////////////////////////////////////privat klasser //////////////////////////////

        private void MejeriFabrikenRubrik()//Rubriken av Mejeriprodukt(Välkommen till mejeriprodukt fabriken!)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string minText = "\t__________________________| Välkommen till mejeriprodukt fabriken! |___________________________________";
            Console.WriteLine(minText);
            Console.ResetColor();
        }
        private string MejeriproduktInfo()//sorterra allt info elementer av ett Mejeriprodukt i en string
        {
            return "Produktnamn: " + Namn + " | i form: " + Form + " | Användbara dagar: " + Utgång + " | FettProcent: " + ProcentenFett + "%  | Laktozfri: " + LaktozfriVarde + " | Organisk: " + Organisk;

        }
        private void AdderaMejeriprodukterExempeler()//Addera två exempeler av Mejeriprodukter till HuvudMejeriproduktList
        {
            switch (Mejeriprodukt.MejeriproduktList.Count)
            {
                case 0:

                    //Addera exempel nummer 1 (smör)
                    var smor = new Mejeriprodukt("  smör", "fast", 12, 2.5, true, true);

                    Mejeriprodukt.MejeriproduktList.Add(smor.MejeriproduktInfo());//Addera till listan 

                    //Addera exempel nummer 2 (grädde)
                    var gradde = new Mejeriprodukt("grädde", "fast", 16, 5.5, false, false);

                    Mejeriprodukt.MejeriproduktList.Add(gradde.MejeriproduktInfo());//Addera till listan 

                    break;

            }
        }
        private void AdderaNyaMejeriprodukt()
        {
            var programManager = new ProgramManager();

            FrogaMejeriproduktFrogor(0); //kalla på froga nummer 1 från metoden
            string aNamn = programManager.UserInputStringPublic();//få  namn från användaren

            FrogaMejeriproduktFrogor(1);//kalla på froga nummer 2 från metoden
            string aForm = programManager.UserInputStringPublic(); //få  form sort från användaren

            FrogaMejeriproduktFrogor(2);//kalla på froga nummer 3 från metoden| TaInmatning metoden =Console.ReadLine
            int aUtgång = programManager.UserInputIntPublic(programManager.TaInmatning());//få  längd från användaren


            FrogaMejeriproduktFrogor(3);//kalla på froga nummer 4 från metoden
            double aProcentenFett = programManager.UserInputDoublePublic(programManager.TaInmatning());//få  längd från användaren

            FrogaMejeriproduktFrogor(4);//kalla på froga nummer 5 från metoden
            bool aLaktozfriVarde = programManager.UserInputBoolPublic(programManager.TaInmatning());//få  vikt från användaren


            FrogaMejeriproduktFrogor(5);//kalla på froga nummer 6 från metoden
            bool aOrganisk = programManager.UserInputBoolPublic(programManager.TaInmatning());//få  vikt från användaren

            //kalla på klassen med konstruktor o
            var mejeriprodukt3 = new Mejeriprodukt(aNamn, aForm, aUtgång, aProcentenFett, aLaktozfriVarde, aOrganisk);

            Mejeriprodukt.MejeriproduktList.Add(mejeriprodukt3.MejeriproduktInfo());// Addera en nya Mejeriprodukt till huvud listan

        }
        private void PrintMejeriproduktList()//Skriva ut allt Mejeriprodukter listan Infomationer (private)
        {
            Console.WriteLine("Antal listan: " + MejeriproduktList.Count);
            int counter = 1;
            foreach (var item in Mejeriprodukt.MejeriproduktList)//skriva ut två exempeler i listan 
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("*" + counter + ")");
                Console.ResetColor();
                Console.WriteLine(item);

                counter++;
            }
        }

        private void FrogaMejeriproduktFrogor(int indexNnm)//visa frogor från frukter array med få index av array i ordning
        {
            string[] mejeriproduktFrogor = { "Mejeriprodukt namn:", "I vilken form? (fast eller flytande) :", "Antal användbara dagar: ", "FettProcent: ", "Laktozfri: (true eller false) ", "Organisk: (true eller false) " };

            Console.WriteLine(mejeriproduktFrogor[indexNnm]);

        }
    }
}
