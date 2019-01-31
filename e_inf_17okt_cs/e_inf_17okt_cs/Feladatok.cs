using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static e_inf_17okt_cs.Fuggvenyek;

namespace e_inf_17okt_cs
{
    class Feladatok
    {
        internal static void Feladat1(out List<HIANYZAS> lst, String fileName, out int napok, out int sorokszama, out int bejegyzes)
        {
            Console.WriteLine("1. feladat:");

            Beolvasas(out lst, fileName, out napok, out sorokszama, out bejegyzes);
            Console.WriteLine("A beolvasás kész.");

            Console.WriteLine();
            Console.WriteLine();
        }

        internal static void Feladat2(int bejegyzes)
        {
            Console.WriteLine("2. feladat:");

            Console.WriteLine("A naplóban " + bejegyzes + " bejegyzés van.");

            Console.WriteLine();
            Console.WriteLine();
        }

        internal static void Feladat3(List<HIANYZAS> lst)
        {
            Console.WriteLine("3. feladat:");

            Console.WriteLine("Az igazolt hiányzások száma " + HianyzoDarab(lst, 'X') + ", az igazolatlanoké " + HianyzoDarab(lst, 'I') + " óra.");

            Console.WriteLine();
            Console.WriteLine();
        }

        internal static void Feladat5(List<HIANYZAS> lst)
        {
            Console.WriteLine("5. feladat:");

            int honap = 0, nap = 0;
            Console.Write("A hónap sorszáma=");
            honap = Convert.ToInt16(Console.ReadLine());
            Console.Write("A nap sorszáma=");
            nap = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Azon a napon " + hetnapja(honap, nap) + " volt.");

            Console.WriteLine();
            Console.WriteLine();
        }

        internal static void Feladat6(List<HIANYZAS> lst)
        {
            Console.WriteLine("6. feladat:");

            Console.Write("A nap neve=");
            String nap = Console.ReadLine();
            Console.Write("Az óra sorszáma=");
            int oraszam = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Ekkor összesen {0} óra hiányzás történt.", HianyzasTipusOraDarab(lst, new char[] { 'X', 'I' }, oraszam, nap));

            Console.WriteLine();
            Console.WriteLine();
        }

        internal static void Feladat7(List<HIANYZAS> lst)
        {
            Console.WriteLine("7. feladat:");

            Console.WriteLine("A legtöbbet hiányzó tanulók: " + HianyzokNeve(lst));

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
