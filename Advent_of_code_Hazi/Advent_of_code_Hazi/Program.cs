using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_code_Hazi
{
    internal class Program
    {
        static List<int>[] Beolvasas(string fajlnev)
        {
            List<int>[] Listak_tombje = new List<int>[2];
            List<int> bal_sor   = new List<int>();
            List<int> jobb_sor = new List<int>();

            StreamReader f = new StreamReader(fajlnev, Encoding.UTF8);
            while (!f.EndOfStream)
            {
                string[] sor = f.ReadLine().Split(' ');
                bal_sor.Add(int.Parse(sor[0]));
                jobb_sor.Add(int.Parse(sor[3]));
            }
            Listak_tombje[0] = bal_sor;
            Listak_tombje[1] = jobb_sor;
            return Listak_tombje;
        }
        
        static void Rendezes_novekvo_sorrendben(List<int> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                int kisebb = Legkisebb_helye_innen(lista, i);
                Kicserel(lista, kisebb, i);
            }
        }

        static int Legkisebb_helye_innen(List<int> lista, int innen)
        {
            int kisebb_elem = innen;
            for (int i = innen+1; i < lista.Count; i++)
            {
                if (lista[i] < lista[kisebb_elem])
                {
                    kisebb_elem = i;
                }
            }
            return kisebb_elem;
        }

        static void Kicserel(List<int> lista, int i, int j)
        {
            int temp = lista[i];
            lista[i] = lista[j];
            lista[j] = temp;
        }
        static void Main(string[] args)
        {
            int szam = 0;
            List<int>[] input = Beolvasas("input_hazi.txt");

            Rendezes_novekvo_sorrendben(input[0]);
            Rendezes_novekvo_sorrendben(input[1]);

            for (int i = 0; i < input[0].Count; i++)
            {
                int a = input[0][i] - input[1][i];
                if (a < 0)
                {
                    a = a * -1;
                }
                szam += a;
            }

            Console.WriteLine(szam);
        }
    }
}
