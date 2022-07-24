using System.Linq;
using WitchSaga.Application.Services.Victim.Requests;

namespace WitchSaga.Application.Services.Victim
{
    public class VictimService : IVictimService
    {
        private readonly IKillingManager _manager;

        public VictimService(IKillingManager manager)
        {
            this._manager = manager;
        }

        public ServiceResponse<decimal> CalculateAverageKilling(CalculateAverageKillingRequest request)
        {
            var response = new ServiceResponse<decimal>();

            if (request.ValidateRequest())
            {
                var totalYearlyKilling = request.Victims.Sum(victim => this._manager.CalculateYearlyKilling(victim.BornOnYear));
                var averageKilling = totalYearlyKilling / (decimal)request.Victims.Count;

                response.Result = averageKilling;

                return response;
            }
            else
            {
                response.AddException("Invalid Data");
                response.Result = -1;
            }

            return response;
        }
    }
}
