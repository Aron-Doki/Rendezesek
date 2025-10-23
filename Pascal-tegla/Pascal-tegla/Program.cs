using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pascal_tegla
{
    internal class Program
    {
        static string Input()
        {
            Console.WriteLine("Adj meg egy szöveget");
            string szoveg = Console.ReadLine();
            bool ez_egy_szam = false;
            Console.WriteLine("Add meg, hogy hány betű széles legyen a pascal-tégla");
            string szam_stringben = "";
            while (!ez_egy_szam)
            {
                string szam = Console.ReadLine();
                int a;
                if (!int.TryParse(szam, out a))
                {
                    Console.WriteLine("Nem számot adtál meg");
                    Console.WriteLine("Add meg, hogy hány betű széles legyen a pascal-tégla");
                }
                else
                {
                    szam_stringben = szam;
                    ez_egy_szam = true;
                }

            }
            return szoveg + " " + szam_stringben;
        }
        static string Bonyolitott_Pascal_tegla_input()
        {
            Console.WriteLine("Adj meg egy szöveget");
            string szoveg = Console.ReadLine();
            bool ez_egy_szam = false;
            Console.WriteLine("Add meg, hogy hány betű széles legyen a pascal-tégla");
            string szam_stringben = "";
            string masodik_tegla_hossza_stringben = "";
            for (int i = 0; i < 2; i++)
            {
                ez_egy_szam = false;
                if (i != 0)
                {
                    Console.WriteLine("Add meg a második téglalap hosszát (ha nem szeretnél második téglát, akkor -1-et adj meg)");
                }

                while (!ez_egy_szam)
                {
                    string szam = Console.ReadLine();
                    int a;
                    if (!int.TryParse(szam, out a))
                    {
                        Console.WriteLine("Nem számot adtál meg");
                        Console.WriteLine("Add meg, hogy hány betű széles legyen a pascal-tégla");
                    }
                    else
                    {
                        if (i == 0)
                        {
                            szam_stringben = szam;
                            ez_egy_szam = true;
                        }
                        else
                        {
                            masodik_tegla_hossza_stringben = szam;
                            ez_egy_szam = true;
                        }
                    }
                }
            }
            return szoveg + " " + szam_stringben + " " + masodik_tegla_hossza_stringben;
        }

        static void Pascal_tegla(string szoveg, int hossz)
        {
            char[] betuk = szoveg.ToCharArray();
            int sorok_szama = 0;
            for (int i = 0; i < betuk.Length; i++)
            {
                if (i < betuk.Length - hossz + 1)
                {
                    for (int j = 0; j < hossz; j++)
                    {
                        if (j + i < betuk.Length)
                            Console.Write(betuk[j + i] + " ");
                    }
                    Console.WriteLine();
                    sorok_szama++;
                }
            }
            int hanyfelekeppen = 0;
            hanyfelekeppen = N_alatt_k(sorok_szama + hossz, hossz);
            Console.WriteLine($"{hanyfelekeppen} féleképpen lehet a bal felső sarokból a jobb alsó sarokig eljutni");
        }
        static int Fakt(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
        static int N_alatt_k(int n, int k)
        {
            return Fakt(n) / (Fakt(k) * Fakt(n-k));
        }
        static void Nehezitett_Pascal_tegla(string szoveg, int hossz, int masodik_tegla_hossz)
        {
            char[] betuk = szoveg.ToCharArray();
            int sorok_szama = 0;

            for (int i = 0; i < betuk.Length; i++)
            {
                if (i < betuk.Length - hossz + 1)
                {
                    if ((betuk.Length - hossz + 1) / 2 <= i)
                    {
                        for (int j = 0; j < (hossz - 1) * 2; j++)
                            Console.Write(' ');
                        for (int j = 0; j < masodik_tegla_hossz; j++)
                        {
                            if (j + i + hossz - 1< betuk.Length)
                                Console.Write(betuk[j + i + hossz-1] + " ");
                        }
                    }
                    else
                    {
                        for (int j = 0; j < hossz; j++)
                        {
                            if (j + i < betuk.Length)
                                Console.Write(betuk[j + i] + " ");
                        }
                    }
                    
                    Console.WriteLine();
                    sorok_szama++;
                }
            }
        }


        static void Main(string[] args)
        {
            /*
            string input = Input();
            string[] input_szetvalasztva = input.Split(' ');
            string szoveg = input_szetvalasztva[0];
            int hossz = int.Parse(input_szetvalasztva[1]);
            Pascal_tegla(szoveg, hossz);
            */

            string bonyolitott_input = Bonyolitott_Pascal_tegla_input();
            string[] input_darabolas = bonyolitott_input.Split(' ');
            string szo = input_darabolas[0];
            int elso_tegla_hossz = int.Parse(input_darabolas[1]);
            int masodik_tegla_hossz = int.Parse(input_darabolas[2]);
            Nehezitett_Pascal_tegla(szo, elso_tegla_hossz, masodik_tegla_hossz);
        }
    }
}

