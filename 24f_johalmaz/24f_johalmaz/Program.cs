using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24f_johalmaz
{
    internal class Program
    {
        class Halmaz
        {
            List<int> lista;
            public Halmaz()
            {
                lista = new List<int>();
            }

            public void Add(int cucc)
            {
                lista.Insert(Helye(cucc), cucc);
            }
            private int Helye(int cucc)
            {
                int e = 0;
                int v = lista.Count-1;
                int k;
                if (lista.Count == 0)
                    return 0;
                do
                {
                    k = (e + v) / 2;
                    if (lista[k] < cucc)
                    { e = k + 1; }
                    else if (lista[k] > cucc)
                    { v = k - 1; }
                } while (e<=v && lista[k]==cucc);
                return cucc == lista[k] ? k : e;
            }
            public int Keres(int cucc)
            {
                int h = Helye(cucc);
                return lista[h] == cucc ? h : -1;
            }
            public bool Contains(int cucc)
            {
                return lista[Helye(cucc)] == cucc;
            }
            public override string ToString() => "[ "+string.Join(",", lista) + "]";
        }

        static void Main(string[] args)
        {
            Halmaz h = new Halmaz();
            h.Add(3);
            h.Add(1);
            h.Add(9);
            h.Add(8);
            h.Add(7);
            h.Add(10);
            h.Add(4);
            h.Add(3);
            h.Add(2);

            Console.WriteLine(h);
        }
    }
}
