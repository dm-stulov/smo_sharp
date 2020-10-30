using System;

namespace smo_sharp.Models
{
    public static class MathHelper
    {
        public static Random rand = new Random();

        public static long GetLineDistribution(int minArg, int maxArg)
        {
            return rand.Next(minArg, maxArg);
        }

        public static long GetExpDistribution(int minArg, int maxArg)
        {
            return Convert.ToInt64(Math.Log(GetLineDistribution(minArg, maxArg)));
        }
    }
}