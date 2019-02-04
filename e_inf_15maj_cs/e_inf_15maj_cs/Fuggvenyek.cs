using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_inf_15maj
{
    class Fuggvenyek
    {
        #region Struktúrák, definiálások
        internal struct Megfigyeles
        {
            internal int nap, radioamator;

            //internal Char kifejlett, kolyok;
            internal String uzenet;
        };
        internal struct Dekodolt
        {
            internal int nap;
            internal String uzenet;
        };
        #endregion

        #region Függvények
        internal static void Beolvasas(out List<Megfigyeles> lst, String fileName)
        {
            lst = new List<Megfigyeles>();
            String[] lst_tmp = File.ReadAllLines(fileName);

            for (int i = 0; i < lst_tmp.Length; i = i + 2)
            {
                if (lst_tmp.Length <= 0) return;
                Megfigyeles megfigyeles = new Megfigyeles();
                megfigyeles.nap = Convert.ToInt32(lst_tmp[i].Split(' ')[0]);
                megfigyeles.radioamator = Convert.ToInt32(lst_tmp[i].Split(' ')[1]);
                megfigyeles.uzenet = lst_tmp[i + 1];
                lst.Add(megfigyeles);
            }

        }

        internal static int NapiDarab(List<Megfigyeles> lst, int nap)
        {
            int db = 0;
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].nap == nap) db++;
            }
            return db;
        }

        internal static String Dekodol(List<Megfigyeles> lst, int nap)
        {
            String dekodoltStr = "";
            List<Char> dekodolt = new List<Char>();
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].nap == nap)
                {
                    if (dekodolt.Count == 0) dekodolt = lst[i].uzenet.ToList();

                    for (int j = 0; j < dekodolt.Count; j++)
                    {
                        if (dekodolt[j] == '#' && lst[i].uzenet[j] != '#')
                        {
                            dekodolt[j] = (char)lst[i].uzenet[j];
                        }
                    }
                }
            }
            //return "";
            for (int k = 0; k < dekodolt.Count; k++)
            {
                dekodoltStr += dekodolt[k];
            }
            return dekodoltStr;
        }
        
        internal static Boolean szame(Char[] szo)
        {
            Boolean valasz = true;
            for (int i = 0; i < szo.Length; i++) if (szo[i] < '0' || szo[i] > '9') valasz = false;
            return valasz;
        }

        internal static int Egyedek(List<Megfigyeles> lst, int nap)
        {
            int db = -1;
            String dekodolt = Dekodol(lst, nap);
            if (dekodolt[1] == '/')
            {
                db = Convert.ToInt32(dekodolt[0]+"") + Convert.ToInt32(dekodolt[2] + "");
            }
            return db;
        }

        internal static Boolean Tartalmaze(List<Megfigyeles> lst, int nap, Char ch)
        {
            for (int i = 0; i < lst.Count; i++) if (lst[i].nap == nap && lst[i].uzenet.Contains(ch)) return true;
            return false;
        }

        #endregion

    }
}
