using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Point = System.Windows.Point;
using Size = System.Drawing.Size;

namespace BMS3
{
    class mimage
    {
        public static Point lu = new Point(0, 0);
        public static int X = 0;
        public static int Y = 0;

        /// <summary>
        /// Return Bitmap in lu-point and X, Y
        /// </summary>
        public static Bitmap img_bitmap
        {
            get
            {
                Bitmap img = new Bitmap(X, Y);
                using (Graphics g = Graphics.FromImage(img))
                {
                    int x = (int)lu.X;
                    int y = (int)lu.Y;
                    g.CopyFromScreen(x, y, 0, 0, new Size(X, Y));
                }
                return img;
            }
        }

        /// <summary>
        /// Struct representing a point.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }

        /// <summary>
        /// Retrieves the cursor's position, in screen coordinates.
        /// </summary>
        /// <see>See MSDN documentation for further information.</see>
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        public static Point GetCursorPosition()
        {
            POINT lpPoint;
            GetCursorPos(out lpPoint);
            //bool success = User32.GetCursorPos(out lpPoint);
            // if (!success)

            return lpPoint;
        }

    }
}