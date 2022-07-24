using WitchSaga.Application.Services.Victim.Requests;

namespace WitchSaga.Application.Services.Victim
{
    public interface IVictimService
    {
        ServiceResponse<decimal> CalculateAverageKilling(CalculateAverageKillingRequest request);
    }
}
