using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WitchSaga.Application.NUnit.Victim
{
    public class KillingManagerTest
    {
        [Test]
        public void ShouldPerformYearlyKillingCalculation()
        {
            var manager = new Application.Services.Victim.KillingManager();

            // On the 1st year the result should 1 
            var firstYearTotalVictims = manager.CalculateYearlyKilling(1);
            Assert.AreEqual(1, firstYearTotalVictims);

            // On the 2nd year the result should 2 
            var secondYearTotalVictims = manager.CalculateYearlyKilling(2);
            Assert.AreEqual(2, secondYearTotalVictims);

            // On the 3rd year the result should 4 
            var thirdYearTotalVictims = manager.CalculateYearlyKilling(3);
            Assert.AreEqual(4, thirdYearTotalVictims);

            // On the 4th year the result should 7 
            var fourthYearTotalVictims = manager.CalculateYearlyKilling(4);
            Assert.AreEqual(7, fourthYearTotalVictims);

            // On the 5th year the result should 12 
            var fifthYearTotalVictims = manager.CalculateYearlyKilling(5);
            Assert.AreEqual(12, fifthYearTotalVictims);
        }
    }
}
