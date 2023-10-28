using UnityEngine;

namespace CustomUtil
{
    public class Utils
    {
        public static float GetFloatInRange(float min, float max)
        {
            return (float)GetDoubleInRange(min, max);
        }

        public static float GetFloatInRange(Vector2 minMaxPair)
        {
            return (float)GetDoubleInRange(minMaxPair.x, minMaxPair.y);
        }

        public static double GetDoubleInRange(double min, double max)
        {
            System.Random random = new System.Random();
            double val = (random.NextDouble() * (max - min) + min);
            return val;
        }
    }
}
