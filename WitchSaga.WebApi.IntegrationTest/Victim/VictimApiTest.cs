using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WitchSaga.WebApi.Controllers.Models;

namespace WitchSaga.WebApi.IntegrationTest.Victim
{
    public class VictimApiTest : ApiTestBase
    {
        [Test]
        public async Task ShouldReturn404WhenPostDataIsEmpty()
        {
            var client = Application.CreateClient();

            var postData = new CalculateAverageKillingModel
            {
                Victims = new List<VictimModel>()
            };

            var response = await client.PostAsJsonAsync("api/v1/victims/average", postData);

            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);

            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CalculateAverageModuleApiTestResponse>(jsonString);

            Assert.AreEqual(-1, result.Average);
        }

        [Test]
        public async Task ShouldReturn404WhenPostDataHasNegativeAge()
        {
            var client = Application.CreateClient();

            var victims = new List<VictimModel>();

            victims.Add(new VictimModel
            {
                AgeOfDeath = 10, YearOfDeath = 12
            });

            victims.Add(new VictimModel
            {
                AgeOfDeath = 12,
                YearOfDeath = 11
            });

            var postData = new CalculateAverageKillingModel
            {
                Victims = victims
            };

            var response = await client.PostAsJsonAsync("api/v1/victims/average", postData);

            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);

            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CalculateAverageModuleApiTestResponse>(jsonString);

            Assert.AreEqual(-1, result.Average);
        }

        [Test]
        public async Task ShouldReturn200WhenPostDataIsValid()
        {
            var client = Application.CreateClient();

            var victims = new List<VictimModel>();

            victims.Add(new VictimModel
            {
                AgeOfDeath = 10,
                YearOfDeath = 12
            });

            victims.Add(new VictimModel
            {
                AgeOfDeath = 13,
                YearOfDeath = 17
            });

            var postData = new CalculateAverageKillingModel
            {
                Victims = victims
            };

            var response = await client.PostAsJsonAsync("api/v1/victims/average", postData);

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CalculateAverageModuleApiTestResponse>(jsonString);

            Assert.AreEqual(4.5, result.Average);
        }

        public class CalculateAverageModuleApiTestResponse
        {
            public IEnumerable<string> Error { get; set; }
            public decimal Average { get; set; }
        }
    }
}
