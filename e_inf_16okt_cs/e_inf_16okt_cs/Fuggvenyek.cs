using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_inf_16okt_cs
{
    class Fuggvenyek
    {
        
        internal class IDO
        {
            internal int o, p, mp;
            internal IDO(String ido)
            {
                String[] ido_arr = ido.Split(':');
                o = Convert.ToInt32(ido_arr[0]);
                p = ido_arr.Length >= 2 ? Convert.ToInt32(ido_arr[1]) : 0;
                mp = ido_arr.Length == 3 ? Convert.ToInt32(ido_arr[2]) : 0;
            }
            public IDO(int o, int p, int mp)
            {
                this.o = o;
                this.p = p;
                this.mp = mp;
            }
            public IDO(double mp)
            {
                TimeSpan timeSpan = new TimeSpan(((long)mp)*TimeSpan.TicksPerSecond);
                this.o = timeSpan.Hours;
                this.p = timeSpan.Minutes;
                this.mp = timeSpan.Seconds;
            }
            internal IDO() { }

            internal String GetTime()
            {
                return o + ":" + p + ":" + mp;
            }

            internal protected double mpbe(int o, int p, int mp)
            {
                return new TimeSpan(o, p, mp).TotalSeconds;
            }

            internal double ToSeconds()
            {
                return mpbe(o, p, mp);
            }
            };

        internal static double nyitas = new IDO("8:00:00").ToSeconds();
        internal static double zaras = new IDO("12:00:00").ToSeconds();
        internal static double hivaskezdet = new IDO("6:00:00").ToSeconds();
        internal static double hivasveg = new IDO("18:00:00").ToSeconds();

        internal class HIVAS
        {
            internal IDO kezdo, veg;
        }

        internal class HIVASKI
        {
            internal int id;
            internal HIVAS hivas;
        }
        
        internal class HIVASINFO
        {
            internal int sorszam;
            internal double hossz;
            internal HIVAS hivas;
        }

        internal class IDOPONTADAT
        {
            internal int varakozok;
            internal int vonalban;
        }

        internal class TELEFONALOADATOK
        {
            internal int hivasinfo;
            internal double varakozasi_ido;
        }

        internal static void Beolvasas(string fileName, out List<HIVAS> lst)
        {
            lst = new List<HIVAS>();
            String[] file = File.ReadAllLines(fileName);
            for (int i = 0; i < file.Length; i++)
            {
                if (file[i] == "") continue;
                HIVAS hivas = new HIVAS();
                IDO kezdo = new IDO(Convert.ToInt32(file[i].Split(' ')[0]), Convert.ToInt32(file[i].Split(' ')[1]), Convert.ToInt32(file[i].Split(' ')[2]));
                hivas.kezdo = kezdo;
                IDO veg = new IDO(Convert.ToInt32(file[i].Split(' ')[3]), Convert.ToInt32(file[i].Split(' ')[4]), Convert.ToInt32(file[i].Split(' ')[5]));
                hivas.veg = veg;
                lst.Add(hivas);
            }
        }

        internal static void Kiiras(List<HIVAS> lst)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                Console.WriteLine("Kezdete: " + lst[i].kezdo.GetTime() + "; Vége: " + lst[i].kezdo.GetTime());
            }
        }

        internal static int DarabOraban(List<HIVAS> lst, double mettol, double meddig)
        {
            int db = 0;
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].kezdo.ToSeconds() >= mettol && lst[i].kezdo.ToSeconds() <= meddig) db++;
            }
            return db;
        }

        internal static int Vonalban(List<HIVAS> lst, double idopont)
        {
            int db = 0;
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].veg.ToSeconds() >= idopont && lst[i].veg.ToSeconds() <idopont+3600) return i;
            }
            return db;
        }

        internal static HIVASINFO MaxKivalasztas(List<HIVAS> lst)
        {
            HIVASINFO hivasinfo = new HIVASINFO();
            int sorszam = 0;
            double maxido = lst[0].veg.ToSeconds() - lst[0].kezdo.ToSeconds();
            for (int i = 0; i < lst.Count; i++)
            {
                double currentln = lst[i].veg.ToSeconds() - lst[i].kezdo.ToSeconds();
                if (currentln > maxido) { maxido = currentln; sorszam = i; }
            }
            hivasinfo.hivas = lst[sorszam];
            hivasinfo.sorszam = sorszam + 1;
            hivasinfo.hossz = maxido;
            return hivasinfo;
        }

        internal static IDOPONTADAT IdopontAdatok(List<HIVAS> lst, IDO idopont)
        {
            IDOPONTADAT ia = new IDOPONTADAT();

            //ia.varakozok = -1;
            int db = -1;
            for (int i = 0; i < lst.Count; i++)
                if (lst[i].kezdo.ToSeconds() <= idopont.ToSeconds() && lst[i].veg.ToSeconds() > idopont.ToSeconds()) db++;
            ia.varakozok = db;
            ia.vonalban = Vonalban(lst, idopont.ToSeconds()) + 1;

            return ia;
        }

        internal static TELEFONALOADATOK UtolsoTelefonalo(List<HIVAS> lst)
        {
            TELEFONALOADATOK adatok = new TELEFONALOADATOK();

            int utso = 0, utsoelott = 0;

            for (int i = 0; i < lst.Count; i++) {
                if(lst[i].kezdo.ToSeconds() <= zaras && lst[i].veg.ToSeconds() > lst[utso].veg.ToSeconds())
                {
                    utsoelott = utso;
                    utso = i;
                }
            }

            adatok.hivasinfo = utso+1;
            adatok.varakozasi_ido = Math.Max(0, lst[utsoelott].veg.ToSeconds() - lst[utso].kezdo.ToSeconds());
            return adatok;
        }

        internal static List<HIVASKI> TelefonaloAdatok(List<HIVAS> lst)
        {
            List<HIVASKI> adatok = new List<HIVASKI>();

            int talk = 0;

            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].veg.ToSeconds() >= nyitas && lst[i].kezdo.ToSeconds() <= zaras && lst[i].veg.ToSeconds() > lst[talk].veg.ToSeconds()) {
                    HIVASKI adat = new HIVASKI();
                    adat.hivas = new HIVAS();
                    adat.id = i+1;
                    double vege = Math.Max(lst[i].kezdo.ToSeconds(), lst[talk].veg.ToSeconds());
                    adat.hivas.kezdo = new IDO(Math.Max(nyitas, vege));
                    adat.hivas.veg = lst[i].veg;
                    adatok.Add(adat);
                    talk = i;
                }
            }
            return adatok;
        }
    }
}
