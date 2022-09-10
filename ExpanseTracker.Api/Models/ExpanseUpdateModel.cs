namespace ExpanseTracker.Api.Models
{
    public class ExpanseUpdateModel
    {
        public int ID { get; set; }

        public string? ExpanseName { get; set; }

        public decimal ExpanseAmount { get; set; }
        public DateTime ExpanseDate { get; set; }
    }
}
