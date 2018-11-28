using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace BMS3
{
    public class scan
    {
        private static string death = "pics/death.png";
        private static bool b_death = File.Exists(death);
        private static double death_s = ini.getskill_s(death);

        private static string WL_baff = "pics/wl_baff.png";
        private static bool b_WL_baff = File.Exists(WL_baff);
        private static double WL_baff_s = ini.getskill_s(WL_baff);

        private static string SIN_baff = "pics/sin_baff.png";
        private static bool b_SIN_baff = File.Exists(SIN_baff);
        private static double SIN_baff_s = ini.getskill_s(SIN_baff);

        private static string DST_baff = "pics/dst_baff.png";
        private static bool b_DST_baff = File.Exists(DST_baff);
        private static double DST_baff_s = ini.getskill_s(DST_baff);

        private static string BM_baff = "pics/bm_baff.png";
        private static bool b_BM_baff = File.Exists(BM_baff);
        private static double BM_baff_s = ini.getskill_s(BM_baff);

        private static string GUN_baff = "pics/gun_baff.png";
        private static bool b_GUN_baff = File.Exists(GUN_baff);
        private static double GUN_baff_s = ini.getskill_s(GUN_baff);

        private static Point lu1, lu2;
        private static int X1, Y1, X2, Y2;

        private static Thread thread;

        /// <summary>
        /// scan 2 area: 1 - baffs, 2- skills
        /// </summary>
        /// <param name="lu_b">lu baff</param>
        /// <param name="X_b">X baff</param>
        /// <param name="Y_b">Y baff</param>
        /// <param name="lu_s">lu skill</param>
        /// <param name="X_s">X skill</param>
        /// <param name="Y_s">Y skill</param>
        public scan(System.Windows.Point lu_b, int X_b, int Y_b, System.Windows.Point lu_s, int X_s, int Y_s)
        {
            lu1 = lu_b; lu2 = lu_s;
            X1 = X_b; X2 = X_s;
            Y1 = Y_b; Y2 = Y_s;

            thread = new Thread(th_start);
            thread.IsBackground = true;
        }

        public static void start()
        {
            thread.Start();
        }

        public static void stop()
        {
            ini.save();
            thread.Abort();
        }

        private static void th_start()
        {
            while (true)
            {
                double res;
                if (b_death)
                {
                    res = match.find(lu2, X2, Y2, death);
                    ini.setskill(death, res);
                    if (res > death_s)
                    {
                        
                    }
                }
                Thread.Sleep(1000);
            }
        }
    }
}