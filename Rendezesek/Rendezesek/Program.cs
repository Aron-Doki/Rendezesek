using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendezesek
{
    internal class Program
    {
        static int Legkisebb_elem_helye_innentol(List<int> lista, int innentol)
        {
            return -1;
        }

        static void Minimumkivalasztasos_rendezes(List<int> lista) // Selection sort
        {
            // megkeressuk a legkisebbet es berakjuk a legelso helyre
            for (int i = 0; i < lista.Count-1; i++)
            {
                int mini = Legkisebb_elem_helye_innentol(lista, i);

            }
        }

        // igy is lehet: static void MergeSort(List<int> lista) => MergeSort(lista, 0, lista.Count);
        static void MergeSort(List<int> lista)
        {
            MergeSort(lista, 0, lista.Count);
        }
        static void MergeSort(List<int> lista, int e, int v)
        {
            if (2 < lista.Count)
            {
                int k = (e + v)/2;
                MergeSort(lista, e, k);
                MergeSort(lista, k+1, v);
                Merge(lista, e, k, v);
            }
        }

        static void Merge(List<int> lista, int e, int k, int v)
        {
            // Osszefesules e-k, k+1-v (ez lesz az unio)
            List<int> ideiglenes_lista = new List<int>(lista.Count);
            int i = e;
            int j = k+1;

            while (i <= k && j <= v)
            {
                if (lista[i] < lista[j])
                {
                    ideiglenes_lista.Add(lista[i]);
                    i++;
                }
                if (lista[i] > lista[j])
                {
                    ideiglenes_lista.Add(lista[j]);
                    j++;
                }
            }




        }

        static void Main(string[] args)
        {
            List<int> lista = new List<int> { 3, 0, 1, 8, 7, 2, 5, 4, 9, 6 };
        }
    }
}
