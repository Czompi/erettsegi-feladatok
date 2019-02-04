using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static e_inf_15maj.Feladatok;
using static e_inf_15maj.Fuggvenyek;

namespace e_inf_15maj
{
    class Program
    {

        #region Feladatok
        #endregion

        static void Main(string[] args)
        {
            Feladat1(out List<Megfigyeles> megfigyelesek, "veetel.txt");
            Feladat2(megfigyelesek);
            Feladat3(megfigyelesek);
            Feladat4(megfigyelesek);
            Feladat5(megfigyelesek, "adaas.txt");
            Feladat6(megfigyelesek);
            Feladat7(megfigyelesek);

            Console.Read();
        }
    }
}
