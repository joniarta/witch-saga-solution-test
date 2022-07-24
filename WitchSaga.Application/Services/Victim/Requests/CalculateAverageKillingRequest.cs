using System.Collections.Generic;
using System.Linq;

namespace WitchSaga.Application.Services.Victim.Requests
{
    public class CalculateAverageKillingRequest : RequestBase
    {
        private ICollection<Dtos.Victim> _victims;

        public ICollection<Dtos.Victim> Victims
        {
            get { return this._victims ?? (this._victims = new List<Dtos.Victim>()); }
        }

        public override bool ValidateRequest()
        {
            return this.Victims.Count > 0 && !this.Victims.Any(victim => victim.BornOnYear < 1);
        }
    }
}
