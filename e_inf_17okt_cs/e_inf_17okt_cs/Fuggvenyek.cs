using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_inf_17okt_cs
{
    class Fuggvenyek
    {
        public struct HIANYZAS_szemelyek
        {
            public string vnev, knev, hianyzas;
        };

        public struct HIANYZAS
        {
            public int honap, nap;
            public List<HIANYZAS_szemelyek> szemelyek;
        };
        internal static int szemelydb(String[] str_lst, int kezdo)
        {
            int db = 0;

            for (int i = kezdo; i < str_lst.Length; i++)
            {
                // hianyzas N. feltolt
                if (str_lst[i].StartsWith("#"))
                {
                    return db;
                }
                else
                {
                    db++;
                }
            }

            return db;
        }
        internal static void Beolvasas(out List<HIANYZAS> lst, String fileName, out int napok, out int sorokszama, out int bejegyzes)
        {
            lst = new List<HIANYZAS>();
            napok = 0;
            bejegyzes = 0;
            String[] str_lst = File.ReadAllLines(fileName, Encoding.Default);
            sorokszama = str_lst.Length;
            for (int i = 0; i < str_lst.Length; i++)
            {
                // hianyzas N. feltolt
                if (str_lst[i].StartsWith("#"))
                {
                    HIANYZAS hianyzas = new HIANYZAS();
                    hianyzas.honap = Convert.ToInt32(str_lst[i].Split(' ')[1]);
                    hianyzas.nap = Convert.ToInt32(str_lst[i].Split(' ')[2]);
                    // szemelyek feltolt
                    hianyzas.szemelyek = new List<HIANYZAS_szemelyek>();
                    
                    int db = szemelydb(str_lst, i+1);

                    for (int j = 1; j <= db; j++)
                    {
                        HIANYZAS_szemelyek szemely = new HIANYZAS_szemelyek();
                        szemely.vnev = str_lst[i+j].Split(' ')[0];
                        szemely.knev = str_lst[i+j].Split(' ')[1];
                        szemely.hianyzas = str_lst[i+j].Split(' ')[2];
                        hianyzas.szemelyek.Add(szemely);
                    }

                    lst.Add(hianyzas);
                }
            }
            for (int i = 0; i < str_lst.Length; i++)
            {
                if (!str_lst[i].StartsWith("#"))
                {
                    bejegyzes++;
                }
            }
            napok = sorokszama - bejegyzes;
        }

        internal static void Kiiras(List<HIANYZAS> lst)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                Console.WriteLine(lst[i].honap + " " + lst[i].nap);
                // szemelyek feltolt
                i++;
                try
                {
                    for (int j = 0; j < lst[i].szemelyek.Count; j++)
                    {
                        Console.WriteLine("\t- " + lst[i].szemelyek[j].vnev + " " + lst[i].szemelyek[j].knev + " :: " + lst[i].szemelyek[j].hianyzas);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        internal static string hetnapja(int honap, int nap)
        {
            //String[] napnev = new String[] {"vasarnap", "hetfo", "kedd", "szerda", "csutortok", "pentek", "szombat"};
            int[] napszam = new int[] { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 335 };

            switch ((napszam[honap - 1] + nap) % 7)
            {
                case 1:
                    return "hetfo";
                case 2:
                    return "kedd";
                case 3:
                    return "szerda";
                case 4:
                    return "csutortok";
                case 5:
                    return "pentek";
                case 6:
                    return "szombat";
                case 0:
                    return "vasarnap";
                default:
                    return "";
            }
        }


        internal static int HianyzasTipusDarab(HIANYZAS lst, char tipus)
        {
            int db = 0;
            for (int i = 0; i < lst.szemelyek.Count; i++)
            {
                Char[] hiany = lst.szemelyek[i].hianyzas.ToCharArray();
                for (int j = 0; j < hiany.Length; j++) if (hiany[j] == tipus) db++;
            }
            return db;
        }

        internal static int SzemelyHianyzasTipusDarab(List<HIANYZAS> lst, String vnev, String knev)
        {
            int db = 0;
            for (int i = 0; i < lst.Count; i++)
            {
                for (int j = 0; j < lst[i].szemelyek.Count; j++)
                {
                    Char[] hiany = lst[i].szemelyek[j].hianyzas.ToCharArray();
                    for (int k = 0; k < hiany.Length; k++) if ((hiany[k] == 'I' || hiany[k] == 'X') && lst[i].szemelyek[j].vnev == vnev && lst[i].szemelyek[j].knev == knev) db++;
                }
            }
            return db;
        }

        internal static int MaxHianyzas(List<HIANYZAS> lst)
        {
            int max = SzemelyHianyzasTipusDarab(lst, lst[0].szemelyek[0].vnev, lst[0].szemelyek[0].knev);
            for (int i = 0; i < lst.Count; i++)
                for (int j = 0; j < lst[i].szemelyek.Count; j++)
                    if (max < SzemelyHianyzasTipusDarab(lst, lst[i].szemelyek[j].vnev, lst[i].szemelyek[j].knev))
                        max = SzemelyHianyzasTipusDarab(lst, lst[i].szemelyek[j].vnev, lst[i].szemelyek[j].knev);
            return max;
        }

        internal static String HianyzokNeve(List<HIANYZAS> lst)
        {
            String nevek = "";
            int max = MaxHianyzas(lst);
            for (int i = 0; i < lst.Count; i++)
            {
                for (int j = 0; j < lst[i].szemelyek.Count; j++)
                {
                    if (SzemelyHianyzasTipusDarab(lst, lst[i].szemelyek[j].vnev, lst[i].szemelyek[j].knev) == max)
                    {
                        nevek += lst[i].szemelyek[j].vnev + " " + lst[i].szemelyek[j].knev + ",";
                    }
                }
            }
            String[] nevlista = nevek.Split(',');
            List<String> nevl = new List<String>();
            for (int i = 0; i < nevlista.Length; i++)
            {
                if (!nevl.Contains(nevlista[i]))
                {
                    nevl.Add(nevlista[i]);
                }
            }

            String veglegeslista = "";
            for (int i = 0; i < nevl.Count; i++)
            {
                veglegeslista += nevl[i] + " ";
            }
            return veglegeslista;
        }

        internal static int HianyzasTipusOraDarab(List<HIANYZAS> lst, char[] tipus, int oraszam, string nap)
        {
            int db = 0;
            for (int i = 0; i < lst.Count; i++)
                for (int j = 0; j < lst[i].szemelyek.Count; j++) if (hetnapja(lst[i].honap, lst[i].nap) == nap)
                        for (int k = 0; k < tipus.Length; k++) if (lst[i].szemelyek[j].hianyzas[oraszam - 1] == tipus[k]) db++;
            return db;
        }

        internal static int HianyzoDarab(List<HIANYZAS> lst, char tipus)
        {
            int db = 0;
            for (int i = 0; i < lst.Count; i++) db += HianyzasTipusDarab(lst[i], tipus);
            return db;
        }
    }
}
