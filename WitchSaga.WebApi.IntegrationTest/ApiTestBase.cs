using NUnit.Framework;

namespace WitchSaga.WebApi.IntegrationTest
{
    public class ApiTestBase
    {
        protected ApiWebApplication Application;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            Application = new ApiWebApplication();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            Application.Dispose();
        }
    }
}
