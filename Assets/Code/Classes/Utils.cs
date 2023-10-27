using UnityEngine;

namespace CustomUtil
{
    public class Utils
    {
        public static float GetFloatInRange(float min, float max)
        {
            System.Random random = new System.Random();
            double val = (random.NextDouble() * (max - min) + min);
            return (float)val;
        }

        public static float GetFloatInRange(Vector2 minMaxPair)
        {
            System.Random random = new System.Random();
            double val = (random.NextDouble() * (minMaxPair.y - minMaxPair.x) + minMaxPair.x);
            return (float)val;
        }
    }
}
