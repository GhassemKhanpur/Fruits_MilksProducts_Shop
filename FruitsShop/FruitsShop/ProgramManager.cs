using FruitsShop;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FruitsShop
{
    class ProgramManager
    {



        ///////////Public Methoder ////////


        public void Start() { StartMenyn(); } //starta programmet

        public string TaInmatning()//få ett string från användaren 
        {
            return Console.ReadLine();
        }
        //Kalla på StoraBokstav metoden att konvertera litte Bokstav till stro Bokstav(a-->A , m-->M ,f-->F)
        public string KonverteraTillStoraBokstavPublic(string str)
        {
            return KonverteraTillStoraBokstav(str);
        }
        public void StorLitenBokstavSpelarIngenRollMessagePublic()
        {
            StorLitenBokstavSpelarIngenRollMessage();
        }
        public void DraLinjePublic()//Göra en linje med valde stycken son standard
        {
            DraLinje();
        }
        public bool IsStringPublic(object inputedValue)//Att konterall input är float(inte alfabetisk string)
        { return IsString(inputedValue); }

        public bool IsNotEmptyStringPublic(string input)
        { return IsNotEmptyString(input); }

        public string UserInputStringPublic()// att konrollera allt input från användaren är inte tömma
        { return UserInputString(); }

        public byte UserInputNumberPublic(int min, int max)//Hantera programmet till rät rut att få ett nummer
        { return UserInputNumber(min, max); }
        public bool UserInputBoolPublic(string input)
        {
            return UserInputBool(input);
        }
        public double UserInputDoublePublic(string input)
        { return UserInputDouble(input); }

        public int UserInputIntPublic(string input)
        {
            return UserInputInt(input);
        }

        ///////////Private Methoder ////////

        private void StartMenyn()//kör bara det i första gånger när du börjar programmet 
        {
            var frukt = new Frukt();
            var mejeriprodukt = new Mejeriprodukt();

            frukt.FruktTavlanPublic(); //visa standard Frukter tavlan
            frukt.PrintFrukterListPublic();//skriva ut allt FruktList

            mejeriprodukt.MejeriproduktTavlanPublic();//visa standard Mejeriprodukter tavlan 
            mejeriprodukt.PrintMejeriproduktListPublic();//skriva ut allt MejeriproduktList

            Menyn();//visa Menyn
        }
        private void Menyn()
        {
            Console.Write("\t\t");
            DraLinje();//kalla på metoden att dra en linje

            bool value = true;

            while (value == true)
            {
                var frukt = new Frukt();//kalla på klassen Frukt i hella loopen
                var mejeriprodukt = new Mejeriprodukt(); //kalla på klassen Mejeriprodukt i hella loopen

                VisaMenynText();//Visa meny text att användaren kommer at välja

                StorLitenBokstavSpelarIngenRollMessagePublic();//en text som informera användaren kan går in stor&små bokstav

                //få ett bokstav med TaInmatning metoden =Console.ReadLine() 
                //Kalla på StoraBokstav metoden att konvertera litte Bokstav till stro Bokstav(a-->A , m-->M ,f-->F)
                switch (KonverteraTillStoraBokstav(TaInmatning()))//få bokstav och jämför den baserat av storlek
                {
                    case "F"://F som välja frukt addera
                        frukt.AdderaNyaFruktPublic();
                        value = false;//Vsluta loopen

                        StartaIgen();//starta programmet
                        break;

                    case "M"://M som välja mejeriprodukt addera

                        mejeriprodukt.AdderaNyaMejeriproduktPublic();
                        value = false;//Vsluta loopen

                        StartaIgen();//starta igen programmet

                        break;
                    case "A"://A som avsultat

                        AvsulutatProgrammet();//metoden som  avsulutat programmet

                        break;

                    default://När du skriver fell input :
                        FelBokstavValdeText();//om man skriver fell bokstav visa den meddelande

                        break;
                }

            }
        }
        private void StartaIgen() //metoden som vissa alla elementer och fråger för att addera elementer(frukter & mejeriprodukter)
        {
            var frukt = new Frukt();
            var mejeriprodukt = new Mejeriprodukt();

            Console.Clear(); //rensa skärmen

            frukt.FruktFabrikenRubrikPublic();//visa FruktFabriken text

            frukt.PrintFrukterListPublic();//skriva ut allt FrukterList

            mejeriprodukt.MejeriFabrikenRubrikPublic();//visa MejeriFabriken text

            mejeriprodukt.PrintMejeriproduktListPublic();//skriva ut allt MejeriproduktList

            Menyn();//visa Menyn och alternativ att välja att addera 1 frukt eller 1 Mejeriprodukt

        }
        private void VisaMenynText()//menyn text
        {
            Console.ForegroundColor = ConsoleColor.Yellow;//Byta färg
            Console.Write("\n\t F ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;//Byta färg
            Console.Write("= lägga til en frukt\t\t");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;//Byta färg
            Console.Write(" M ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;//Byta färg
            Console.Write("= lägga til en mjölkprodukt\t\t");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;//Byta färg
            Console.Write(" A ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;//Byta färg
            Console.Write("= Avsluta programmet\"\t\t");
            Console.ResetColor();
            Console.WriteLine();
        }
        private void AvsulutatProgrammet()
        {
            Console.ForegroundColor = ConsoleColor.Red;//Byta färg
            Console.WriteLine("Programmet kommaer att avslutas. Tryck Enter!");
            Environment.Exit(0);
        }
        private void FelBokstavValdeText()//när du skriver fel input det visa över meddelande
        {
            Console.WriteLine("Skriv rätt bokstaven");
        }

        private string KonverteraTillStoraBokstav(string str)//Den metoden som konvertera bosktav till stor bokstav
        {
            str = char.ToUpper(str[0]) + str.Substring(1);
            return str;
        }
        private void DraStandardLinje(char breakLineType, int lineLenght)//Göra en linje med valde stycken 
        {
            Console.ForegroundColor = ConsoleColor.Green;//Byta färg 
            string breakLine = new string(breakLineType, lineLenght);
            Console.Write(breakLine);
        }
        private void DraLinje()//Göra en linje med valde stycken son standard
        {
            DraStandardLinje('_', 80);
        }

        private void StorLitenBokstavSpelarIngenRollMessage()//en text som informera användaren kan går in stor&små bokstav
        {
            Console.WriteLine("Stor eller liten bokstav spelar ingen roll!\nVal:");
        }
      
        private bool IsString(object inputedValue)//Att konterall input är float(inte alfabetisk string)
        {
            bool onlyAlphas = Convert.ToString(inputedValue).All(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'));

            return onlyAlphas;

        }
  
        private bool IsNotEmptyString(string input)
        {
            bool IsEmptyOrNot = false;
            switch ((!string.IsNullOrEmpty(Convert.ToString(input)) || !string.IsNullOrWhiteSpace(Convert.ToString(input))))
            {
                case true:
                    IsEmptyOrNot = true;
                    break;

                case false:

                    break;
            }

            return IsEmptyOrNot;
        }

        private string UserInputString()// att konrollera allt input från användaren är inte tömma
        {
            string userInput = "";
            bool inputLoop = false;
            while (inputLoop == false)
            {

                userInput = Console.ReadLine();
                switch (IsNotEmptyString(userInput) && IsString(userInput))//IsStrig=(true)  (!IsStrig=false)
                {
                    case true://input är inte tömma och är en string

                        Console.WriteLine("Ok! " + userInput);


                        inputLoop = true;

                        break;

                    case false://user input är tömma så informa till användaren och börja loopen igen

                        Console.WriteLine("skriv en string ");
                        break;
                }
            }
            return userInput;
        }
   
        private byte UserInputNumber(int min, int max)//Hantera programmet till rät rut att få ett nummer
        {
            byte number = 0;
            bool validNumber = false;
            while (validNumber == false)
            {
                byte.TryParse(TaInmatning(), out number);

                switch (number <= max && number >= min)
                {
                    case true://informera till användaren angvas rätt nummer 
                        Console.WriteLine("OK! " + number);
                        validNumber = true;
                        break;

                    case false://informera till användaren angvas inte rätt nummer 
                        Console.WriteLine("skriv ett rät nummer mellan " + min + " och " + max);

                        break;
                }
            }
            return number;
        }
   
        private double UserInputDouble(string input)
        {
            double result = 00.00;
            bool loppValue = false;
            while (loppValue == false)
            {
                switch (input != string.Empty && IsString(input) == false)
                {
                    case true:
                        switch (IsAllDigits(input))
                        {
                            case true:
                                result = Convert.ToDouble(input);
                                loppValue = true;//avsluta loopen
                                break;
                            case false:
                                Console.WriteLine("skriv i rätt form");
                                input = Console.ReadLine();
                                break;
                        }

                        break;
                    case false:
                        Console.WriteLine("skriv nogånting över rätt form");
                        input = Console.ReadLine();

                        break;
                }
            }

            return result;
        }
     
        private int UserInputInt(string input)
        {
            int result = 0;
            bool loppValue = false;
            while (loppValue == false)
            {
                switch (input != string.Empty && IsString(input) == false)
                {
                    case true:
                        result = Convert.ToInt32(input);
                        loppValue = true;//avsluta loopen

                        break;
                    case false:
                        Console.WriteLine("skriv nogånting över rätt form");
                        input = Console.ReadLine();

                        break;
                }
            }
            return result;
        }
        private bool UserInputBool(string input)
        {
            bool result = false;
            bool loppValue = false;
            while (loppValue == false)
            {
                switch (input != string.Empty)
                {
                    case true:
                        switch (input)
                        {
                            case "true":
                            case "True":
                                result = Convert.ToBoolean(input);
                                loppValue = true;//avsluta loopen

                                break;

                            case "false":
                            case "False":

                                result = Convert.ToBoolean(input);
                                loppValue = true;//assluta loopen

                                break;

                            default:
                                Console.WriteLine("skriv över rätt form");

                                input = Console.ReadLine();
                                break;

                        }

                        break;
                    case false:
                        Console.WriteLine("skriv nogånting över rätt form");
                        input = Console.ReadLine();

                        break;
                }
            }

            return result;
        }
        private bool IsAllDigits(string input)//kontrolaa att all input vara siffror
        {
            foreach (char c in input)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}




