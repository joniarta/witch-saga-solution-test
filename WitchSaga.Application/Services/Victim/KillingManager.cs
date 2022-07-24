namespace WitchSaga.Application.Services.Victim
{
    public class KillingManager : IKillingManager
    {
        public KillingManager() { }

        public int CalculateYearlyKilling(int year)
        {
            if (year == 1) return year;

            return this.Fibo(year) + this.CalculateYearlyKilling(--year);
        }

        private int Fibo(int i)
        {
            if (i <= 1) return i;

            return this.Fibo(--i) + this.Fibo(--i);
        }
    }
}
