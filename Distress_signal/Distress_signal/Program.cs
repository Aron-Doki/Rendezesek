using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Distress_signal
{
    internal class Program
    {
        static List<string> Olvas(int hanyadik_lista)
        {
            List<string> input = new List<string>();
            int l = 0;
            StreamReader f = new StreamReader("Distress_signal_input", Encoding.UTF8);
            while (f.EndOfStream)
            {
                if(l%3 != 0)
                    input.Add(f.ReadLine());
                
                l++;
            }
            return input;
        }




        static List<string> Elemekre_bont(List<string> lista)
        {
            int leptet = 0;
            int listaszam = 0;
            while (leptet<lista.Count)
            {
                string[] a = lista[leptet].Split(',');
                for (int i = 0; i < a.Length; i++)
                {
                    lista.Add(a[i]);
                }
            }
            return lista;
        }

        static List<List<string>> Listakra_bontas(List<string> szetszedendo)
        {
            List<string> elemekre_szedett_lista = Elemekre_bont(szetszedendo);



            List<List<string>> listak_listaja = new List<List<string>>();
            int leptet = 0;
            int zarojeltol;
            int kesz_lista = 0;
            int listaszam = 0;


            while (leptet < elemekre_szedett_lista.Count)
            {
                if (elemekre_szedett_lista[leptet] == "[")
                {
                    zarojeltol = leptet;
                    while (elemekre_szedett_lista[zarojeltol] != "]")
                    {
                        listak_listaja[kesz_lista].Add(elemekre_szedett_lista[zarojeltol]);
                        elemekre_szedett_lista.RemoveAt(zarojeltol);


                        zarojeltol++;
                    }
                    kesz_lista++;
                    leptet = 0;
                }
                else
                    leptet++;
            }
            return listak_listaja;
        }


        static void Main(string[] args)
        {



            // Feladatleiras:

            // Ha mindket elem egy szam:
            // ha a bal kisebb, mint a jobb, akkor jo a jel, ha nem akkor rossz, ha ugyan akkora, akkor a kovetkezo elem jon

            // Ha mindket elem egy lista:
            // mindket lista elso elemet kell osszehasonltani, majd a masodikat es igy tovabb
            // ha nem tortenik semmi, es a bal lista fogy ki elobb, akkor jo a jel, viszont ha a bal akkor rossz
            // ha nem tortenik semmi, es mindket lista kifut az elemekbol, akkor a kovetkezo elemet kell nezni
            // Ha az egyik elem egy lista, a masik egy szam:
            // at kell alakitani a szamot egy listava, amiben csak az az egy szam van, es ujraproba




            // Terv: Fuggveny, while ciklus, vegig megy az egesz input fileon
            // Kozben a leptetonek a szamat meg kell adni az Olvas fuggvenynek, mert az alapjan fogja megnezni a listakat
            // A whileon belul meghivjuk az "Olvas" fuggvenyt
            // Az Olvas Fuggveny visszaadja az input azon 2 listajat, amivel foglalkozni kell
            // A cikluson belul megnezem, hogy melyik feladatot kell elvegezni rajta
            // Alkalmazom a megfelelo fuggvenyt
            // Ha jo a signal, akkor elmentem, hogy ez hanyadik 2 lista volt








            List<string> feladat_sora = Olvas(1);
            List<string> teszt = new List<string>();
            for (int i = 0; i < feladat_sora.Count; i++)
            {
                teszt.Add(feladat_sora[i]);
            }


            List<List<string>> proba = Listakra_bontas(teszt);

            for (int i = 0; i < proba.Count; i++)
            {
                for (int j = 0; j < proba[i].Count; j++)
                {
                    Console.WriteLine(proba[i][j]);
                }
            }



        }
    }
}
