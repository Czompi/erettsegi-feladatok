using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static e_inf_17okt_cs.Fuggvenyek;
using static e_inf_17okt_cs.Feladatok;

namespace e_inf_17okt_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            List<HIANYZAS> hianyzasok;
            Feladat1(out hianyzasok, "naplo.txt", out int napoksz, out int soroksz, out int bejegyzesek);
            Feladat2(bejegyzesek);
            Feladat3(hianyzasok);
            Feladat5(hianyzasok);
            Feladat6(hianyzasok);
            Feladat7(hianyzasok);

            //Kiiras(hianyzasok);
            Console.Read();
        }
    }
}
