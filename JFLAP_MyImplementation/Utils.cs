using System;
using System.Drawing;

namespace JFLAP_MyApproach
{
    class Utils
    {
        public double EuclidianDistance(Point P1, Point P2)
        {
            return Math.Sqrt(Math.Pow(P2.X - P1.X, 2) + Math.Pow(P2.Y - P1.Y, 2));
        }
    }
}
