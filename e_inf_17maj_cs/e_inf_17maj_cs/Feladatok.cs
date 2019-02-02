using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static e_inf_17maj.Fuggvenyek;

namespace e_inf_17maj
{
    class Feladatok
    {
        #region Feladat1
        internal static void Feladat1(out List<TESZT> lst, out String helyes, String fileName)
        {
            Console.WriteLine("1. feladat: Adatok beolvasása.");

            Feltoltes(out lst, out helyes, fileName);

            Console.WriteLine(); Console.WriteLine();
        }
        #endregion

        #region Feladat2
        internal static void Feladat2(List<TESZT> vek)
        {
            Console.Write("2. feladat: ");

            Console.WriteLine("A vetélkedőn {0} versenyző indult.", vek.Count);

            Console.WriteLine(); Console.WriteLine();
        }
        #endregion

        #region Feladat3
        internal static void Feladat3(List<TESZT> vek, out String szemely_valaszok)
        {
            Console.Write("3. feladat: ");

            Console.Write("A versenyző azonosítója = ");
            String veraz = Console.ReadLine();
            veraz = veraz.ToUpper();
            szemely_valaszok = ver_valaszok(vek, veraz);
            Console.WriteLine("{0}\t(a versenyző válasza)", ver_valaszok(vek, veraz));

            Console.WriteLine(); Console.WriteLine();
        }
        #endregion

        #region Feladat4
        internal static void Feladat4(List<TESZT> vek, String helyes, String szemely_valaszok)
        {
            Console.WriteLine("4. feladat: ");

            Console.WriteLine("{0}\t(a helyes megoldás)", helyes);
            Console.WriteLine("{0}\t(a versenyző helyes válaszai)", val_hely(szemely_valaszok, helyes));

            Console.WriteLine();
            Console.WriteLine();
        }
        #endregion

        #region Feladat5
        internal static void Feladat5(List<TESZT> vek, String helyes)
        {
            Console.Write("5. feladat: ");

            Console.Write("A feladat sorszáma = ");
            int sorsz = Convert.ToInt32(Console.ReadLine());
            double helyesint = helyesfo(vek, helyes, sorsz);
            Console.WriteLine("A feladara {0} fő, a versenyzők {1:F2}%-a adott helyes választ.", helyesint, (double)(helyesint / vek.Count) * 100);

            Console.WriteLine();
            Console.WriteLine();
        }
        #endregion

        #region Feladat6
        internal static void Feladat6(List<TESZT> vek, String helyes, out List<PONTSZAMOK> psz)
        {
            Console.WriteLine("6. feladat: A versenyzők pontszámának meghatározása.");

            psz = new List<PONTSZAMOK>();


            for (int i = 0; i < vek.Count; i++)
            {
                PONTSZAMOK pontszam = new PONTSZAMOK();
                pontszam.szaz = vek[i].szaz;
                pontszam.pont = val_hely_sulyozott(vek[i].valaszok, helyes);
                psz.Add(pontszam);

            }

            File.WriteAllLines("pontok.txt", Kiirat(psz));

            Console.WriteLine();
            Console.WriteLine();
        }
        #endregion

        #region Feladat7
        internal static void Feladat7(List<PONTSZAMOK> lst)
        {
            Console.WriteLine("7. feladat: ");

            List<PONTSZAMOK> rendezett = lst.OrderByDescending(n => n.pont).ToList();

            int i = 0, max = 3, curr = 3;
            while (i < rendezett.Count && curr != 0)
            {

                Console.WriteLine((max - curr + 1) + ". díj (" + rendezett[i].pont + " pont): " + rendezett[i].szaz);
                if (!(rendezett[i].pont == rendezett[i + 1].pont)) curr--;
                i++;
            }

            Console.WriteLine();
            Console.WriteLine();
        }
        #endregion

    }
}
