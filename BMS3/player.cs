using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS3
{
    class player
    {
        private static scheme sch1;
        public scheme clear()
        {
            clr();
            return sch1;
        }

        private void clr()
        {
            sch1.b1= false; sch1.b2 = false; sch1.b3 = false; sch1.b4 = false;
            sch1.bs1 = false; sch1.bs2 = false; sch1.bs3 = false; sch1.bs4 = false;
            sch1.bf = false; sch1.bv = false; sch1.bz = false; sch1.bx = false;
            sch1.bL = false; sch1.bP = false; sch1.bPW = false;
            sch1.bSS = true;
        }

        public scheme init()
        {
            clr();
            sch1.bP = true;
            sch1.bPW = true;
            return sch1;
        }

        public scheme SIN()
        {
            init();
            return sch1;
        }

        public scheme FM()
        {
            init();
            return sch1;
        }

        public scheme WL()
        {
            init();
            return sch1;
        }

        public scheme GUN()
        {
            init();
            return sch1;
        }

        public scheme KOT()
        {
            return sch1;
        }

        public scheme CI()
        {
            return sch1;
        }

        public scheme DST()
        {
            return sch1;
        }

        public scheme BM()
        {
            return sch1;
        }

        public scheme WAR()
        {
            return sch1;
        }

        public scheme KFM()
        {
            return sch1;
        }

        public scheme LSM()
        {
            return sch1;
        }
    }
}