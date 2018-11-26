using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Point = System.Windows.Point;

namespace BMS3
{
    class match
    {
        public static double find(Point lu, int x, int y, string pic)
        {
            mimage.lu = lu;
            mimage.X = x;
            mimage.Y = y;
            Image<Gray, Byte> screen_image = new Image<Gray, Byte>(mimage.img_bitmap);

            using (Mat result = new Mat())
            using (Mat modelImage = CvInvoke.Imread(pic, ImreadModes.Grayscale))
            {
                var modimage = modelImage.ToImage<Gray, Byte>();

                CvInvoke.MatchTemplate(screen_image, modimage, result, TemplateMatchingType.CcorrNormed);

                double minVal = 0; double maxVal = 0;
                System.Drawing.Point minLoc = new System.Drawing.Point(-1, -1);
                System.Drawing.Point maxLoc = new System.Drawing.Point(-1, -1);
                System.Drawing.Point matchLoc = new System.Drawing.Point(-1, -1);

                CvInvoke.MinMaxLoc(result, ref minVal, ref maxVal, ref minLoc, ref maxLoc);

                bool isMatch = maxLoc != new System.Drawing.Point(-1, -1);
                if (isMatch)
                {
                    return maxVal;
                }
            }

            return 0;
        }
    }
}