namespace StudAdminPortal.API.DataModels
{
    public class PremiumCalculationResponse
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string dateOfBirth { get; set; }
        public string occupation { get; set; }
        public int age { get; set; }
        public double deathSumInsured { get; set; }
        public double premiumAmount { get; set; }
    }
}
