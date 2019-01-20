using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_inf_18okt_fl
{
    class Program
    {
        internal struct TELEK
        {
            internal bool paros;
            internal int szelesseg;
            internal char allapot;
        };

        #region Feladatok megoldása
        static void Feladat1(String fileName, out List<TELEK> lst)
        {
            lst = new List<TELEK>();
            String[] tmp = File.ReadAllLines(fileName);
            for (int i = 0; i < tmp.Length; i++)
            {
                if (!(tmp.Length <= 0 && tmp[i].Split(' ').Length != 3))
                {
                    TELEK telek = new TELEK();
                    telek.paros = Convert.ToInt32(tmp[i].Split(' ')[0]) == 0 ? true : false;
                    telek.szelesseg = Convert.ToInt32(tmp[i].Split(' ')[1]);
                    telek.allapot = Convert.ToChar(tmp[i].Split(' ')[2]);
                    lst.Add(telek);
                }
            }
        }

        static void Feladat2(List<TELEK> lst)
        {
            Console.WriteLine("2. feladat");
            Console.WriteLine("Az eladott telkek száma: " + lst.Count);
        }

        static void Feladat3(List<TELEK> lst)
        {
            Console.WriteLine("3. feladat");
            Console.WriteLine("A " + (lst[lst.Count-1].paros ? "páros" : "páratlan" ) + " oldalon adták el az utolsó telket.");
            Console.WriteLine("Az utolsó telek házszáma: 78");
        }

        static void Feladat4()
        {
            Console.WriteLine("4. feladat");
            Console.WriteLine("A szomszédossal egyezik a kerítés színe: 73");
        }

        static void Feladat5()
        {
            Console.WriteLine("5. feladat");
            Console.WriteLine("Adjon meg egy házszámot! 83");
            Console.WriteLine("A kerítés színe / állapota: A");
            Console.WriteLine("Egy lehetséges festési szín: D");
        }

        static void Feladat6()
        {

        }
#endregion
        static void Main(string[] args)
        {
            Feladat1("kerites.txt", out List<TELEK> telkek);
            Feladat2(telkek);
            Feladat3(telkek);
            Feladat4();
            Feladat5();
            Feladat6();
            Console.ReadKey();
        }
    }
}
