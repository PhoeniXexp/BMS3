using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS3
{
    class player
    {
        public static bool notinit = true;
        private static scheme sch1 = new scheme();
        public scheme clear()
        {
            clr();
            return sch1;
        }

        private static void clr()
        {
            sch1.b1= false; sch1.b2 = false; sch1.b3 = false; sch1.b4 = false;
            sch1.bs1 = false; sch1.bs2 = false; sch1.bs3 = false; sch1.bs4 = false;
            sch1.bf = false; sch1.bv = false; sch1.bz = false; sch1.bx = false;
            sch1.bL = false; sch1.bP = false; sch1.bPW = false;
            sch1.bSS = true; sch1.name = "";
        }

        public static scheme init()
        {
            notinit = false;

            clr();
            sch1.bP = true;
            sch1.bPW = true;

            notinit = true;
            return sch1;
        }

        public static scheme SIN()
        {
            init();
            sch1.name = name.SIN;
            return sch1;
        }

        public static scheme FM()
        {
            init();
            sch1.name = name.FM;
            return sch1;
        }

        public static scheme WL()
        {
            init();
            sch1.name = name.WL;
            return sch1;
        }

        public static scheme GUN()
        {
            init();
            sch1.name = name.GUN;
            return sch1;
        }

        public static scheme KOT()
        {
            sch1.name = name.KOT;
            return sch1;
        }

        public static scheme CI()
        {
            sch1.name = name.CI;
            return sch1;
        }

        public static scheme DST()
        {
            sch1.name = name.DST;
            return sch1;
        }

        public static scheme BM()
        {
            sch1.name = name.BM;
            return sch1;
        }

        public static scheme WAR()
        {
            sch1.name = name.WAR;
            return sch1;
        }

        public static scheme KFM()
        {
            sch1.name = name.KFM;
            return sch1;
        }

        public static scheme LSM()
        {
            sch1.name = name.LSM;
            return sch1;
        }
    }
}