using System;
using System.Collections.Generic;
using static e_inf_16okt_cs.Fuggvenyek;
using static e_inf_16okt_cs.Feladatok;

namespace e_inf_16okt_cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Feladat1();
            Feladat2(out List<HIVAS> hivasok, "hivas.txt");
            Feladat3(hivasok);
            Feladat4(hivasok);
            Feladat5(hivasok);
            Feladat6(hivasok);
            Feladat7(hivasok, "sikeres.txt");

            Console.Read();
        }
    }
}
