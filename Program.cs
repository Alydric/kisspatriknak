using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KissPatrik_Beadando
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            Random rnd = new Random();
            int generatedNumber;
            bool isEnabled = true;
            int n = 0;
            List<int> measures = new List<int>();
            List<int> alacsonySzigetek = new List<int>();

            while (isEnabled)
            {
                //----------------------------------
                measures.Clear();
                alacsonySzigetek.Clear(); //értékek resetelése
                generatedNumber = 0;
                //----------------------------------


                Console.WriteLine("Adja meg a mérésszámot 5 és 1000 között!");
                Console.Write("N: ");

                while (!int.TryParse(Console.ReadLine(), out n) || n < 5 || n > 1000) //------- mérésszám megadása és ellenőrzése
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nHelytelen bevitel!\n");
                    Console.ResetColor();
                    Console.WriteLine("Adja meg a mérésszámot 5 és 1000 között!");
                    Console.Write("N: ");
                }
                Console.WriteLine();

                generatedNumber = rnd.Next(1, 9000);
                measures.Add(generatedNumber); //indulási pont első szárazföldös mérése

                for (int i = 0; i < n - 2; i++)
                {
                    generatedNumber = rnd.Next(0, 9000);
                    measures.Add(generatedNumber); //indulás és érkezés közötti mért értékek generálása

                    if (generatedNumber > 0 && generatedNumber < 100)
                    {
                        alacsonySzigetek.Add(generatedNumber);
                    }
                }

                generatedNumber = rnd.Next(1, 9000);
                measures.Add(generatedNumber); //érkezése pont utolsó szárazföldös mérése

                for (int i = 0; i < measures.Count; i++)//mérési adatok kimutatása (igaz a feladat nem kéri de szerintem jól mutat)
                {
                    if (measures[i] > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(i + 1 + ". Mérés eredménye: " + measures[i] + "m");
                        Console.ResetColor();
                    }
                    else if (measures[i] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(i + 1 + ". Mérés eredménye: " + measures[i] + "m");
                        Console.ResetColor();
                    } 
                }

                Console.WriteLine();

                for (int i = 0; i < alacsonySzigetek.Count; i++) //100 métertől kisebb szigetek kimutatása
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("100 métertől alacsonyabb szigetek: " + alacsonySzigetek[i] + "m");
                    Console.ResetColor();
                }

                if (alacsonySzigetek.Count != 0) //100 métertől kisebb szigetek átlaga
                {
                    Console.WriteLine("100 métertől alacsonyabb szigetek átlag magassága: " + Math.Round(alacsonySzigetek.Average(), 1) + "m"); //A math.round lekerekíti a számot 2. paraméternél megadott hosszúságra
                }

                Console.WriteLine("\nA kilépéshez nyomd meg az ESC gombot vagy ENTERT a folytatáshoz!"); //egy kis bónusz 
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Escape)
                {
                    isEnabled = false;
                }
                else if (cki.Key == ConsoleKey.Enter)
                {
                    isEnabled = true;
                    Console.Clear();
                }
            }
        }
    }
}
