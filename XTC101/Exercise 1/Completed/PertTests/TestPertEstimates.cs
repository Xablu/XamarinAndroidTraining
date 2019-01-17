using NUnit.Framework;
using System;
using Calculations;

namespace PertTests
{
    [TestFixture]
    public class TestPertEstimates
    {
        [Test]
        public void PertEstimate_CalculationWithPositiveValues_CheckAccuracyIsSuccess()
        {
            // Arrange
            double likelyAmount = 20;
            double bestCaseAmount = 12;
            double worstCaseAmount = 40;
            double estimatedResult = 22;

            // Act
            double actualAmount = PertEstimate.Estimate(likelyAmount,
                bestCaseAmount, worstCaseAmount);

            // Assert
            Assert.AreEqual(estimatedResult, actualAmount);
        }
    }
}

