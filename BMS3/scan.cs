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
        private bool b_death = File.Exists(death);

        private static string WL_baff = "pics/wl_baff.png";
        private bool b_WL_baff = File.Exists(WL_baff);

        private static string SIN_baff = "pics/sin_baff.png";
        private bool b_SIN_baff = File.Exists(SIN_baff);

        private static string DST_baff = "pics/dst_baff.png";
        private bool b_DST_baff = File.Exists(DST_baff);

        private static string BM_baff = "pics/bm_baff.png";
        private bool b_BM_baff = File.Exists(BM_baff);

        private static string GUN_baff = "pics/gun_baff.png";
        private bool b_GUN_baff = File.Exists(GUN_baff);

        private Point _lu;
        int _X, _Y;

        private static Thread thread;

        public scan(System.Windows.Point lu, int X, int Y)
        {
            _lu = lu;
            _X = X;
            _Y = Y;

            thread = new Thread(th_start);
            thread.IsBackground = true;
        }

        public static void start()
        {
            thread.Start();
        }

        public static void stop()
        {
            thread.Abort();
        }

        private static void th_start()
        {   
            while (true)
            {                
                var q = match.find(lu, x, y, pic);
                ini.setskill("death", q);
                Dispatcher.Invoke(() =>
                {
                    label.Content = q;
                    if (q > 0.99)
                    {
                        ch4.IsChecked = true;
                    }
                    else
                    {
                        ch4.IsChecked = false;
                    }
                });
                Thread.Sleep(1000);
            }
            ini.save();
        }

    }
}