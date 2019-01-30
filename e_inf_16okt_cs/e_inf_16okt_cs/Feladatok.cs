using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static e_inf_16okt_cs.Fuggvenyek;

namespace e_inf_16okt_cs
{
    internal class Feladatok
    {
        internal static void Feladat1()
        {
            Console.WriteLine("1. feladat:");
            Console.WriteLine("A feladat végrehajtva.");
            Console.WriteLine();
            Console.WriteLine();
        }


        internal static void Feladat2(out List<HIVAS> lst, String fileName)
        {
            Console.WriteLine("2. feladat:");
            Beolvasas(fileName, out lst);
            Console.WriteLine("A feladat végrehajtva.");
            Console.WriteLine();
            Console.WriteLine();
        }

        internal static void Feladat3(List<HIVAS> lst)
        {
            Console.WriteLine("3. feladat:");
            for (int i = 0; i <= 12; i++)
            {
                Console.WriteLine((i + 6) + " óra: " + DarabOraban(lst, new IDO(i + 6, 0, 0).ToSeconds(), new IDO(i + 6, 59, 59).ToSeconds()) + " hívás");
            }
            Console.WriteLine("A feladat végrehajtva.");
            Console.WriteLine();
            Console.WriteLine();
        }

        internal static void Feladat4(List<HIVAS> lst)
        {
            Console.WriteLine("4. feladat:");

            Console.WriteLine("A leghosszabb ideig vonalban lévő hívó a " + MaxKivalasztas(lst).sorszam + ". sorban szerepel,");
            Console.WriteLine("a hívásának hossza: " + MaxKivalasztas(lst).hossz + " másodperc.");
            Console.WriteLine();
            Console.WriteLine();
        }

        internal static void Feladat5(List<HIVAS> lst)
        {
            Console.WriteLine("5. feladat:");
            Console.Write("Adj meg egy időpontot (ó p mp formában): ");
            String idopont = Console.ReadLine();
            IDOPONTADAT ia = IdopontAdatok(lst, new IDO(idopont.Replace(' ', ':')));
            if (ia.varakozok == -1) Console.WriteLine("");
            else Console.WriteLine("Jelenleg " + ia.varakozok + " várakozó van, éppen a " + ia.vonalban + ". hívó van vonalban.");
            Console.WriteLine();
            Console.WriteLine();
        }

        internal static void Feladat6(List<HIVAS> lst)
        {
            Console.WriteLine("6. feladat:");
            TELEFONALOADATOK adat = UtolsoTelefonalo(lst);
            Console.WriteLine("Az utolsó telefonáló adatai a " + adat.hivasinfo + ". sorban vannak, a sorra kerülésig " + adat.varakozasi_ido + " másodpercet várt.");
            Console.WriteLine();
            Console.WriteLine();
        }
        internal static void Feladat7(List<HIVAS> lst, String fileName)
        {
            Console.WriteLine("7. feladat:");
            List<HIVASKI> ki = TelefonaloAdatok(lst);
            List<String> out_datas = new List<String>();
            for (int i = 0; i < ki.Count; i++)
            {
                out_datas.Add(ki[i].id + " " + ki[i].hivas.kezdo.GetTime().Replace(':', ' ') + " " + ki[i].hivas.veg.GetTime().Replace(':', ' '));
            }
            File.WriteAllLines(fileName, out_datas);
            Console.WriteLine("A fájlba írás sikeresen befejeződött");
            Console.WriteLine();
        }
    }
}