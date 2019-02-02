using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static e_inf_17maj.Feladatok;
using static e_inf_17maj.Fuggvenyek;

namespace e_inf_17maj
{
    class Program
    {
        static void Main(string[] args)
        {
            Feladat1(out List<TESZT> tvalaszok, out String helyes, "valaszok.txt");
            Feladat2(tvalaszok);
            Feladat3(tvalaszok, out String szemely_valaszok);
            Feladat4(tvalaszok, helyes, szemely_valaszok);
            Feladat5(tvalaszok, helyes);
            Feladat6(tvalaszok, helyes, out List<PONTSZAMOK> psz);
            Feladat7(psz);

            //Kiiras(tvalaszok); // only for testing purposes
            Console.Read();
        }
    }
}
