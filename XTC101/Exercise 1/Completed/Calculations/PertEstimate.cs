using System;

namespace Calculations
{
    public class PertEstimate
    {
        public static double Estimate(double likelyAmount, double bestCaseAmount,
            double worstCaseAmount)
        {
            return (likelyAmount * 4 + bestCaseAmount + worstCaseAmount) / 6;
        }
    }
}

