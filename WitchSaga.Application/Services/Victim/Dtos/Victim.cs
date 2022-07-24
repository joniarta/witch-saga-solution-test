namespace WitchSaga.Application.Services.Victim.Dtos
{
    public class Victim
    {
        public int AgeOfDeath { get; set; }

        public int YearOfDeath { get; set; }

        public int BornOnYear
        {
            get { return this.YearOfDeath - this.AgeOfDeath; }
        }
    }
}
