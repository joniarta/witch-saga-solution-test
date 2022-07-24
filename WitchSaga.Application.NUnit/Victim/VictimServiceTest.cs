using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WitchSaga.Application.Services.Victim;
using WitchSaga.Application.Services.Victim.Requests;

namespace WitchSaga.Application.NUnit.Victim
{
    public class VictimServiceTest
    {
        private Mock<IKillingManager> _mockKillingManager = null;
        private VictimService _victimService = null;

        [SetUp]
        public void Setup()
        {
            this._mockKillingManager = new Mock<IKillingManager>();
            
            this._mockKillingManager
                .Setup(m => m.CalculateYearlyKilling(1))
                .Returns(1);
            this._mockKillingManager
                .Setup(m => m.CalculateYearlyKilling(2))
                .Returns(2);
            this._mockKillingManager
                .Setup(m => m.CalculateYearlyKilling(3))
                .Returns(4);
            this._mockKillingManager
                .Setup(m => m.CalculateYearlyKilling(4))
                .Returns(7);
            this._mockKillingManager
                .Setup(m => m.CalculateYearlyKilling(5))
                .Returns(12);

            this._victimService = new VictimService(this._mockKillingManager.Object);
        }

        [Test]
        public void ShouldReturnInvalidDataMinusOneWhenRequestIsEmpty()
        {
            var response = this._victimService.CalculateAverageKilling(new CalculateAverageKillingRequest());

            Assert.AreEqual(-1, response.Result);
            Assert.IsTrue(response.HasError);
            Assert.AreEqual(1, response.Exceptions.Count());
        }

        [Test]
        public void ShouldReturnInvalidDataMinusOneWhenRequestHasNegativeAge()
        {
            var request = new CalculateAverageKillingRequest();
            
            request.Victims.Add(new Services.Victim.Dtos.Victim
            {
                AgeOfDeath = 10, YearOfDeath = 12
            });

            request.Victims.Add(new Services.Victim.Dtos.Victim
            {
                AgeOfDeath = 15,
                YearOfDeath = 12
            });

            var response = this._victimService.CalculateAverageKilling(request);

            Assert.AreEqual(-1, response.Result);
            Assert.IsTrue(response.HasError);
            Assert.AreEqual(1, response.Exceptions.Count());
        }

        [Test]
        public void ShouldReturnSucessReponseWithValidAverageKillingResultFirstTest()
        {
            var request = new CalculateAverageKillingRequest();

            request.Victims.Add(new Services.Victim.Dtos.Victim
            {
                AgeOfDeath = 10,
                YearOfDeath = 12
            });

            request.Victims.Add(new Services.Victim.Dtos.Victim
            {
                AgeOfDeath = 13,
                YearOfDeath = 17
            });

            var response = this._victimService.CalculateAverageKilling(request);

            Assert.AreEqual(4.5, response.Result);
            Assert.IsFalse(response.HasError);
            Assert.AreEqual(0, response.Exceptions.Count());
        }

        [Test]
        public void ShouldReturnSucessReponseWithValidAverageKillingResultSecondTest()
        {
            var request = new CalculateAverageKillingRequest();

            request.Victims.Add(new Services.Victim.Dtos.Victim
            {
                AgeOfDeath = 10,
                YearOfDeath = 12
            });

            request.Victims.Add(new Services.Victim.Dtos.Victim
            {
                AgeOfDeath = 13,
                YearOfDeath = 17
            });

            request.Victims.Add(new Services.Victim.Dtos.Victim
            {
                AgeOfDeath = 20,
                YearOfDeath = 25
            });

            var response = this._victimService.CalculateAverageKilling(request);

            Assert.AreEqual(7, response.Result);
            Assert.IsFalse(response.HasError);
            Assert.AreEqual(0, response.Exceptions.Count());
        }
    }
}
