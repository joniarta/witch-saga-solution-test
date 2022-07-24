using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WitchSaga.WebApi.Controllers.Models
{
    public class CalculateAverageKillingModel
    {
        [Required]
        public ICollection<VictimModel> Victims { get; set; }
    }
}
