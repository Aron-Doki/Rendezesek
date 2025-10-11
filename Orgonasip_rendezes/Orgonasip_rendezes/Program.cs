using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orgonasip_rendezes
{
    internal class Program
    {

        static Random r = new Random();

        static List<int> Randomlista(int minertek, int maxertek, int minhossz, int maxhossz)
        {
            int hossz = r.Next(minhossz, maxhossz+1);
            List<int> lista = new List<int>(hossz);
            for (int i = 0; i < hossz; i++)
            {
                lista.Add(r.Next(minertek, maxertek + 1));
            }
            return lista;
        }

        static void Rendezes_Csokkeno_Sorrendben(List<int> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                int nagyobb = Legnagyobb_helye_innen(lista, i);
                Csere(lista, nagyobb, i);
            }
        }

        static int Legnagyobb_helye_innen(List<int> lista, int innen)
        {
            int eddigi_legnagyobb = innen;
            for (int i = innen+1; i < lista.Count; i++)
            {
                if (lista[i] > lista[eddigi_legnagyobb])
                {
                    eddigi_legnagyobb = i;
                }
            }
            return eddigi_legnagyobb;
        }

        static void Csere(List<int> lista, int eddigi_legnagyobb_elem, int i)
        {
            int temp = lista[eddigi_legnagyobb_elem];
            lista[eddigi_legnagyobb_elem] = lista[i];
            lista[i] = temp;
        }

        static void Kiiras(List<int> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                Console.Write(lista[i]);
                if (i != lista.Count)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static List<int> Orgonasip_rendezes(List<int> lista)
        {
            // egyik listabol egy masikba atpakolni, az elso elemet hozzaadni, a masodikat is csak siman hozzaadni, a harmadiknal meg shiftelni egyet az egeszen

            List<int> rendezett_lista = new List<int>();
            rendezett_lista.Add(lista[0]);
            for (int i = 1; i < lista.Count; i++)
            {
                if (i % 2 == 0)
                {
                    Elem_hozzaadasa_shiftelessel(rendezett_lista, lista[i]);
                }
                else
                {
                    rendezett_lista.Add(lista[i]);
                }
                
            }
            return rendezett_lista;
        }

        static void Elem_hozzaadasa_shiftelessel(List<int> lista, int hozzaadando_elem)
        {
            int temp = lista[lista.Count - 1];
            for (int i = lista.Count -1 ; i > 0; i--)
            {
                lista [i] = lista[i - 1];
            }
            lista[0] = hozzaadando_elem;
            lista.Add(temp);
        }



        static void Main(string[] args)
        {
            List<int> lista = Randomlista(1, 25, 15, 19);

            Kiiras(lista);

            Rendezes_Csokkeno_Sorrendben(lista);

            Kiiras(lista);

            List<int> rendezett_lista = Orgonasip_rendezes(lista);

            Kiiras(rendezett_lista);

        }
    }
}
