using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static e_inf_15maj.Fuggvenyek;

namespace e_inf_15maj
{
    class Feladatok
    {
        internal static void Feladat1(out List<Megfigyeles> lst, String fileName)
        {
            Beolvasas(out lst, fileName);
        }
        internal static void Feladat2(List<Megfigyeles> lst)
        {
            Console.WriteLine("2. feladat:");
            Console.WriteLine();
            Console.WriteLine("Az első üzenet rögzítője: " + lst[0].radioamator);
            Console.WriteLine("Az utolsó üzenet rögzítője: " + lst[lst.Count - 1].radioamator);
            Console.WriteLine();
            Console.WriteLine();
        }
        internal static void Feladat3(List<Megfigyeles> lst)
        {
            Console.WriteLine("3. feladat:");
            Console.WriteLine();
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].uzenet.Contains("farkas"))
                {
                    Console.WriteLine(lst[i].nap + ". nap: " + lst[i].radioamator + ". rádióamatőr");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        internal static void Feladat4(List<Megfigyeles> lst)
        {
            Console.WriteLine("4. feladat:");
            Console.WriteLine();
            for (int i = 1; i < 20 + 1; i++)
            {
                if(NapiDarab(lst, i) > 0) Console.WriteLine(i + ". nap: " + NapiDarab(lst, i) + " rádióamatőr");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        internal static void Feladat5(List<Megfigyeles> lst, String fileName)
        {
            Console.WriteLine("5. feladat: Fájlba írás.");

            List<String> dekodolt = new List<String>();
            for (int i = 1; i <= 20; i++)
            {
                dekodolt.Add(Dekodol(lst, i));
            }
            File.WriteAllLines(fileName, dekodolt);

            Console.WriteLine();
            Console.WriteLine();
        }
        internal static void Feladat6(List<Megfigyeles> lst)
        {
            Console.WriteLine("6. feladat: Függvény létrehozása sikeres.");
            Console.WriteLine();
            Console.WriteLine();
        }
        internal static void Feladat7(List<Megfigyeles> lst)
        {
            Console.WriteLine("7. feladat:");
            Console.WriteLine();
            Console.Write("Adja meg a nap sorszámát! ");
            int nap = Convert.ToInt32(Console.ReadLine());
            Console.Write("Adja meg a rádióamatőr sorszámát! ");
            int radioamator = Convert.ToInt32(Console.ReadLine());
            if (Tartalmaze(lst, nap, '/'))
            {
                int egyedek = Egyedek(lst, nap);
                if (egyedek == -1) Console.WriteLine("Nincs információ.");
                else Console.WriteLine("A megfigyelt egyedek száma: " + egyedek);
            }
            else Console.WriteLine("Nincs ilyen feljegyzés");

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
